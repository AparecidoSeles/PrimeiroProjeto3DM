using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto.inicial.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// validação do usuário
        /// </summary>
        /// <param name="email"> email do usuário </param>
        /// <param name="senha"> senha do usuário </param>
        /// <returns></returns>
        Usuario Login(string email, string senha);
    }
}
