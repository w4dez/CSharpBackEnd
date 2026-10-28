using Microsoft.EntityFrameworkCore;
namespace Game.DataServiceLayer;
public class GamesContext : DbContext
{
    public GamesContext(DbContextOptions<GamesContext> options) : base(options)
    {
    }
    public DbSet<GameDomain.Game> Games { get; set; }
}