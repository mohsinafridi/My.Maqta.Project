using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Maqta.Project.Models;
using My.Maqta.Project.Services;

namespace My.Maqta.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("employees")]
        [AllowAnonymous]
        public ActionResult<AuthToken> GetCategoriesAuthentication([FromBody] AuthUser user)
        {
            if (user.Username != "admin" || user.Password != "admin")
            {
                return BadRequest(new { message = "Username or Password is invalid" });
            }

            return new APITokenService().GenerateToken(user);
        }
    }
}
