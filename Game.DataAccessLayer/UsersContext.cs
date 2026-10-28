using Microsoft.EntityFrameworkCore;
namespace Game.DataServiceLayer;
public class UsersContext : DbContext
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
    }
    public DbSet<GameDomain.UserDto> Users { get; set; }
}