using API.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace API.Services;

public class PasswordService : IPasswordService
{
    public string GerarHashSenha(string senha)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            var builder = new StringBuilder();
            foreach (var byteValue in bytes)
            {
                builder.Append(byteValue.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public bool VerificarSenha(string senhaDigitada, string senhaHashArmazenada)
    {
        var hashDaSenhaDigitada = GerarHashSenha(senhaDigitada);
        return hashDaSenhaDigitada == senhaHashArmazenada;
    }
}
