namespace dao_library;
using entity_library;

public class TeamDAO
{
    public Team CreateTeam(Team team)
    {
        team.Id = MockDatabase.Teams.Count + 1;
        MockDatabase.Teams.Add(team);
        return team;
    }

    public Team? GetTeamById(long id)
    {
        return MockDatabase.Teams.FirstOrDefault(t => t.Id == id);
    }

    public List<Team> GetAllTeams()
    {
        return MockDatabase.Teams;
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
        return true;
    }

    public bool DeleteTeamById(long id)
    {
        var existing = GetTeamById(id);
        if (existing == null)
        {
            return false;
        }

        MockDatabase.Teams.Remove(existing);
        return true;
    }
}
