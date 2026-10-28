namespace Game.ServiceLayer;

public class CreateUserDto
{
  public required string Email { get; set; }
  public required DateTime DateOfBirthday { get; set; }

  public required string Username { get; set; }

  public required string FirstName { get; set; }

  public required string LastName { get; set; }

}