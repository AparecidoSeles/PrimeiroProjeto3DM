using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto.Inicial.Domains
{
    public partial class TipoEquipamento
    {
        public TipoEquipamento()
        {
            Equipamentos = new HashSet<Equipamento>();
        }

        public int IdTipoEquipamento { get; set; }
        public string NomeTipoEquipamento { get; set; }

        public virtual ICollection<Equipamento> Equipamentos { get; set; }
    }
}
