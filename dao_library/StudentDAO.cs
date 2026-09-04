namespace dao_library;
using entity_library;

public class StudentDAO
{
    public Student CreateStudent(Student student)
    {
        student.Id = MockDatabase.Students.Count + 1;
        MockDatabase.Students.Add(student);
        return student;
    }

    public Student? GetStudentById(long id)
    {
        return MockDatabase.Students.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> GetAllStudents()
    {
        return MockDatabase.Students;
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
        return true;
    }

    public bool DeleteStudentById(long id)
    {
        var existing = GetStudentById(id);
        if (existing == null)
        {
            return false;
        }

        MockDatabase.Students.Remove(existing);
        return true;
    }
}
