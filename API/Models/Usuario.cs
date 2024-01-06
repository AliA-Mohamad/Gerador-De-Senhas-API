namespace API.Models;

public class Usuario
{
    public int Id { get; set; }

    public required string Nome { get; set; }

    public required string Email { get; set; }

    public required string Senha { get; set; }

    public virtual ICollection<SenhasGeradas> SenhasGeradas { get; set; }
}
