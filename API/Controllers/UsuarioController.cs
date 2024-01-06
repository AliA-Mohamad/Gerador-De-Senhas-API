<<<<<<< HEAD
﻿using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;

=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> parent of 6a5e8e5 (é, não da assim)

namespace API.Controllers
{
<<<<<<< HEAD
    private readonly IPasswordService _passwordService;
    UsuarioController(IPasswordService passwordService)
    {
        _passwordService = passwordService;
=======
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
>>>>>>> parent of 6a5e8e5 (é, não da assim)
    }

}
