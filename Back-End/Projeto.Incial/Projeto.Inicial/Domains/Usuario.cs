using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Projeto.Inicial.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdEscola { get; set; }

        // define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o nome do usuário!")]
        public string Nome { get; set; }

        // define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string Email { get; set; }

        // define que o campo é obrigatório
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        //define a quantidade máxima e mínima de caracteres 
        [StringLength(100, MinimumLength = 5, ErrorMessage = "A senha deve conter no mínimo 5 caracteres!")]
        public string Senha { get; set; }


        public virtual Escola IdEscolaNavigation { get; set; }
    }
}
