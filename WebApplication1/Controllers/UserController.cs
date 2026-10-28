using Microsoft.AspNetCore.Mvc;
using Game.ServiceLayer;
using GameDomain;
namespace WebApplication1.Controllers;


[ApiController]
[Route("api/[controller]")]
/// <summary>
///   
/// </summary>
public class UserController : ControllerBase // Controller for handling game-related API requests
{

  private UserService _userService; // Dependency injection for the UserService
/// <summary>
///   
/// </summary>
/// <param name="userService"></param>
  public UserController(UserService userService) // Constructor injection for the UserService
  {
    DataService dataService = new DataService();
    _userService = userService;
  }

  [HttpGet]
  /// <summary>
  ///   
  /// </summary>
  /// <returns></returns>
  public ActionResult<List<GameDomain.UserDto>> GetUsers() // GET: api/user
  {
    var users = _userService.GetAllUsers();
    return Ok(users);
  }

  [HttpGet("{id}")]
  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public ActionResult<GameDomain.UserDto> GetById(int id) // GET: api/user/{id}
  {
    var user = _userService.GetById(id);

    if (user == null) return NotFound();
    return Ok(user);
  }
  [HttpPost]
  /// <summary>
  ///   
  /// </summary>
  /// <param name="createUserDto"></param>
  /// <returns></returns>
  public ActionResult<GameDomain.UserDto> CreateUser([FromBody] GameDomain.CreateUserDto createUserDto) // POST: api/user
  {
    var newUser = _userService.CreateUser(createUserDto);
    return Created($"/api/user/{newUser.Id}", newUser);
  }

  [HttpPut("{id}")]
  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <param name="updateUserDto"></param>
  /// <returns></returns>
  public ActionResult<GameDomain.UserDto> UpdateUser(int id, [FromBody] GameDomain.UpdateUserDto updateUserDto) // PUT: api/user/{id}
  {
    var success = _userService.UpdateUser(id, updateUserDto);

    if (!success) return NotFound();

    return NoContent();
  }

  [HttpDelete("{id}")]
  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public IActionResult DeleteUser(int id) // DELETE: api/user/{id}
  {
    var success = _userService.DeleteUser(id);

    if (!success) return NotFound();

    return NoContent();
  }
[HttpGet ("In Work")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public ActionResult<List<UserDto>> GetUser()
  {
    return GetUser();
  }
}

  

/* [HttpGet("GetList")]
public ActionResult<List<GameDto>> GetGames()
{
  return Ok(_games);
}
*/
/* [HttpGet("Id")]
public ActionResult<GameDto> GetGames()
{
  return Ok(_games);
} */


