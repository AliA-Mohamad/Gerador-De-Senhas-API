namespace API.Models;

public class Usuario
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public List<SenhaGerada> SenhasGeradas { get; set; }
}
