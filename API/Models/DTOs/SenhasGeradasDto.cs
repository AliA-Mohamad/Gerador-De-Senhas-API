namespace API.Models.DTOs
{
    public class SenhasGeradasDto
    {
        public int IdUsuario { get; set; }

        public required string Identificador { get; set; }

        public required string Senha { get; set; }
    }
}
