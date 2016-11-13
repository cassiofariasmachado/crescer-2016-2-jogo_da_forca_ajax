using JogoDaForca.Dominio;
using JogoDaForca.Servicos;
using System.Web.Mvc;

namespace JogoDaForca.Controllers
{
    public class LoginController : Controller
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

            if (usuario == null)
            {
                ViewBag.MessagemErroLogin = "Senha ou Nome está errado!";
                return View("Index");
            }

            Usuario usuarioLogado = new Usuario();
            ServicoDeAutenticacao.Autenticar(usuarioLogado);

            return RedirectToAction("Index","Home");
        }
    }
}
