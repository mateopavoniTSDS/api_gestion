using System.ComponentModel.DataAnnotations;

namespace entity_library;

public class Person
{
    private long id = 0;
    private string name = "";
    private string? dni;

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

    [StringLength(20, MinimumLength = 6)]
    public string? Dni
    {
        get { return dni; }
        set { dni = value; }
    }
}
