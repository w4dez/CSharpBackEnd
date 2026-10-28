using Game.ServiceLayer;
namespace Game.ServiceLayer;

using System.Text.Json;
using GameDomain;

/// <summary>
///   
/// </summary>
public class UserService
{
  private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "users.json");
  private List<UserDto> LoadUsers()
  {
    if (!System.IO.File.Exists(_filePath))
    {
      return ResetToDefaultUsers();
    }

    string json = System.IO.File.ReadAllText(_filePath);
    if (string.IsNullOrWhiteSpace(json))
      return new List<UserDto>();

    try
    {
      return JsonSerializer.Deserialize<List<UserDto>>(json) ?? new List<UserDto>();
    }
    catch (JsonException)
    {
      return ResetToDefaultUsers();
    }
  }

  private List<UserDto> ResetToDefaultUsers()
  {
    var defaultUsers = new List<UserDto>
    {
        new UserDto { Id = 1, Email = "test1@gmail.com", DateOfBirthday = new DateTime(2001, 1, 1), Username = "Test1", FirstName = "FirstNameTest1", LastName = "LastNameTest1" },
        new UserDto { Id = 2, Email = "test2@gmail.com", DateOfBirthday = new DateTime(2002, 2, 2), Username = "Test2", FirstName = "FirstNameTest2", LastName = "LastNameTest2" },
        new UserDto { Id = 3, Email = "test3@gmail.com", DateOfBirthday = new DateTime(2003, 3, 3), Username = "Test3", FirstName = "FirstNameTest3", LastName = "LastNameTest3" },
    };
    SaveUsers(defaultUsers);
    return defaultUsers;
  }

  private void SaveUsers(List<UserDto> users)
  {
    string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
    System.IO.File.WriteAllText(_filePath, json);
  }
  /// <summary>
  ///   
  /// </summary>
  /// <returns></returns>
  public List<UserDto> GetAllUsers()
  {
    return LoadUsers();
  }
/// <summary>
///   
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
  public UserDto? GetById(int id)
  {
    var users = LoadUsers();
    return users.FirstOrDefault(u => u.Id == id);
  }
/// <summary>
///   
/// </summary>
/// <param name="createUserDto"></param>
/// <returns></returns>
  public UserDto CreateUser(CreateUserDto createUserDto)
  {
    var users = LoadUsers();
    int nextId = users.Any() ? users.Max(u => u.Id) + 1 : 1;

    var newUser = new UserDto
    {
      Id = nextId,
      Email = createUserDto.Email,
      DateOfBirthday = createUserDto.DateOfBirthday,
      Username = createUserDto.Username,
      FirstName = createUserDto.FirstName,
      LastName = createUserDto.LastName,
    };

    users.Add(newUser);
    SaveUsers(users);

    return newUser;
  }
/// <summary>
///   
/// </summary>
/// <param name="id"></param>
/// <param name="updateUserDto"></param>
/// <returns></returns>
  public bool UpdateUser(int id, UpdateUserDto updateUserDto)
  {
    var users = LoadUsers();
    var userToUpdate = users.FirstOrDefault(u => u.Id == id);

    if (userToUpdate == null) return false;
    userToUpdate.Username = updateUserDto.Username;
    userToUpdate.Email = updateUserDto.Email;
    userToUpdate.FirstName = updateUserDto.FirstName;
    userToUpdate.LastName = updateUserDto.LastName;

    SaveUsers(users);

    return true;
  }
  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>

  public bool DeleteUser(int id)
  {
    var users = LoadUsers();
    var userToDelete = users.FirstOrDefault(u => u.Id == id);

    if (userToDelete == null) return false;

    users.Remove(userToDelete);
    SaveUsers(users);

    return true;
  }
}