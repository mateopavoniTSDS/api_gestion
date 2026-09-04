namespace dao_library;
using entity_library;

public class CourseDAO
{
    public Course CreateCourse(Course course)
    {
        course.Id = MockDatabase.Courses.Count + 1;
        MockDatabase.Courses.Add(course);
        return course;
    }

    public Course? GetCourseById(long id)
    {
        return MockDatabase.Courses.FirstOrDefault(c => c.Id == id);
    }

    public List<Course> GetAllCourses()
    {
        return MockDatabase.Courses;
    }

    public bool UpdateCourse(Course course)
    {
        var existing = GetCourseById(course.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = course.Name;
        return true;
    }

    public bool DeleteCourseById(long id)
    {
        var existing = GetCourseById(id);
        if (existing == null)
        {
            return false;
        }

        MockDatabase.Courses.Remove(existing);
        return true;
    }
}
