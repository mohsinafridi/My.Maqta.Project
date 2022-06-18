using APIGateway.Models;
using APIGateway.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]        
        [AllowAnonymous]
        public ActionResult<AuthToken> GetCategoriesAuthentication([FromBody] AuthUser user)
        {
            if (user.Username != "admin" || user.Password != "admin")
            {
                return BadRequest(new { message = "Username or Password is invalid" });
            }

            return new EmployeeTokenService().GenerateToken(user);
        }

        [HttpGet]
        public ActionResult<AuthToken> Get()
        {
            return Ok();
        }
    }
}
