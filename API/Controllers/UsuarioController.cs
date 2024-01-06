using API.Data;
using API.Interfaces;
using API.Models;
using API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IPasswordService _passwordService;

    public UsuarioController(ApplicationDbContext context , IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> Registrar([FromBody] UsuarioDto usuarioDto)
    {
        if (_context.Usuarios.Any(u => u.Email == usuarioDto.Email))
        {
            return BadRequest("Usuário já existe.");
        }

        var usuario = new Usuario
        {
            Nome = usuarioDto.Nome,
            Email = usuarioDto.Email,
            Senha = _passwordService.GerarHashSenha(usuarioDto.Senha)
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok("Usuário registrado com sucesso.");
    }
}
