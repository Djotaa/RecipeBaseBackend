using FluentValidation;
using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.Services;
using RecipeBase_Backend.Application.UseCases.Commands.Recipes;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using RecipeBase_Backend.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecipeBase_Backend.Implementation.UseCases.Commands.Recipes
{
    public class EfCreateRecipe : EfUseCase, ICreateRecipe
    {
        public RecipeValidator validator;
        private IAzureService azureService;
        public EfCreateRecipe(AppDbContext context, RecipeValidator validator, IAzureService azureService) : base(context)
        {
            this.validator = validator;
            this.azureService = azureService;
        }

        public int Id => 18;

        public string Name => "Create Recipe";

        public string Description => "Insert new Recipe";

        public void Execute(CreateRecipeDtoWithImage request)
        {
            if (request.Image == null)
            {
                throw new UseCaseConflictException("Image not provided.");
            }

            validator.ValidateAndThrow(request);

            List<string> AllowedImageExtensions = new List<string> { ".jpg", ".png", ".jpeg" };

            var guid = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(request.Image.FileName);
            if (!AllowedImageExtensions.Contains(extension.ToLower()))
            {
                throw new UseCaseConflictException("Unsupported file type.");
            }
            var fileName = guid + extension;
            var contentType = request.Image.ContentType;

            //var filePath = Path.Combine("wwwroot", "images", fileName);
            //using var stream = new FileStream(filePath, FileMode.Create);
            //request.Image.CopyTo(stream);

            var filePath = azureService.Upload(request.Image.OpenReadStream(), fileName, contentType);

            var recipe = new Recipe
            {
                Title = request.Title,
                PrepTime = request.PrepTime,
                CategoryId = request.CategoryId,
                Ingredients = request.Ingredients.Select(x => new Ingredient
                {
                    Value = x
                }).ToList(),
                Image = new Image { Path = filePath },
                Directions = request.Directions.Select( (d,i)  => new Direction
                {
                    Step = d,
                    StepNumber = i+1
                }).ToList(),
                AuthorId = DbContext.AppUser.Id
            };

            DbContext.Recipes.Add(recipe);
            DbContext.SaveChanges();
        }
    }
}
