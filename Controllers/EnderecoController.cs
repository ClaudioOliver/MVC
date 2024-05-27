using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                return RedirectToAction(nameof(Index));

            return View(endereco);
        }

        [HttpPost]
        public IActionResult Editar(Endereco endereco)
        {
            _context.Update(endereco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var endereco = _context.Enderecos.Find(Id);
            return View(endereco);
        }

        [HttpPost]
        public IActionResult Delete(Endereco endereco)
        {
            _context.Remove(endereco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ExportarEnderecos()
        {
            // Buscar todos os endereços do banco de dados
            var enderecos = _context.Enderecos.ToList();

            // Verificar se existem endereços para exportar
            if (!enderecos.Any())
            {
                return NotFound("Não há endereços para exportar.");
            }

            // Criar StringBuilder para construir o CSV
            StringBuilder csvData = new StringBuilder();

            // Cabeçalho do CSV (opcional)
            csvData.AppendLine("Id,Logradouro,Bairro,Cidade,Estado,CEP");

            // Converter endereços para linhas CSV
            foreach (var endereco in enderecos)
            {
                csvData.AppendLine($"{endereco.Id},{endereco.Logradouro},{endereco.Bairro},{endereco.Cidade},{endereco.Uf},{endereco.Cep}");
            }

            // Retornar arquivo CSV
            return File(Encoding.UTF8.GetBytes(csvData.ToString()), "text/csv", "enderecos.csv");
        }


    }
}