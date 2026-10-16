namespace dao_library;
using entity_library;

public interface IDAOUser
{
    User CreateUser(User user);
    User? GetUserById(long id);
    List<User> GetAllUsers();
    bool UpdateUser(User user);
    bool DeleteUserById(long id);
}
