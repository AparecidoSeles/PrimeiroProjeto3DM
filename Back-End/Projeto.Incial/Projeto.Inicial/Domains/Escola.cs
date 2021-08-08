using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto.Inicial.Domains
{
    public partial class Escola
    {
        public Escola()
        {
            Salas = new HashSet<Sala>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdEscola { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }

        public virtual ICollection<Sala> Salas { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
