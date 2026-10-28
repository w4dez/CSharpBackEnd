using Microsoft.AspNetCore.Mvc;
using Game.ServiceLayer;
namespace WebApplication1.Controllers;


[ApiController]
[Route("api/[controller]")]
/// <summary>
///       
/// </summary>
public class UserController : ControllerBase // Controller for handling user-related API requests
{

  private UserService _userService;  // Dependency injection for the UserService
  /// <summary>
  ///   
  /// </summary>
  /// <param name="userService"></param>
  public UserController(UserService userService) // Constructor injection for the UserService
  {
    _userService = userService;
  }

  [HttpGet]
  /// <summary>
  ///   
  /// </summary>
  /// <returns></returns>
  public ActionResult<List<UserDto>> GetUser() // GET: api/user
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
  public ActionResult<UserDto> GetById(int id) // GET: api/user/{id}
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
  public ActionResult<UserDto> CreateUser([FromBody] CreateUserDto createUserDto) // POST: api/user
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
  public ActionResult UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto) // PUT: api/user/{id}
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


