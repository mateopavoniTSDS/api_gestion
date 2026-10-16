namespace dao_library;
using entity_library;

public class StudentDAO
{
    private readonly AppDbContext context;

    public StudentDAO(AppDbContext context)
    {
        this.context = context;
    }

    public Student CreateStudent(Student student)
    {
        context.Students.Add(student);
        context.SaveChanges();
        return student;
    }

    public Student? GetStudentById(long id)
    {
        return context.Students.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> GetAllStudents()
    {
        return context.Students.ToList();
    }

    public bool UpdateStudent(Student student)
    {
        var existing = GetStudentById(student.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = student.Name;
        existing.Dni = student.Dni;
        existing.File = student.File;
        existing.CourseId = student.CourseId;
        context.SaveChanges();
        return true;
    }

    public bool DeleteStudentById(long id)
    {
        var existing = GetStudentById(id);
        if (existing == null)
        {
            return false;
        }

        context.Students.Remove(existing);
        context.SaveChanges();
        return true;
    }
}
