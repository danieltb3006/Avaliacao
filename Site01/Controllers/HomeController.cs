using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Site01.Library.Filters;
using Site01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Controllers
{
    
    public class HomeController : Controller //para adicionar o controller (ctrl+'.')
    {
        //método para ação padrão
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login([FromForm] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
               if (usuario.Email == "danieltb3006@gmail.com" && usuario.Senha == "123456")
               {
                    /*
                    HttpContext.Session.SetString("Login", "true");
                    HttpContext.Session.SetInt32("UserID", 32);

                    string login = HttpContext.Session.GetString("Login");
                    */
                    HttpContext.Session.SetString("Login", "true");
                    return RedirectToAction("Index","Palavra");
               }
                else
                {
                    ViewBag.Mensagem = "Os dados informados são inválidos!";
                    return View();
                }
            }
            else
            {
                return View();
            }
            
            
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
