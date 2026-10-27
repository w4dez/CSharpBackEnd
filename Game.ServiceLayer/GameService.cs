using System.Text.Json;
using Game.ServiceLayer;
namespace Game.ServiceLayer;


public class GameService
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


  public List<GameDto> GetAllGames()
  {
    return LoadGames();
  }

  public GameDto? GetById(int id)
  {
    var games = LoadGames();
    return games.FirstOrDefault(g => g.Id == id);
  }

  public GameDto CreateGame(CreateGameDto createGameDto)
  {
    var games = LoadGames();
    int nextId = games.Any() ? games.Max(g => g.Id) + 1 : 1;

    var newGame = new GameDto
    {
      Id = nextId,
      Title = createGameDto.Title,
      Genre = createGameDto.Genre
    };

    games.Add(newGame);
    SaveGames(games);

    return newGame;
  }

  public bool UpdateGame(int id, CreateGameDto updateGameDto)
  {
    var games = LoadGames();
    var gameToUpdate = games.FirstOrDefault(g => g.Id == id);

    if (gameToUpdate == null) return false;

    gameToUpdate.Title = updateGameDto.Title;
    gameToUpdate.Genre = updateGameDto.Genre;
    SaveGames(games);

    return true;
  }

  public bool DeleteGame(int id)
  {
    var games = LoadGames();
    var gameToDelete = games.FirstOrDefault(g => g.Id == id);

    if (gameToDelete == null) return false;

    games.Remove(gameToDelete);
    SaveGames(games);

    return true;
  }
}