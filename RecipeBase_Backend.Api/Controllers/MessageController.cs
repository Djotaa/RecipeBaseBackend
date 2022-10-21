using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBase_Backend.Application.UseCases.Commands;
using RecipeBase_Backend.Application.UseCases.Commands.Recipes;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using RecipeBase_Backend.Application.UseCases.Queries;
using RecipeBase_Backend.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBase_Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private UseCaseHandler handler;

        public MessageController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        // GET: api/<MessageController>
        [HttpGet]
        public IActionResult Get([FromQuery] PagedSearch search,[FromServices] IGetMessagesQuery query)
        {
            return Ok(handler.Handle(query, search));
        }

        // POST api/<MessageController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] CreateMessageDto dto, [FromServices] ISendMessage command)
        {
            this.handler.Handle(command, dto);

            return StatusCode(201);
        }

        [HttpDelete]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteMessage command)
        {
            this.handler.Handle(command, id);

            return StatusCode(204);
        }
    }
}
