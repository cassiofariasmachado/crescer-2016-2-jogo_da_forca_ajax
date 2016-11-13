using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Interfaces;

namespace JogoDaForca.Dominio
{
    public class UsuarioServico
    {
        private IUsuarioRepositorio usuarioRepositorio;
        private IServicoDeCriptografia servicoCriptografia;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio, IServicoDeCriptografia servicoCriptografia)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.servicoCriptografia = servicoCriptografia;
        }

        public Usuario BuscarPorAutenticacao(string nome, string senha)
        {
            Usuario usuarioEncontrado = this.usuarioRepositorio.BuscarPorNome(nome);

            string senhaCriptografada = this.servicoCriptografia.Criptografar(senha);

            if (usuarioEncontrado != null && usuarioEncontrado.Senha.Equals(senhaCriptografada))
            {
                return usuarioEncontrado;
            }

            return null;
        }
    }
}
