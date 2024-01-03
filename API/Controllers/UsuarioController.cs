using Microsoft.AspNetCore.Mvc;
using FirebaseAdmin.Auth;
using API.Models;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : Controller
{
    [HttpPost]
    [Route("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] Usuario request)
    {
        try
        {
            var userRecordArgs = new UserRecordArgs
            {
                DisplayName = request.Nome,
                Email = request.Email,
                Password = request.Senha,
            };

            var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userRecordArgs);
            return Ok(new { UserId = userRecord.Uid });
        }
        catch (Exception ex)
        {
            // Tratar exceções (e.g., usuário já existe, problema de rede)
            return BadRequest(ex.Message);
        }
    }
}
