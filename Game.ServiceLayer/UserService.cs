using GameDomain;
namespace Game.ServiceLayer;

public class UserService : IUserService
{ 
  private readonly IUserRepository _userRepository;
/// <summary>
/// §
/// </summary>
/// <param name="UserRepository"></param> <summary>
/// 
/// </summary>
/// <param name="UserRepository"></param>
  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  /// <summary>
  ///   
  /// </summary>
  /// <returns></returns>
  public List<UserDto> GetAllUsers()
  {
    return _userRepository.GetAllUsers();
  }

  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public UserDto? GetById(int id)
  {
    var users = _userRepository.GetById(id);
    var user = users.FirstOrDefault(u => u.Id == id);
    
    if (user == null) return null;

    return new UserDto
    {
      Id = user.Id,
      Username = user.Username,
      DateOfBirthday = user.DateOfBirthday,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Email = user.Email
    };
  }

  /// <summary>
  ///   
  /// </summary>
  /// <summary>
  ///   
  /// </summary>
  /// <param name="createUserDto"></param>
  /// <returns></returns>
  public UserDto CreateUser(CreateUserDto createUserDto)
  { 
    var newUser = new GameDomain.UserDto
    {
      Username = createUserDto.Username,
      DateOfBirthday = createUserDto.DateOfBirthday,
      FirstName = createUserDto.FirstName,
      LastName = createUserDto.LastName,
      Email = createUserDto.Email
    };

    var updatedList = _userRepository.CreateUser(newUser);

    var createdUser = updatedList.Last(); 

    return new UserDto
    {
      Id = createdUser.Id,
      Username = createdUser.Username,
      DateOfBirthday = createdUser.DateOfBirthday,
      FirstName = createdUser.FirstName,
      LastName = createdUser.LastName,
      Email = createdUser.Email
    };
  }

  /// <summary>
  ///   
  /// </summary>
  /// <param name="id"></param>
  /// <param name="updateUserDto"></param>
  /// <returns></returns>
  public bool UpdateUser(int id, UpdateUserDto updateUserDto)
  {
    var userToUpdate = new GameDomain.UserDto
    {
      Id = id,    
      Username = updateUserDto.Username,
      FirstName = updateUserDto.FirstName,
      LastName = updateUserDto.LastName,
      Email = updateUserDto.Email
    };

    return _userRepository.UpdateUser(id, userToUpdate);
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public bool DeleteUser(int id)
  {
    return _userRepository.DeleteUser(id);
  }
}