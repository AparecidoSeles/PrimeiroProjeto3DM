using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto.Inicial.Domains
{
    public partial class Sala
    {
        public Sala()
        {
            Equipamentos = new HashSet<Equipamento>();
        }

        public int IdSala { get; set; }
        public int? IdEscola { get; set; }
        public string Nome { get; set; }
        public string Andar { get; set; }
        public decimal Metragem { get; set; }

        public virtual Escola IdEscolaNavigation { get; set; }
        public virtual ICollection<Equipamento> Equipamentos { get; set; }
    }
}
