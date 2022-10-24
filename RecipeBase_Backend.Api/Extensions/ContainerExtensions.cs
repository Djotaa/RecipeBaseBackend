using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RecipeBase_Backend.Api.Core;
using RecipeBase_Backend.Application.Services;
using RecipeBase_Backend.Application.UseCases.Commands;
using RecipeBase_Backend.Application.UseCases.Commands.Categories;
using RecipeBase_Backend.Application.UseCases.Commands.Favorites;
using RecipeBase_Backend.Application.UseCases.Commands.Recipes;
using RecipeBase_Backend.Application.UseCases.Commands.Users;
using RecipeBase_Backend.Application.UseCases.Queries;
using RecipeBase_Backend.Application.UseCases.Queries.Categories;
using RecipeBase_Backend.Application.UseCases.Queries.Recipes;
using RecipeBase_Backend.Application.UseCases.Queries.Users;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using RecipeBase_Backend.Implementation.Services;
using RecipeBase_Backend.Implementation.UseCases.Commands;
using RecipeBase_Backend.Implementation.UseCases.Commands.Categories;
using RecipeBase_Backend.Implementation.UseCases.Commands.Favorites;
using RecipeBase_Backend.Implementation.UseCases.Commands.Recipes;
using RecipeBase_Backend.Implementation.UseCases.Commands.Users;
using RecipeBase_Backend.Implementation.UseCases.Queries;
using RecipeBase_Backend.Implementation.UseCases.Queries.Categories;
using RecipeBase_Backend.Implementation.UseCases.Queries.Recipes;
using RecipeBase_Backend.Implementation.UseCases.Queries.Users;
using RecipeBase_Backend.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBase_Backend.Api.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddAppUser(this IServiceCollection services)
        {
            services.AddTransient<IAppUser>(s =>
            {
                var httpContextAccessor = s.GetService<IHttpContextAccessor>();

                var claims = httpContextAccessor.HttpContext.User;
                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonymousAppUser();
                }

                var obj = new JwtAppUser()
                {
                    Id = Convert.ToInt32(claims.FindFirst("UserId").Value),
                    Username = claims.FindFirst("Username").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCaseIds").Value)
                };


                return obj;

            });
        }
        public static void AddAppDbContext(this IServiceCollection services)
        {
            services.AddTransient(s =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder();

                var connString = s.GetService<AppSettings>().ConnectionString;
                dbContextOptionsBuilder.UseSqlServer(connString).UseLazyLoadingProxies();

                return new AppDbContext(dbContextOptionsBuilder.Options, s.GetService<IAppUser>());
            });
        }
        public static void AddJwt(this IServiceCollection services, JwtSettings jwtConfig)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<AppDbContext>();
                var config = x.GetService<AppSettings>();

                return new JwtManager(context, jwtConfig);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtConfig.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.PrivateKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ISeed, EfSeed>();

            services.AddTransient<IRegisterUser, EfRegisterUser>();
            services.AddTransient<IDeleteUser, EfDeleteUser>();
            services.AddTransient<IUpdateUser, EfUpdateUser>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();
            services.AddTransient<IGetUserRecipesQuery, EfGetUserRecipesQuery>();

            services.AddTransient<IGetRecipesQuery, EfGetRecipesQuery>();
            services.AddTransient<IGetRecipeQuery, EfGetRecipeQuery>();
            services.AddTransient<ICreateRecipe, EfCreateRecipe>();
            services.AddTransient<IDeleteRecipe, EfDeleteRecipe>();
            services.AddTransient<IUpdateRecipe, EfUpdateRecipe>();

            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<IGetCategoryQuery, EfGetCategoryQuery>();
            services.AddTransient<ICreateCategory, EfCreateCategory>();
            services.AddTransient<IDeleteCategory, EfDeleteCategory>();
            services.AddTransient<IUpdateCategory, EfUpdateCategory>();

            services.AddTransient<IGetAuditLog, EfGetAuditLogQuery>();

            services.AddTransient<IGetFavoritesQuery, EfGetFavoritesQuery>();
            services.AddTransient<IAddFavorite, EfAddFavorite>();
            services.AddTransient<IRemoveFavorite, EfRemoveFavorite>();


            services.AddTransient<IGetMessagesQuery, EfGetMessagesQuery>();
            services.AddTransient<ISendMessage, EfSendMessage>();
            services.AddTransient<IDeleteMessage, EfDeleteMessage>();

            services.AddScoped<IAzureService, AzureService>();



            #region Validators
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<UserValidator>();
            services.AddTransient<CategoryValidator>();
            services.AddTransient<RecipeValidator>();
            //services.AddTransient<DirectionValidator>();
            services.AddTransient<MessageValidator>();
            #endregion
        }
    }
}
