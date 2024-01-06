using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : Controller
{
    private readonly IPasswordService _passwordService;
    UsuarioController(IPasswordService passwordService)
    {
        _passwordService = passwordService;
    }

}
