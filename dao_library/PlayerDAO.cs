namespace dao_library;
using entity_library;

public class PlayerDAO
{
    private readonly AppDbContext context;

    public PlayerDAO(AppDbContext context)
    {
        this.context = context;
    }

    public Player CreatePlayer(Player player)
    {
        context.Players.Add(player);
        context.SaveChanges();
        return player;
    }

    public Player? GetPlayerById(long id)
    {
        return context.Players.FirstOrDefault(p => p.Id == id);
    }

    public List<Player> GetAllPlayers()
    {
        return context.Players.ToList();
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
        existing.Age = player.Age;
        existing.Numero = player.Numero;
        existing.TeamId = player.TeamId;
        context.SaveChanges();
        return true;
    }

    public bool DeletePlayerById(long id)
    {
        var existing = GetPlayerById(id);
        if (existing == null)
        {
            return false;
        }

        context.Players.Remove(existing);
        context.SaveChanges();
        return true;
    }
}
