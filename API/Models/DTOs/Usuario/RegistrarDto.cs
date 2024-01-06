namespace API.Models.DTOs.Usuario;

public class RegistrarDto
{
    public required string Nome { get; set; }

    public required string Email { get; set; }

    public required string Senha { get; set; }
}
