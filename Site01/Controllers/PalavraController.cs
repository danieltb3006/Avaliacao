using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site01.Database;
using Site01.Library.Filters;
using Site01.Models;

namespace Site01.Controllers
{
    [Login]
    public class PalavraController : Controller
    {
        private DatabaseContext _db;
        public PalavraController(DatabaseContext db)
        {
            _db = db;
            
        }
        //Listar todas as palavras do banco de dados
        public IActionResult Index()
        {
            var palavras = _db.Palavras.ToList();
            return View(palavras);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new Palavra());
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Palavra palavra)
        {
            if (ModelState.IsValid) {
                _db.Palavras.Add(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = "A palavra '"+palavra.Nome+"' foi criada com sucesso!";
                return RedirectToAction("Index");
            }
            return View();
        }

        //CRUD: cadastrar, consultar, atualizar e excluir
        [HttpGet]
        public IActionResult Atualizar(int Id)
        {
            Palavra palavra = _db.Palavras.Find(Id);
            return View("Cadastrar", palavra);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Palavra palavra)
        {
            if (ModelState.IsValid)
            {
                _db.Palavras.Update(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = "A palavra '" + palavra.Nome + "' foi atualizada com sucesso!";
                return RedirectToAction("Index");
            }
            return View("Cadastrar",palavra);
        }

        //Palavra/Excluir/39
        //{Controller}/{Action}/{Id?}
        [HttpGet]
        public IActionResult Excluir(int Id)
        {
            Palavra palavra = _db.Palavras.Find(Id);
            _db.Palavras.Remove(_db.Palavras.Find(Id));
            _db.SaveChanges();

            TempData["Mensagem"] = "A palavra '" + palavra.Nome + "' foi excluída com sucesso!";


            return RedirectToAction("Index");
        }
    }
}
