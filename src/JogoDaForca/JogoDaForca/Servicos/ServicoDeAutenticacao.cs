using JogoDaForca.Dominio;
using System.Web;

namespace JogoDaForca.Servicos
{
    public static class ServicoDeAutenticacao
    {
        private const string USUARIO_LOGADO_CHAVE = "USUARIO_LOGADO_CHAVE";
        public static void Autenticar(Usuario ususario)
        {
            HttpContext.Current.Session[USUARIO_LOGADO_CHAVE] = ususario;
        }

        public static Usuario UsuarioLogado
        {
            get
            {
                return (Usuario)HttpContext.Current.Session[USUARIO_LOGADO_CHAVE];
            }
        }

    }
}