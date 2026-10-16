using entity_library;

namespace api_gestion.Dtos;

public class UserResponseDTO
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string? Dni { get; set; }
    public string Email { get; set; } = "";
    public RoleType RoleType { get; set; }
}
