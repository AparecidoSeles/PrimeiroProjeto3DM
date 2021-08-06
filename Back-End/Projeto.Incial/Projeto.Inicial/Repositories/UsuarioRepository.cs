using projeto.inicial.webApi.Interfaces;
using Projeto.Inicial.Contexts;
using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Incial.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        BlogContext ctx = new BlogContext();

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
