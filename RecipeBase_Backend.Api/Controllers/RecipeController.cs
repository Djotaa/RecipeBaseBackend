using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBase_Backend.Application.UseCases.Commands.Recipes;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using RecipeBase_Backend.Application.UseCases.Queries.Recipes;
using RecipeBase_Backend.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBase_Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        public UseCaseHandler handler { get; set; }

        public RecipeController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        // GET: api/<RecipeController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] PagedSearch request, [FromServices] IGetRecipesQuery query)
        {
            return Ok(this.handler.Handle(query, request));
        }

        // GET api/<RecipeController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IGetRecipeQuery query)
        {
            return Ok(this.handler.Handle(query, id));

        }

        // POST api/<RecipeController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRecipeDto request, [FromServices] ICreateRecipe command)
        {
            this.handler.Handle(command, request);

            return StatusCode(201);
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateRecipeDto request, [FromServices] IUpdateRecipe command)
        {
            request.Id = id;
            handler.Handle(command, request);

            return StatusCode(201);
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRecipe command)
        {
            this.handler.Handle(command, id);

            return StatusCode(204);
        }
    }
}
