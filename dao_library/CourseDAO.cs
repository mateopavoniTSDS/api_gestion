namespace dao_library;
using entity_library;

public class CourseDAO
{
    private readonly AppDbContext context;

    public CourseDAO(AppDbContext context)
    {
        this.context = context;
    }

    public Course CreateCourse(Course course)
    {
        context.Courses.Add(course);
        context.SaveChanges();
        return course;
    }

    public Course? GetCourseById(long id)
    {
        return context.Courses.FirstOrDefault(c => c.Id == id);
    }

    public List<Course> GetAllCourses()
    {
        return context.Courses.ToList();
    }

    public bool UpdateCourse(Course course)
    {
        var existing = GetCourseById(course.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = course.Name;
        context.SaveChanges();
        return true;
    }

    public bool DeleteCourseById(long id)
    {
        var existing = GetCourseById(id);
        if (existing == null)
        {
            return false;
        }

        context.Courses.Remove(existing);
        context.SaveChanges();
        return true;
    }
}
