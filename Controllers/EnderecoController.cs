using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoContext _context;
        public EnderecoController(EnderecoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Enderecos = _context.Enderecos.ToList();
            return View(Enderecos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        public IActionResult Editar(int Id)
        {
            var endereco = _context.Enderecos.Find(Id);

            if (endereco == null)
                return NotFound();


            return View(endereco);
        }
    }
}