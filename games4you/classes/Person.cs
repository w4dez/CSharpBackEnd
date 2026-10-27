public class Person
{

  public int Id { get; set; }

  public int? OrtId { get; set; }
  public Ort? Ort { get; set; }

  public string Name { get; set; } = string.Empty;

  public string Vorname { get; set; } = string.Empty;


  public string Adresse { get; set; } = string.Empty;

  public DateTime Geburtsdatum { get; set; }

  public List<Spiel> Spiele { get; set; } = new List<Spiel>();
  public List<Ausleihe> Ausleihen { get; set; } = new List<Ausleihe>();
}
