namespace Game.DataAccessLayer;

using Game.DataServiceLayer;
using GameDomain;

public class GameRepository : IGameRepository 
{
    private GamesContext _context;

    public GameRepository(GamesContext context)
    {
        _context = context;
    }
public List<Game> GetAllGames()
{
    return _context.Games.ToList();
}
 public List<Game> GetById(int id)
{
    return _context.Games.Where(g => g.Id == id). ToList();
} 
 public List<Game> CreateGame(Game game)
{
    int NextId =_context.Games.Any() ? _context.Games.Max(g => g.Id) + 1 : 1;
    var newGame = new Game
    {
        Id = NextId,
        Title = game.Title,
        Genre = game.Genre
    };
    _context.Games.Add(newGame);
    _context.SaveChanges();
    return _context.Games.ToList();
}     
public bool UpdateGame(int id, Game game)
{
    var gameToUpdate = _context.Games.FirstOrDefault(g => g.Id == id);
    if (gameToUpdate == null) return false;

    gameToUpdate.Title = game.Title;
    gameToUpdate.Genre = game.Genre;
    _context.SaveChanges();
    return true;
}
public bool DeleteGame(int id)
{
    var gameToDelete = _context.Games.FirstOrDefault(g => g.Id == id);
    if (gameToDelete == null) return false;

    _context.Games.Remove(gameToDelete);
    _context.SaveChanges();
    return true;
} 
}