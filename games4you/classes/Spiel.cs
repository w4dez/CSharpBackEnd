
public class Spiel
{
  public int Id { get; set; }

  public int? GenreId { get; set; }
  public Genre? Genre { get; set; }

  public int? PersonId { get; set; }
  public Person? Person { get; set; }


  public string Bezeichnung { get; set; } = string.Empty;

  public long EAN { get; set; }


  public string Zustand { get; set; } = string.Empty;

  public string Status { get; set; } = string.Empty;

  public List<Ausleihe> Ausleihen { get; set; } = new List<Ausleihe>();
}
