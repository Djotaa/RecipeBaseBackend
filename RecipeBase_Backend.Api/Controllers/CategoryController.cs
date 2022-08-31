using Microsoft.AspNetCore.Mvc;
using RecipeBase_Backend.Application.UseCases.Commands.Categories;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using RecipeBase_Backend.Application.UseCases.Queries.Categories;
using RecipeBase_Backend.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBase_Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private UseCaseHandler handler;

        public CategoryController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get([FromQuery] PagedSearch request, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(this.handler.Handle(query, request));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCategoryQuery query)
        {
            return Ok(handler.Handle(query, id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryDto request, [FromServices] ICreateCategory command)
        {
            this.handler.Handle(command, request);

            return StatusCode(201);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryDto request, [FromServices] IUpdateCategory command)
        {
            request.Id = id;
            this.handler.Handle(command, request);

            return StatusCode(204);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategory command)
        {
            this.handler.Handle(command, id);

            return StatusCode(204);
        }
    }
}
