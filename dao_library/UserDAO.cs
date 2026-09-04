namespace dao_library;
using entity_library;

public class UserDAO
{
    private readonly AppDbContext context;

    public UserDAO(AppDbContext context)
    {
        this.context = context;
    }

    public User CreateUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }

    public User? GetUserById(long id)
    {
        return context.Users.FirstOrDefault(u => u.Id == id);
    }

    public List<User> GetAllUsers()
    {
        return context.Users.ToList();
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
        existing.Email = user.Email;
        existing.Password = user.Password;
        existing.RoleType = user.RoleType;
        context.SaveChanges();
        return true;
    }

    public bool DeleteUserById(long id)
    {
        var existing = GetUserById(id);
        if (existing == null)
        {
            return false;
        }

        context.Users.Remove(existing);
        context.SaveChanges();
        return true;
    }
}
