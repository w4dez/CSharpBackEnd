

public class Ort
{

  public int Id { get; set; }


  public int PLZ { get; set; }

  public string Bezeichnung { get; set; } = string.Empty;

  public List<Person> Personen { get; set; } = new List<Person>();
}
