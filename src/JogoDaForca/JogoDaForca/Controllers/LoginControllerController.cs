using JogoDaForca.Servicos;
using JogoDaForcaDominio;
using System.Web.Mvc;

namespace JogoDaForca.Controllers
{
    public class LoginControllerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entrar(string nome, string senha)
        {
            UsuarioServico usuarioServico = ServicoDeDependencias.MontarUsuarioServico();

            Usuario usuario = usuarioServico.BuscarPorAutenticacao(nome, senha);

            return null;
        }
    }
}
