using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using JogoDaForca.Dominio;
using JogoDaForca.Dominio.Interfaces;
using JogoDaForca.Servicos;

namespace JogoDaForca.Controllers
{
    public class UsuariosController : ApiController
    {
        private IUsuarioRepositorio usuarioRepositorio = ServicoDeDependencias.MontarUsuarioRepositorio();

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(string nome)
        {
            Usuario usuario = usuarioRepositorio.BuscarPorNome(nome);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuarioRepositorio.Adicionar(usuario);

            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }
    }
}