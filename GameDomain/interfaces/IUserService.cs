using GameDomain;
namespace GameDomain; 

public interface IUserService 
{ /// <summary>
  /// Get all users from the database
  /// </summary>    
    public List <UserDto> GetAllUsers();
    /// <summary>
    /// Get a user by their ID
    /// </summary>
    public UserDto? GetById(int id);
    /// <summary>
    ///     
    /// </summary>
    /// <param name="createUserDto"></param>
    /// <returns></returns>
    public UserDto CreateUser(CreateUserDto createUserDto);
    /// <summary>
    ///     
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateUserDto"></param>
    /// <returns></returns>
    public bool UpdateUser(int id, UpdateUserDto updateUserDto);
    /// <summary>
    ///     
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteUser(int id);
}