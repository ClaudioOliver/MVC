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
    }
}