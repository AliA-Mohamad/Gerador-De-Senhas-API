namespace API.Models.DTOs.Usuario;

public class AlterarSenhaDto
{
    public string Email { get; set; }
    public string SenhaAtual { get; set; }
    public string NovaSenha { get; set; }
}