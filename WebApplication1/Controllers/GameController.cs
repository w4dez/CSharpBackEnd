using Microsoft.AspNetCore.Mvc;
using Game.ServiceLayer;
namespace WebApplication1.Controllers;


[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{

  private readonly GameService _gameService;

  public GameController()
  {
    _gameService = new GameService();
  }

  [HttpGet]
  public ActionResult<List<GameDto>> GetGames()
  {
    var games = _gameService.GetAllGames();
    return Ok(games);
  }
  [HttpGet("{id}")]
  public ActionResult<GameDto> GetById(int id)
  {
    var game = _gameService.GetById(id);

    if (game == null) return NotFound();

    return Ok(game);
  }
  [HttpPost]
  public ActionResult<GameDto> CreateGame([FromBody] CreateGameDto createGameDto)
  {
    var newGame = _gameService.CreateGame(createGameDto);
    return Created($"/api/game/{newGame.Id}", newGame);
  }

  [HttpPut("{id}")]
  public ActionResult UpdateGame(int id, [FromBody] CreateGameDto updateGameDto)
  {
    var success = _gameService.UpdateGame(id, updateGameDto);

    if (!success) return NotFound();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteGame(int id)
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


