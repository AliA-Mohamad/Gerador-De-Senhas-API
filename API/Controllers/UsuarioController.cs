using API.Data;
using API.Interfaces;
using API.Models;
using API.Models.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IPasswordService _passwordService;

    public UsuarioController(ApplicationDbContext context, IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> Registrar([FromBody] RegistrarDto registrarDto)
    {
        if (_context.Usuarios.Any(u => u.Email == registrarDto.Email))
        {
            return BadRequest("Usuário já existe.");
        }

        var usuario = new Usuario
        {
            Nome = registrarDto.Nome,
            Email = registrarDto.Email,
            Senha = _passwordService.GerarHashSenha(registrarDto.Senha)
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok("Usuário registrado com sucesso.");
    }

    [HttpPost("AlterarSenha")]
    public async Task<IActionResult> AlterarSenha([FromBody] AlterarSenhaDto alterarSenhaDto)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == alterarSenhaDto.Email);
        if (usuario == null)
        {
            return NotFound("Usuário não encontrado.");
        }

        if (!_passwordService.VerificarSenha(alterarSenhaDto.SenhaAtual, usuario.Senha))
        {
            return BadRequest("Senha atual incorreta.");
        }

        usuario.Senha = _passwordService.GerarHashSenha(alterarSenhaDto.NovaSenha);
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();

        return Ok("Senha alterada com sucesso.");
    }
}
