using Game.ServiceLayer;
using GameDomain;
namespace Game.ServiceLayer;

interface IUserService
{
  /// <summary>
  ///   
  /// </summary>
  /// <returns></returns>
  public List<UserDto> GetAllUsers(); ///
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
