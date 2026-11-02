using Microsoft.AspNetCore.Mvc;
using Game.ServiceLayer;
using GameDomain;
namespace WebApplication1.Controllers;


[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase // Controller for handling authentication-related API requests
{
  private GameService _gameService; // Dependency injection for the GameService
private readonly AuthService _authService;
  public AuthController(GameService gameService, AuthService authService) // Constructor injection for the GameService
  {
    _gameService = gameService;
    _authService = authService;
  }
[HttpPost("login")]
public ActionResult<LoginResponseDto> Login([FromBody] LoginRequestDto loginRequest)
{   
    LoginResponseDto response = _authService.Login(loginRequest);

    if (response == null)
    {
        // Don't say "Password was wrong" or "User does not exist".
        // Always return a generic error message.
        return Unauthorized("Invalid login credentials.");
    }

    return Ok(response);
}
}