namespace Game.DataAccessLayer;
using Game.DataServiceLayer;
using GameDomain;

public class UserRepository : IUserRepository 
{
    private UsersContext _userContext;

    public UserRepository(UsersContext userContext)
    {
        _userContext = userContext;
    }
public List<UserDto> GetAllUsers()
    {
        return _userContext.Users.ToList();
    }
    public List<UserDto> GetById(int id)
    {
        return _userContext.Users.Where(u => u.Id == id).ToList();
    }
    public List<UserDto> CreateUser(UserDto user)
    {
        int NextId = _userContext.Users.Any() ? _userContext.Users.Max(u => u.Id) + 1 : 1;
        var newUser = new UserDto
        {
            Id = NextId,
            Username = user.Username,
            DateOfBirthday = user.DateOfBirthday,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
        _userContext.Users.Add(newUser);
        _userContext.SaveChanges();
        return _userContext.Users.ToList();
    }
    public bool UpdateUser(int id, UserDto user)
    {
        var userToUpdate = _userContext.Users.FirstOrDefault(u => u.Id == id);
        if (userToUpdate == null) return false;

        userToUpdate.Username = user.Username;
        userToUpdate.DateOfBirthday = user.DateOfBirthday;
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.Email = user.Email;
        _userContext.SaveChanges();
        return true;
    }
    public bool DeleteUser(int id)
    {
        var userToDelete = _userContext.Users.FirstOrDefault(u => u.Id == id);
        if (userToDelete == null) return false;

        _userContext.Users.Remove(userToDelete);
        _userContext.SaveChanges();
        return true;
    }
}