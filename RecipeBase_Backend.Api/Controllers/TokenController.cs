using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBase_Backend.Api.Core;
using RecipeBase_Backend.Api.Core.DTO;

namespace RecipeBase_Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private JwtManager jwtManager;

        public TokenController(JwtManager jwtManager)
        {
            this.jwtManager = jwtManager;
        }


        // POST api/<TokenController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] TokenRequest request)
        {
            return Ok(new { Token = this.jwtManager.CreateToken(request.Username, request.Password) });
        }
    }
}
