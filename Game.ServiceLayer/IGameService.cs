using Game.ServiceLayer;
namespace Game.ServiceLayer;

interface IGameService
{
  IGameService CreateGame();
  IGameService GetById();
  IGameService UpdateGame();
  bool DeleteGame();
  IGameService SaveGames();
}
