namespace dao_library;
using entity_library;

public class MockDAOUser : IDAOUser
{
    private readonly List<User> users = new();
    private long nextId = 1;

    public MockDAOUser()
    {
        // usuario de prueba para poder hacer login en modo mock
        CreateUser(new User
        {
            Name = "Admin",
            Dni = "00000000",
            Age = 30,
            Email = "admin@email.com",
            Password = BCrypt.Net.BCrypt.HashPassword("123456"),
            RoleType = RoleType.Admin
        });
    }

    public User CreateUser(User user)
    {
        user.Id = nextId++;
        users.Add(user);
        return user;
    }

    public User? GetUserById(long id)
    {
        return users.FirstOrDefault(u => u.Id == id);
    }

    public List<User> GetAllUsers()
    {
        return users.ToList();
    }

    public bool UpdateUser(User user)
    {
        var existing = GetUserById(user.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = user.Name;
        existing.Dni = user.Dni;
        existing.Age = user.Age;
        existing.Email = user.Email;
        existing.Password = user.Password;
        existing.RoleType = user.RoleType;
        return true;
    }

    public bool DeleteUserById(long id)
    {
        var existing = GetUserById(id);
        if (existing == null)
        {
            return false;
        }

        users.Remove(existing);
        return true;
    }
}
