using DTO.Authenticate.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi_Test.Auth;

namespace WebApi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("authenticateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> authenticateUser([FromBody]LoginRequest request)
        {

            List<UserRoles> userData = new List<UserRoles>();
            userData.Add(new UserRoles { userName = "tester", password = "1234", role = "User" });
            userData.Add(new UserRoles { userName = "Admin", password = "1234", role = "Admin" });

            var usercheck =userData.Where(x => x.userName == request.userName && x.password ==request.password ).ToList().FirstOrDefault();

            if (usercheck != null )
            {


                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usercheck.userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role,usercheck.role)
                };

                
                   
               
                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
