namespace dao_library;
using entity_library;

public class PlayerDAO
{
    public Player CreatePlayer(Player player)
    {
        player.Id = MockDatabase.Players.Count + 1;
        MockDatabase.Players.Add(player);
        return player;
    }

    public Player? GetPlayerById(long id)
    {
        return MockDatabase.Players.FirstOrDefault(p => p.Id == id);
    }

    public List<Player> GetAllPlayers()
    {
        return MockDatabase.Players;
    }

    public bool UpdatePlayer(Player player)
    {
        var existing = GetPlayerById(player.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = player.Name;
        existing.Dni = player.Dni;
        existing.Numero = player.Numero;
        existing.TeamId = player.TeamId;
        return true;
    }

    public bool DeletePlayerById(long id)
    {
        var existing = GetPlayerById(id);
        if (existing == null)
        {
            return false;
        }

        MockDatabase.Players.Remove(existing);
        return true;
    }
}
