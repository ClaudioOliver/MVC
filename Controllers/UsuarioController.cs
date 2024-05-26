using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly EnderecoContext _context;

        public UsuarioController(EnderecoContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Name == model.Username && u.Senha == model.Password);

                if (user != null)
                {
                    // Lógica de autenticação
                    //HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return RedirectToAction("Index", "Endereco");
                }
                ViewBag.ErrorMessage = "Usuário ou senha inválidos.";
            }
            return View(model);
        }

        // GET: Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario
                {
                    Name = model.Nome,
                    Login = model.Username,
                    Senha = model.Password
                };

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // POST: Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }



}