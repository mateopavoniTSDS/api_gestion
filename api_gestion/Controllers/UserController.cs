namespace api_gestion.Controllers;
using Microsoft.AspNetCore.Mvc;
using entity_library;
using dao_library;
using api_gestion.Dtos;
using api_gestion.Services;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserDAO _userDAO;
    private readonly JwtService _jwtService;

    public UserController(ILogger<UserController> logger, UserDAO userDAO, JwtService jwtService)
    {
        _logger = logger;
        _userDAO = userDAO;
        _jwtService = jwtService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_userDAO.GetAllUsers());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var user = _userDAO.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
        if (_userDAO.GetAllUsers().Any(u => u.Email.ToLower() == user.Email.ToLower()))
        {
            return BadRequest("Ya existe un usuario con ese email");
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        var created = _userDAO.CreateUser(user);
        return Created($"/user/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(long id, User user)
    {
        if (_userDAO.GetAllUsers().Any(u => u.Id != id && u.Email.ToLower() == user.Email.ToLower()))
        {
            return BadRequest("Ya existe un usuario con ese email");
        }

        user.Id = id;
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        var updated = _userDAO.UpdateUser(user);
        if (!updated)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var deleted = _userDAO.DeleteUserById(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost("login")]
    public ActionResult Login(LoginDTO login)
    {
        var user = _userDAO.GetAllUsers()
            .FirstOrDefault(u => u.Email.ToLower() == login.Email.ToLower());

        if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
        {
            return Unauthorized("Credenciales inválidas");
        }

        var token = _jwtService.GenerateToken(user);
        return Ok(new { token });
    }
}
