namespace GameDomain; 

public interface IGameRepository
{
    public List<Game> GetAllGames();
    public List<Game> GetById(int id);
    public List<Game> CreateGame(Game game);
    public bool UpdateGame(int id, Game game);
    public bool DeleteGame(int id);

}