using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Common;

namespace WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(string user, string pass)
        {
            if (user == JwtCredentials.User && pass == JwtCredentials.Pass)
            {
                var token = GenerateJwtToken(user);
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private static string GenerateJwtToken(string username)
        {
            var key = Encoding.ASCII.GetBytes(JwtCredentials.Key);
            var claims = new Claim[]{ new(ClaimTypes.Name, username) };
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(JwtCredentials.Issuer,JwtCredentials.Audience, claims, expires: DateTime.Now.AddMinutes(60),signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
