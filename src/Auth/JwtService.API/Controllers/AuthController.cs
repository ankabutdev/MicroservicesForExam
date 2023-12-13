using JwtService.API.Models;
using JwtService.Core;
using JwtService.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtService.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtTokenHandler _jwtTokenHandler;

    public AuthController(JwtTokenHandler jwtTokenHandler)
    {
        _jwtTokenHandler = jwtTokenHandler;
    }

    [HttpPost]
    public ActionResult<AuthenticationResponse?> Authenticate(AuthenticationRequest authentication)
    {
        var result = _jwtTokenHandler.GenereteToken(authentication);

        if (authentication == null) return Unauthorized();

        return Ok(result);
    }
}
