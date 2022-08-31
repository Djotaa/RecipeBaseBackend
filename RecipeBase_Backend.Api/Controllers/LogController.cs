using Microsoft.AspNetCore.Mvc;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using RecipeBase_Backend.Application.UseCases.Queries;
using RecipeBase_Backend.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBase_Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        public UseCaseHandler handler { get; set; }

        public LogController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get([FromQuery] PagedAuditLogSearch request, [FromServices] IGetAuditLog query)
        {
            return Ok(this.handler.Handle(query, request));
        }

    }
}
