namespace dao_library;
using entity_library;

public class TeamDAO
{
    private readonly AppDbContext context;

    public TeamDAO(AppDbContext context)
    {
        this.context = context;
    }

    public Team CreateTeam(Team team)
    {
        context.Teams.Add(team);
        context.SaveChanges();
        return team;
    }

    public Team? GetTeamById(long id)
    {
        return context.Teams.FirstOrDefault(t => t.Id == id);
    }

    public List<Team> GetAllTeams()
    {
        return context.Teams.ToList();
    }

    public bool UpdateTeam(Team team)
    {
        var existing = GetTeamById(team.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = team.Name;
        existing.Category = team.Category;
        existing.TrainerId = team.TrainerId;
        context.SaveChanges();
        return true;
    }

    public bool DeleteTeamById(long id)
    {
        var existing = GetTeamById(id);
        if (existing == null)
        {
            return false;
        }

        context.Teams.Remove(existing);
        context.SaveChanges();
        return true;
    }
}
