namespace api_gestion.Controllers;
using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly ILogger<TeamController> _logger;
    private readonly TeamDAO _teamDAO;

    public TeamController(ILogger<TeamController> logger, TeamDAO teamDAO)
    {
        _logger = logger;
        _teamDAO = teamDAO;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_teamDAO.GetAllTeams());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var team = _teamDAO.GetTeamById(id);
        if (team == null)
        {
            return NotFound();
        }

        return Ok(team);
    }

    [HttpPost]
    public ActionResult Create(Team team)
    {
        var created = _teamDAO.CreateTeam(team);
        return Created($"/team/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(long id, Team team)
    {
        team.Id = id;
        var updated = _teamDAO.UpdateTeam(team);
        if (!updated)
        {
            return NotFound();
        }

        return Ok(team);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var deleted = _teamDAO.DeleteTeamById(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
