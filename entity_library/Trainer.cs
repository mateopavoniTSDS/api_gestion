namespace entity_library;

public class Trainer : Person
{
    private List<Team> teams = new();

    public List<Team> Teams
    {
        get { return teams; }
        set { teams = value; }
    }
}
