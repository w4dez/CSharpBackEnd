using Microsoft.AspNetCore.Mvc;
using Game.ServiceLayer;
using GameDomain;
namespace WebApplication1.Controllers;


[ApiController]
[Route("api/[controller]")]
/// <summary>
///   
/// </summary>
public class GameController : ControllerBase // Controller for handling game-related API requests
{

  private GameService _gameService; // Dependency injection for the GameService
/// <summary>
///   
/// </summary>
/// <param name="gameService"></param>
  public GameController(GameService gameService) // Constructor injection for the GameService
  {
    DataService dataService = new DataService();
    _gameService = gameService;
  }

  [HttpGet]
  /// <summary>
  ///   
  /// </summary>
  /// <returns></returns>
  public ActionResult<List<GameDto>> GetGames() // GET: api/game
  {
    var games = _gameService.GetAllGames();
    return Ok(games);
  }
  [HttpGet("{id}")]
  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public ActionResult<GameDto> GetById(int id) // GET: api/game/{id}
  {
    var game = _gameService.GetById(id);

    if (game == null) return NotFound();

    return Ok(game);
  }
  [HttpPost]
  /// <summary>
  ///   
  /// </summary>
  /// <param name="createGameDto"></param>
  /// <returns></returns>
  public ActionResult<GameDto> CreateGame([FromBody] CreateGameDto createGameDto) // POST: api/game
  {
    var newGame = _gameService.CreateGame(createGameDto);
    return Created($"/api/game/{newGame.Id}", newGame);
  }

  [HttpPut("{id}")]
  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <param name="updateGameDto"></param>
  /// <returns></returns>
  public ActionResult UpdateGame(int id, [FromBody] UpdateGameDto updateGameDto) // PUT: api/game/{id}
  {
    var success = _gameService.UpdateGame(id, updateGameDto);

    if (!success) return NotFound();

    return NoContent();
  }

  [HttpDelete("{id}")]
  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public IActionResult DeleteGame(int id) // DELETE: api/game/{id}
  {
    var success = _gameService.DeleteGame(id);

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


