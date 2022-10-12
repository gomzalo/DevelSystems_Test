using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Back.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.Username == "admin" && user.Password == "admin")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DevelSystems_SuperSecretKey"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "Jwt:Issuer",
                    audience: "Jwt:Audience",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(25),
                    signingCredentials: signinCredentials
                );

                var tokenStr = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenStr });
            }

            return Unauthorized();
        }
    }
}
