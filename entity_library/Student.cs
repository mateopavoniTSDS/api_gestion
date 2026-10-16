using System.ComponentModel.DataAnnotations;

namespace entity_library;

public class Student : Person
{
    private string file = "";
    private long courseId = 0;
    private Course? course;

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string File
    {
        get { return file; }
        set { file = value; }
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
