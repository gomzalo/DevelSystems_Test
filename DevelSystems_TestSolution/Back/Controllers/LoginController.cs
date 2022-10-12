using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.Username == "admin" && user.Password == "admin")
            {
                return Ok(new { Token = "This is your token" });
            }

            return Unauthorized();
        }
    }
}
