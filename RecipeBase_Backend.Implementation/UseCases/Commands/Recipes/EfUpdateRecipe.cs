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
    public class EfUpdateRecipe : EfUseCase, IUpdateRecipe
    {
        public RecipeValidator validator { get; set; }
        private IAzureService azureService;

        public EfUpdateRecipe(AppDbContext context, RecipeValidator validator, IAzureService azureService) : base(context)
        {
            this.validator = validator;
            this.azureService = azureService;
        }

        public int Id => 20;

        public string Name => "Update recipe";

        public string Description => "Users can update their recipes";

        public void Execute(UpdateRecipeDtoWithImage request)
        {
            validator.ValidateAndThrow(request);

            var recipe = DbContext.Recipes.Where(x=>x.IsActive).FirstOrDefault(y=>y.Id == request.Id);

            if (recipe == null)
                throw new EntityNotFoundException();

            if (recipe.AuthorId != DbContext.AppUser.Id)
                throw new UseCaseConflictException("Users can only update their own recipes.");

            if (request.Image != null)
            {
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

                azureService.Delete(recipe.Image.Path.Split('/').Last());

                var filePath = azureService.Upload(request.Image.OpenReadStream(), fileName, contentType);
                
                recipe.Image = new Image { Path = filePath };
            }

            recipe.Title = request.Title;
            recipe.PrepTime = request.PrepTime;
            recipe.CategoryId = request.CategoryId;
            DbContext.Ingredients.RemoveRange(recipe.Ingredients);
            DbContext.Directions.RemoveRange(recipe.Directions);
            recipe.Directions = request.Directions.Select((d,i) => new Direction
            {
                Step = d,
                StepNumber = i+1
            }).ToList();
            recipe.Ingredients = request.Ingredients.Select(x => new Ingredient
            {
                Value = x
            }).ToList();

            DbContext.SaveChanges();
        }
    }
}
