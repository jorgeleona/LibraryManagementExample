using System.Security.Claims;
using LibraryManagement.API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;

        public class AuthenticateRequest
        {
            public required string User { get; set; }
            public required string Password { get; set; }
        }

        [HttpPost("auth-token")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest authRequest)
        {
            // Add logic to authenticate user on db
            if (!string.IsNullOrEmpty(authRequest.User) && !string.IsNullOrEmpty(authRequest.Password))
                if (authRequest.User.Equals("xuser")
                && authRequest.Password.Equals("#$$u53r??"))
                {
                    JWTProvider jwtProvider = JWTProvider.GetInstance(_configuration);
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim("sub", authRequest.User)
                    };
                    return Ok(jwtProvider.GenerateToken(claims));
                }

            return BadRequest("Invalid Request");
        }
    }
}