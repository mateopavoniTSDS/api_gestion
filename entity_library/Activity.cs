using System.ComponentModel.DataAnnotations;

namespace entity_library;

public class Activity
{
    private long id = 0;
    private string title = "";
    private string description = "";
    private DateTime date = DateTime.Now;
    private TypeActivity type = TypeActivity.Clase;
    private long courseId = 0;
    private Course? course;

    public long Id
    {
        get { return id; }
        set { id = value; }
    }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    [Required]
    [StringLength(500, MinimumLength = 2)]
    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    [Required]
    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    [Required]
    public TypeActivity Type
    {
        get { return type; }
        set { type = value; }
    }

    [Range(1, long.MaxValue)]
    public long CourseId
    {
        get { return courseId; }
        set { courseId = value; }
    }

    public Course? Course
    {
        get { return course; }
        set { course = value; }
    }
}
