namespace dao_library;

public class MockDAOFactory : IDAOFactory
{
    // siempre el mismo DAO para que la lista persista entre requests
    private readonly MockDAOUser userDAO = new();

    public IDAOUser CreateUserDAO()
    {
        return userDAO;
    }
}
