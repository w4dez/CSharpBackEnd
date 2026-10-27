public class Ausleihe
{
  public int Id { get; set; }
  public int PersonId { get; set; }
  public Person? Person { get; set; }
  public int SpielId { get; set; }
  public Spiel? Spiel { get; set; }

  public DateTime AusleiheDatum { get; set; }

  public DateTime RuckAbgabeDatum { get; set; }

  public float Bezahlt { get; set; }
}