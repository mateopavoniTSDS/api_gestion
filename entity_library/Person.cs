using System.ComponentModel.DataAnnotations;

namespace entity_library;

public abstract class Person
{
    private long id = 0;
    private string name = "";
    private string? dni;
    private int age = 0;

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

    [Range(1, 120)]
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}
