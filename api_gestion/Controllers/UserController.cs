namespace api_gestion.Controllers;
using Microsoft.AspNetCore.Authorization;
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
    private readonly IDAOUser _userDAO;
    private readonly JwtService _jwtService;

    public UserController(ILogger<UserController> logger, IDAOFactory factory, JwtService jwtService)
    {
        _logger = logger;
        _userDAO = factory.CreateUserDAO();
        _jwtService = jwtService;
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_userDAO.GetAllUsers().Select(ToResponse));
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var user = _userDAO.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(ToResponse(user));
    }

    [HttpPost]
    public ActionResult Create(UserCreateDTO dto)
    {
        var users = _userDAO.GetAllUsers();
        if (users.Any(u => u.Email.ToLower() == dto.Email.ToLower()))
        {
            return BadRequest("Ya existe un usuario con ese email");
        }
        if (users.Any(u => u.Dni == dto.Dni))
        {
            return BadRequest("Ya existe un usuario con ese DNI");
        }

        var user = new User
        {
            Name = dto.Name,
            Dni = dto.Dni,
            Age = dto.Age,
            Email = dto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            RoleType = dto.RoleType
        };
        var created = _userDAO.CreateUser(user);
        return Created($"/user/{created.Id}", ToResponse(created));
    }

    [Authorize]
    [HttpPut("{id}")]
    public ActionResult Update(long id, UserCreateDTO dto)
    {
        var users = _userDAO.GetAllUsers();
        if (users.Any(u => u.Id != id && u.Email.ToLower() == dto.Email.ToLower()))
        {
            return BadRequest("Ya existe un usuario con ese email");
        }
        if (users.Any(u => u.Id != id && u.Dni == dto.Dni))
        {
            return BadRequest("Ya existe un usuario con ese DNI");
        }

        var user = new User
        {
            Id = id,
            Name = dto.Name,
            Dni = dto.Dni,
            Age = dto.Age,
            Email = dto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            RoleType = dto.RoleType
        };
        if (!_userDAO.UpdateUser(user))
        {
            return NotFound();
        }

        return Ok(ToResponse(user));
    }

    [Authorize(Roles = "Admin")]
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

    private static UserResponseDTO ToResponse(User user)
    {
        return new UserResponseDTO
        {
            Id = user.Id,
            Name = user.Name,
            Dni = user.Dni,
            Age = user.Age,
            Email = user.Email,
            RoleType = user.RoleType
        };
    }
}
