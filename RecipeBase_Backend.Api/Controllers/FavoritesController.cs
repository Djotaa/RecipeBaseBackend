using Microsoft.AspNetCore.Mvc;
using RecipeBase_Backend.Application.UseCases.Commands.Favorites;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using RecipeBase_Backend.Application.UseCases.Queries;
using RecipeBase_Backend.Implementation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBase_Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private UseCaseHandler handler;

        public FavoritesController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        // GET api/<FavoritesController>
        [HttpGet]
        public IActionResult Get([FromQuery] PagedSearch request, [FromServices] IGetFavoritesQuery query)
        {
            //request.Username = username;
            return Ok(handler.Handle(query, request));
        }

        // POST api/<FavoritesController>
        [HttpPost]
        public IActionResult Post([FromBody] int request, [FromServices] IAddFavorite command)
        {
            this.handler.Handle(command, request);

            return StatusCode(201);
        }

        // PUT api/<FavoritesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FavoritesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveFavorite command)
        {
            this.handler.Handle(command, id);

            return StatusCode(204);
        }
    }
}
