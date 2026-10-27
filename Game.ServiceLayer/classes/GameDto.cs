namespace Game.ServiceLayer;

public class GameDto
{
  public int Id { get; set; }

  public required string Title { get; set; }

  public required string Genre { get; set; }
}