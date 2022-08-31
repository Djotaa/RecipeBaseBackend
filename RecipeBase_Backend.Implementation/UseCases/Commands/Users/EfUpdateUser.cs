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
        UserValidator validator;
        public EfUpdateUser(AppDbContext context, UserValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 10;

        public string Name => "Update User";

        public string Description => "Update existing User";

        public void Execute(UserDto request)
        {
            this.validator.ValidateAndThrow(request);

            var user = this.DbContext.Users.Where(x => x.IsActive).FirstOrDefault(x => x.Id == request.Id);

            if (user == null)
                throw new EntityNotFoundException();

            this.DbContext.UseCases.RemoveRange(user.UseCases);
            user.Username = request.Username;
            user.FullName = request.FullName;
            user.Email = request.Email;
            user.UseCases = request.UseCaseIds.Select(x => new UseCase
            {
                UseCaseId = x
            }).ToList();            

            this.DbContext.SaveChanges();
        }
    }
}
