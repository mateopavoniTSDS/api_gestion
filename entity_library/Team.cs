using System.ComponentModel.DataAnnotations;

namespace entity_library;

public class Team
{
    private long id = 0;
    private string name = "";
    private string category = "";
    private long trainerId = 0;
    private Trainer? trainer;
    private List<Player> players = new();

    public long Id
    {
        get { return id; }
        set { id = value; }
    }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Category
    {
        get { return category; }
        set { category = value; }
    }

    [Range(1, long.MaxValue)]
    public long TrainerId
    {
        get { return trainerId; }
        set { trainerId = value; }
    }

    public Trainer? Trainer
    {
        get { return trainer; }
        set { trainer = value; }
    }

    public List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }
}
