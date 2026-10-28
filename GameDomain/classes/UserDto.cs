namespace GameDomain;

public class UserDto
{
  public int Id { get; set; }
  public required string Email { get; set; }
  public  DateTime DateOfBirthday { get; set; }
  public required string Username { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
}