namespace API.Models;

public class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public string Senha { get; set; }

    public virtual ICollection<SenhasGeradas> SenhasGeradas { get; set; }
}
