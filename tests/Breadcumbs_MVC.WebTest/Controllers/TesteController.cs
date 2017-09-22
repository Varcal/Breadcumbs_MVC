using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }


        public ActionResult Editar()
        {
            return View();
        }


        public ActionResult Detalhes()
        {
            return View();
        }
    }
}