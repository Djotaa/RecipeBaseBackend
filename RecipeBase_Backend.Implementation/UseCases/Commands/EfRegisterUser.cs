using FluentValidation;
using Mapster;
using MapsterMapper;
using RecipeBase_Backend.Application.UseCases.Commands;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using RecipeBase_Backend.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Commands
{
    public class EfRegisterUser : EfUseCase, IRegisterUser
    {
        RegisterUserValidator validator;
        UserValidator userValidator;
        public EfRegisterUser(AppDbContext dbContext, RegisterUserValidator validator, UserValidator userValidator)
            : base(dbContext)
        {
            this.validator = validator;
            this.userValidator = userValidator;
        }
        public int Id => 2;

        public string Name => "User Registration";

        public string Description => "Create new user with user data";

        public void Execute(RegisterDto request)
        {
            userValidator.ValidateAndThrow(request);
            validator.ValidateAndThrow(request);


            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var userEntry = this.DbContext.Users.Add(request.Adapt<User>());

            var useCaseIds = new List<int> { 1, 2, 3, 4 };
            for (int id = 15; id <= 20; id++)
                useCaseIds.Add(id);

            userEntry.Entity.UseCases = new List<UseCase>();

            foreach (var id in useCaseIds)
                userEntry.Entity.UseCases.Add(new UseCase { UseCaseId = id });

            this.DbContext.SaveChanges();
        }
    }
}
