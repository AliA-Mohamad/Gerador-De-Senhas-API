namespace API.Interfaces;

internal interface IPasswordService
{
    string GerarHashSenha(string senha);
    bool VerificarSenha(string senhaDigitada, string senhaHashArmazenada);
}
