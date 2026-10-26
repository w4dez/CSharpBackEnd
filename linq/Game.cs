public class Game
{
  public int Id { get; set; }
  public string? Title { get; set; }
  public Developer? Developer { get; set; }
  public Publisher? Publisher { get; set; }
  public DateTime ReleaseDate { get; set; }
  public List<Review>? Reviews { get; set; }
}