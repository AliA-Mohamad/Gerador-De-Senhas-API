using API.Models;

namespace API.Interfaces;

public interface IJwtService
{
    string GenerateJwtToken(Usuario user);
}
