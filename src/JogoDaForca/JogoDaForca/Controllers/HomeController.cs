using JogoDaForca.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JogoDaForca.Controllers
{
    public class HomeController : Controller
    {
        [Autorizador]
        public ActionResult Index()
        {
            return View();
        }
    }
}
