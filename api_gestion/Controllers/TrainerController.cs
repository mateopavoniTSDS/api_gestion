namespace api_gestion.Controllers;
using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;

[ApiController]
[Route("[controller]")]
public class TrainerController : ControllerBase
{
    private readonly ILogger<TrainerController> _logger;
    private readonly TrainerDAO _trainerDAO;

    public TrainerController(ILogger<TrainerController> logger, TrainerDAO trainerDAO)
    {
        _logger = logger;
        _trainerDAO = trainerDAO;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_trainerDAO.GetAllTrainers());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var trainer = _trainerDAO.GetTrainerById(id);
        if (trainer == null)
        {
            return NotFound();
        }

        return Ok(trainer);
    }

    [HttpPost]
    public ActionResult Create(Trainer trainer)
    {
        var created = _trainerDAO.CreateTrainer(trainer);
        return Created($"/trainer/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(long id, Trainer trainer)
    {
        trainer.Id = id;
        var updated = _trainerDAO.UpdateTrainer(trainer);
        if (!updated)
        {
            return NotFound();
        }

        return Ok(trainer);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var deleted = _trainerDAO.DeleteTrainerById(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
