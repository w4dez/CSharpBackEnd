namespace GameDomain;
public class User
{
  public int Id { get; set; }
  public required string Email { get; set; } = string.Empty;
  public  DateTime DateOfBirthday { get; set; }
  public required string Username { get; set; } = string.Empty;
  public required string FirstName { get; set; } = string.Empty;
  public required string LastName { get; set; } = string.Empty;
}