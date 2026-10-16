namespace api_gestion.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ILogger<CourseController> _logger;
    private readonly CourseDAO _courseDAO;
    private readonly StudentDAO _studentDAO;

    public CourseController(ILogger<CourseController> logger, CourseDAO courseDAO, StudentDAO studentDAO)
    {
        _logger = logger;
        _courseDAO = courseDAO;
        _studentDAO = studentDAO;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_courseDAO.GetAllCourses());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var course = _courseDAO.GetCourseById(id);
        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpPost]
    public ActionResult Create(Course course)
    {
        var created = _courseDAO.CreateCourse(course);
        return Created($"/course/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(long id, Course course)
    {
        course.Id = id;
        var updated = _courseDAO.UpdateCourse(course);
        if (!updated)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        if (_studentDAO.GetAllStudents().Any(s => s.CourseId == id))
        {
            return BadRequest("El curso tiene estudiantes");
        }

        var deleted = _courseDAO.DeleteCourseById(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
