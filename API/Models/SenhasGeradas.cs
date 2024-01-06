using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class SenhasGeradas
{
    public int Id { get; set; }

    [ForeignKey("Usuario")]
    public int IdUsuario { get; set; }

    public  string Identificador { get; set; }

    public string Senha { get; set; }

}
