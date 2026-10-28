using GameDomain;
namespace GameDomain;


public interface IGameService // Interface for the GameService
{ /// <summary>
  /// Interface for the GameService, defining the contract for game-related operations.
  /// </summary>  
  public List<GameDto> GetAllGames(); // GET: api/game
  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns> <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public GameDto? GetById(int id); // GET: api/game/{id}
  /// <summary>
  /// 
  /// </summary>
  /// <param name="createGameDto"></param>    
  public GameDto CreateGame(CreateGameDto createGameDto); // POST: api/game
  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <param name="updateGameDto"></param>
  /// <returns></returns>
  public bool UpdateGame(int id, UpdateGameDto updateGameDto); // PUT: api/game/{id}
  /// <summary>
  /// 
  /// </summary>    
  public bool DeleteGame(int id); // DELETE: api/game/{id}
}
