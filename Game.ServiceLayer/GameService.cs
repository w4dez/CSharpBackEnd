using GameDomain;
namespace Game.ServiceLayer;

public class GameService : IGameService
{ 
  private readonly IGameRepository _gameRepository;
/// <summary>
/// §
/// </summary>
/// <param name="gameRepository"></param> <summary>
/// 
/// </summary>
/// <param name="gameRepository"></param>
  public GameService(IGameRepository gameRepository)
  {
    _gameRepository = gameRepository;
  }

  /// <summary>
  ///   
  /// </summary>
  /// <returns></returns>
  public List<GameDto> GetAllGames()
  {
    var games = _gameRepository.GetAllGames();
    
    return games.Select(g => new GameDto
    {
      Id = g.Id,
      Title = g.Title,
      Genre = g.Genre
    }).ToList();
  }

  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public GameDto? GetById(int id)
  {
    var games = _gameRepository.GetById(id);
    var game = games.FirstOrDefault(g => g.Id == id);
    
    if (game == null) return null;

    return new GameDto
    {
      Id = game.Id,
      Title = game.Title,
      Genre = game.Genre
    };
  }

  /// <summary>
  ///   
  /// </summary>
  /// <param name="createGameDto"></param>
  /// <returns></returns>
  public GameDto CreateGame(CreateGameDto createGameDto)
  { 
    var newGame = new GameDomain.Game
    {
      Title = createGameDto.Title,
      Genre = createGameDto.Genre
    };

    var updatedList = _gameRepository.CreateGame(newGame);

    var createdGame = updatedList.Last(); 

    return new GameDto
    {
      Id = createdGame.Id,
      Title = createdGame.Title,
      Genre = createdGame.Genre
    };
  }

  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <param name="updateGameDto"></param>
  /// <returns></returns>
  public bool UpdateGame(int id, UpdateGameDto updateGameDto)
  {
    var gameToUpdate = new GameDomain.Game
    {
      Id = id,
      Title = updateGameDto.Title,
      Genre = updateGameDto.Genre
    };

    return _gameRepository.UpdateGame(id, gameToUpdate);
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public bool DeleteGame(int id)
  {
    return _gameRepository.DeleteGame(id);
  }
}