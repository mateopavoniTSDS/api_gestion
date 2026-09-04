namespace api_gestion.Controllers;
using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;
    private readonly PlayerDAO _playerDAO;

    public PlayerController(ILogger<PlayerController> logger, PlayerDAO playerDAO)
    {
        _logger = logger;
        _playerDAO = playerDAO;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_playerDAO.GetAllPlayers());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var player = _playerDAO.GetPlayerById(id);
        if (player == null)
        {
            return NotFound();
        }

        return Ok(player);
    }

    [HttpPost]
    public ActionResult Create(Player player)
    {
        var created = _playerDAO.CreatePlayer(player);
        return Created($"/player/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(long id, Player player)
    {
        player.Id = id;
        var updated = _playerDAO.UpdatePlayer(player);
        if (!updated)
        {
            return NotFound();
        }

        return Ok(player);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var deleted = _playerDAO.DeletePlayerById(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
