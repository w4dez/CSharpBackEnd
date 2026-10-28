using GameDomain;
namespace GameDomain; 

public interface IUserRepository
{
    public List<UserDto> GetAllUsers();
    public List<UserDto>  GetById(int id);
    public List<UserDto>  CreateUser(UserDto user);
    public bool UpdateUser(int id, UserDto user);
    public bool DeleteUser(int id);
}
 
