using API.Data;
using API.Interfaces;
using API.Models;
using API.Models.DTOs.Usuario;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IPasswordService _passwordService;
    private readonly IJwtService _jwtService;

    public UsuarioController(ApplicationDbContext context, IPasswordService passwordService, IJwtService jwtService)
    {
        _db = context;
        _passwordService = passwordService;
        _jwtService = jwtService;
    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> Registrar([FromBody] RegistrarDto registrarDto)
    {
        if (_db.Usuarios.Any(u => u.Email == registrarDto.Email))
        {
            return BadRequest("Usuário já existe.");
        }

        var usuario = new Usuario
        {
            Nome = registrarDto.Nome,
            Email = registrarDto.Email,
            Senha = _passwordService.GerarHashSenha(registrarDto.Senha)
        };

        _db.Usuarios.Add(usuario);
        await _db.SaveChangesAsync();

        return Ok("Usuário registrado com sucesso.");
    }

    [HttpPost("AlterarSenha")]
    public async Task<IActionResult> AlterarSenha([FromBody] AlterarSenhaDto alterarSenhaDto)
    {
        var usuario = _db.Usuarios.FirstOrDefault(u => u.Email == alterarSenhaDto.Email);
        if (usuario == null)
        {
            return NotFound("Usuário não encontrado.");
        }

        if (!_passwordService.VerificarSenha(alterarSenhaDto.SenhaAtual, usuario.Senha))
        {
            return BadRequest("Senha atual incorreta.");
        }

        usuario.Senha = _passwordService.GerarHashSenha(alterarSenhaDto.NovaSenha);
        _db.Usuarios.Update(usuario);
        await _db.SaveChangesAsync();

        return Ok("Senha alterada com sucesso.");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var user = _db.Usuarios.FirstOrDefault(u => u.Email == loginDto.Email);

        if (user == null || !_passwordService.VerificarSenha(loginDto.Senha, user.Senha))
        {
            return Unauthorized("Credenciais inválidas.");
        }

        var token = _jwtService.GenerateJwtToken(user);
        return Ok(new { Token = token });
    }

    [HttpDelete("Deletar/{id}")]
    public async Task<IActionResult> DeletarUsuario(int id)
    {
        var usuario = await _db.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound("Usuário não encontrado.");
        }

        _db.Usuarios.Remove(usuario);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
