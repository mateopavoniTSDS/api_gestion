namespace dao_library;

public class EFDAOFactory : IDAOFactory
{
    private readonly AppDbContext context;

    public EFDAOFactory(AppDbContext context)
    {
        this.context = context;
    }

    public IDAOUser CreateUserDAO()
    {
        return new EFDAOUser(context);
    }
}
