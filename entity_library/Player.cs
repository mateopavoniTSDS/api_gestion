using System.ComponentModel.DataAnnotations;

namespace entity_library;

public class Player : Person
{
    private int numero = 0;
    private long teamId = 0;
    private Team? team;

    [Range(1, 99)]
    public int Numero
    {
        get { return numero; }
        set { numero = value; }
    }

    [Range(1, long.MaxValue)]
    public long TeamId
    {
        get { return teamId; }
        set { teamId = value; }
    }

    public Team? Team
    {
        get { return team; }
        set { team = value; }
    }
}
