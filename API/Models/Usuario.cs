namespace API.Models;

public class Usuario
{
<<<<<<< HEAD
    public int Id { get; set; }

    public required string Nome { get; set; }

    public required string Email { get; set; }

    public required string Senha { get; set; }

    public virtual ICollection<SenhasGeradas> SenhasGeradas { get; set; }
=======
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public List<SenhaGerada> SenhasGeradas { get; set; }
>>>>>>> parent of 6a5e8e5 (é, não da assim)
}
