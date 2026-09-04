namespace entity_library;

public class Player : Person
{
    private int numero = 0;
    private long teamId = 0;

    public int Numero
    {
        get { return numero; }
        set { numero = value; }
    }

    public long TeamId
    {
        get { return teamId; }
        set { teamId = value; }
    }
}
