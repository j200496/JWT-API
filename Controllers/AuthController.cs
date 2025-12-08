using JsonWebToken.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin user)
        {
            if (user.Username == "admin" && user.Password == "admin")
            {
               var token = GenerateJwtToken(user.Username);
                return Ok(new {token });
            }
            return Unauthorized();
        }

        private object GenerateJwtToken(string username)
        {
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, username),
              new Claim(JwtRegisteredClaimNames.Jti, Guid .NewGuid().ToString()),
          };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ClaveParaDemostracion123456789123456789123456789123456789123456789!!"));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "DemoJwt",
                audience: "UsuariosDemo",
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
               );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
