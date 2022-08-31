using Microsoft.AspNetCore.Mvc;
using RecipeBase_Backend.Application.UseCases.Commands;
using RecipeBase_Backend.Implementation;

namespace RecipeBase_Backend.Api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class SeedController : ControllerBase
        {
            public UseCaseHandler handler { get; set; }
            public ISeed seedCommand { get; set; }

            public SeedController(
                UseCaseHandler handler,
                ISeed seedCommand
                )
            {
                this.handler = handler;
                this.seedCommand = seedCommand;
            }

            // POST api/<SeedController>
            [HttpPost]
            public void Post()
            {
                this.handler.Handle(seedCommand);
            }

        }
}
