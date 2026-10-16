namespace api_gestion.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ActivityController : ControllerBase
{
    private readonly ILogger<ActivityController> _logger;
    private readonly ActivityDAO _activityDAO;

    public ActivityController(ILogger<ActivityController> logger, ActivityDAO activityDAO)
    {
        _logger = logger;
        _activityDAO = activityDAO;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_activityDAO.GetAllActivities());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var activity = _activityDAO.GetActivityById(id);
        if (activity == null)
        {
            return NotFound();
        }

        return Ok(activity);
    }

    [HttpPost]
    public ActionResult Create(Activity activity)
    {
        var created = _activityDAO.CreateActivity(activity);
        return Created($"/activity/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(long id, Activity activity)
    {
        activity.Id = id;
        var updated = _activityDAO.UpdateActivity(activity);
        if (!updated)
        {
            return NotFound();
        }

        return Ok(activity);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var deleted = _activityDAO.DeleteActivityById(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
