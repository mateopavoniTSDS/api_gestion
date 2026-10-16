using System.ComponentModel.DataAnnotations;
using entity_library;

namespace api_gestion.Dtos;

public class UserCreateDTO
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = "";

    [Required]
    [StringLength(20, MinimumLength = 6)]
    public string Dni { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = "";

    public RoleType RoleType { get; set; } = RoleType.User;
}
