using JogoDaForca.Infraestrutura;
using JogoDaForca.Repositorio;
using JogoDaForcaDominio;
using JogoDaForcaDominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JogoDaForca.Servicos
{
    public class ServicoDeDependencias
    {
        public static UsuarioServico MontarUsuarioServico()
        {
            UsuarioServico usuarioServico =
                new UsuarioServico(
                    new UsuarioRepositorio(),
                    new ServicoDeCriptografia());

            return usuarioServico;
        }

        public static IPalavraRepositorio MontarPalavraRepositorio()
        {
            return new PalavraRepositorio();
        }
    }
}