using Microsoft.AspNetCore.Mvc;
using RecipeBase_Backend.Application.UseCases.Commands;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Implementation;

namespace RecipeBase_Backend.Api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class RegisterController : ControllerBase
        {
            public UseCaseHandler handler { get; set; }
            public IRegisterUser registerCommand { get; set; }

            public RegisterController(UseCaseHandler handler, IRegisterUser registerCommand)
            {
                this.handler = handler;
                this.registerCommand = registerCommand;
            }

            // POST api/<RegisterController>
            [HttpPost]
            public IActionResult Post([FromBody] RegisterDto request)
            {
                this.handler.Handle(this.registerCommand, request);

                return StatusCode(201);
            }

        }
}
