using Models;

namespace WebApp.Services;

public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(int id);
    User CreateUser(User user);
    bool UpdateUser(int id, User updatedUser);
    bool DeleteUser(int id);
}

public class UserService : IUserService
{
    private readonly List<User> _users = [];

    public IEnumerable<User> GetAllUsers()
    {
        return _users.ToList();
    }

    public User? GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public User CreateUser(User user)
    {
        var nextId = _users.Count == 0 ? 1 : _users.Max(u => u.Id) + 1;
        user.Id = nextId;
        _users.Add(user);
        return user;
    }

    public bool UpdateUser(int id, User updatedUser)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            return false;
        }

        user.Login = updatedUser.Login;
        user.Password = updatedUser.Password;
        return true;
    }

    public bool DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            return false;
        }

        _users.Remove(user);
        return true;
    }
}
