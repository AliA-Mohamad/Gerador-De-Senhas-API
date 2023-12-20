using System.Text;

namespace API.Models;

public class SenhaGerada
{
    public string identificador { get; set; }
    public string senha { get; }


    public SenhaGerada()
    {
        senha = GerarSenhaAleatoria();
    }

    private string GerarSenhaAleatoria()
    {
        Random random = new();
        StringBuilder stringBuilder = new(8);

        for (int i = 0; i < 8; i++)
        {
            int tipoCaractere = random.Next(3);

            switch (tipoCaractere)
            {
                case 0:
                    stringBuilder.Append((char)random.Next('0', '9' + 1));
                    break;
                case 1:
                    stringBuilder.Append((char)random.Next('a', 'z' + 1));
                    break;
                case 2:
                    stringBuilder.Append((char)random.Next('A', 'Z' + 1));
                    break;
            }
        }
        return stringBuilder.ToString();
    }
}
