using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.Commands.Users;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using RecipeBase_Backend.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Commands.Users
{
    public class EfUpdateUser : EfUseCase, IUpdateUser
    {
        UpdateUserValidator validator;
        public EfUpdateUser(AppDbContext context, UpdateUserValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 10;

        public string Name => "Update User";

        public string Description => "Update existing User";

        public void Execute(UpdateUserDto request)
        {
            this.validator.ValidateAndThrow(request);

            var user = this.DbContext.Users.Where(x => x.IsActive).FirstOrDefault(x => x.Id == request.Id);

            if (user == null)
                throw new EntityNotFoundException();

            if (user.Id != DbContext.AppUser.Id)
                throw new UseCaseConflictException("Users can only update their own profile.");

            user.Username = request.Username;
            user.FullName = request.FullName;
            user.Email = request.Email; 

            this.DbContext.SaveChanges();
        }
    }
}
