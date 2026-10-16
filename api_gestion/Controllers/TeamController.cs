namespace api_gestion.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly ILogger<TeamController> _logger;
    private readonly TeamDAO _teamDAO;
    private readonly TrainerDAO _trainerDAO;

    public TeamController(ILogger<TeamController> logger, TeamDAO teamDAO, TrainerDAO trainerDAO)
    {
        _logger = logger;
        _teamDAO = teamDAO;
        _trainerDAO = trainerDAO;
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
        if (_trainerDAO.GetTrainerById(team.TrainerId) == null)
        {
            return BadRequest("El entrenador no existe");
        }

        var created = _teamDAO.CreateTeam(team);
        return Created($"/team/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(long id, Team team)
    {
        if (_trainerDAO.GetTrainerById(team.TrainerId) == null)
        {
            return BadRequest("El entrenador no existe");
        }

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
