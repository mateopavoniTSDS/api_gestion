namespace entity_library;

public class Student : Person
{
    private string file = "";
    private long courseId = 0;

    public string File
    {
        get { return file; }
        set { file = value; }
    }

    public long CourseId
    {
        get { return courseId; }
        set { courseId = value; }
    }
}
