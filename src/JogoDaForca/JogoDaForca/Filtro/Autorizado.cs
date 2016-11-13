using JogoDaForca.Dominio;
using JogoDaForca.Servicos;
using System.Web;
using System.Web.Mvc;

namespace JogoDaForca.Filtro
{
    public class Autorizador : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Usuario usuario = ServicoDeAutenticacao.UsuarioLogado;

            if (usuario == null) return false;
        
            return true;
        }
    }
}