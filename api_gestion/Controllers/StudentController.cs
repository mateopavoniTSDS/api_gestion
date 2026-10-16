namespace api_gestion.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

[Authorize]
[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly StudentDAO _studentDAO;

    public StudentController(ILogger<StudentController> logger, StudentDAO studentDAO)
    {
        _logger = logger;
        _studentDAO = studentDAO;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_studentDAO.GetAllStudents());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var student = _studentDAO.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
        var created = _studentDAO.CreateStudent(student);
        return Created($"/student/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(long id, Student student)
    {
        student.Id = id;
        var updated = _studentDAO.UpdateStudent(student);
        if (!updated)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var deleted = _studentDAO.DeleteStudentById(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
