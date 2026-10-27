using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
  private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "games_v2.json");

  private List<GameDto> LoadGames()
  {
    if (!System.IO.File.Exists(_filePath))
    {
      return ResetToDefaultGames();
    }

    string json = System.IO.File.ReadAllText(_filePath);
    if (string.IsNullOrWhiteSpace(json))
      return new List<GameDto>();

    try
    {
      return JsonSerializer.Deserialize<List<GameDto>>(json) ?? new List<GameDto>();
    }
    catch (JsonException)
    {
      return ResetToDefaultGames();
    }
  }

  private List<GameDto> ResetToDefaultGames()
  {
    var defaultGames = new List<GameDto>
      {
          new GameDto { Id = 1, Title = "Cs:go", Genre = "Shooter" },
          new GameDto { Id = 2, Title = "The Last of Us Part I", Genre = "Adventure" },
          new GameDto { Id = 3, Title = "GTA 6", Genre = "Open World Adventure" },
          new GameDto { Id = 4, Title = "Dota 2", Genre = "Multiplayer online battle arena" }
      };
    SaveGames(defaultGames);
    return defaultGames;
  }
  private void SaveGames(List<GameDto> games)
  {
    string json = JsonSerializer.Serialize(games, new JsonSerializerOptions { WriteIndented = true });
    System.IO.File.WriteAllText(_filePath, json);
  }
  /*   private static List<GameDto> _games = new List<GameDto>
  {
      new GameDto { Id = 1, Title = "Cs:go", Genre = "Shooter" },
      new GameDto { Id = 2, Title = "The Last of Us Part I", Genre = "Adventure" },
      new GameDto { Id = 3, Title = "GTA 6", Genre = "Open World Adventure" },
      new GameDto { Id = 4, Title = "Dota 2", Genre = "Multiplayer online battle arena" }
  }; */

  [HttpGet("{id}")]
  public ActionResult<GameDto> GetById(int id)
  {
    var games = LoadGames();
    var game = games.FirstOrDefault(g => g.Id == id);

    if (game == null)
    {
      return NotFound();
    }
    else
    {
      return Ok(game);
    }
  }
  [HttpPost]
  public ActionResult<GameDto> CreateGame([FromBody] CreateGameDto createGameDto)
  {
    var games = LoadGames();
    int nextId = 1;
    if (games.Count > 0)
    {
      nextId = games.Max(g => g.Id) + 1;
    }

    var newGame = new GameDto
    {
      Id = nextId,
      Title = createGameDto.Title,
      Genre = createGameDto.Genre
    };

    games.Add(newGame);
    SaveGames(games);
    var gameDto = new GameDto
    {
      Id = newGame.Id,
      Title = newGame.Title,
      Genre = newGame.Genre
    };
    return Created($"/api/game/{newGame.Id}", gameDto);
  }

  [HttpPut("{id}")]
  public ActionResult<GameDto> UpdateGame(int id, [FromBody] CreateGameDto updateGameDto)
  {
    var games = LoadGames();
    var gameToUpdate = games.FirstOrDefault(g => g.Id == id);

    if (gameToUpdate == null)
    {
      return NotFound();
    }

    else
    {
      gameToUpdate?.Title = updateGameDto.Title;
      gameToUpdate?.Genre = updateGameDto.Genre;
      SaveGames(games);
      return Ok(gameToUpdate);
    }


  }
  [HttpDelete("{id}")]
  public IActionResult DeleteGame(int id)
  {
    var games = LoadGames();
    var gameToDelete = games.FirstOrDefault(g => g.Id == id);
    if (gameToDelete == null)
    {
      return NotFound();
    }

    else
    {
      games.Remove(gameToDelete);
      SaveGames(games);
      return NoContent();
    }
  }
  /// <summary>
  /// Retrieves all grades for the logged-in user.
  /// </summary>
  /// <returns>A list of all games in the system.</returns>
  /// <response code="200">Successful retrieval of games.</response>
  /// <response code="401">User is not authenticated.</response>
  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  public async Task<IActionResult> GetGames()
  {
    var games = LoadGames();
    return Ok(games);
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

}
