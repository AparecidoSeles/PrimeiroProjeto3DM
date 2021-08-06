using Projeto.Incial.Interfaces;
using Projeto.Inicial.Contexts;
using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Incial.Repositories
{
    public class TipoEquipamentoRepository : ITipoEquipamentoRepository
    {
        BlogContext ctx = new BlogContext();

        public void Atualizar(int id, TipoEquipamento TipoEquipamentoAtualizado)
        {
            TipoEquipamento tipoEquipamentoBuscado = BuscarPorId(id);

            if (TipoEquipamentoAtualizado.NomeTipoEquipamento != null)
            {
                tipoEquipamentoBuscado.NomeTipoEquipamento = TipoEquipamentoAtualizado.NomeTipoEquipamento;

                ctx.TipoEquipamentos.Update(tipoEquipamentoBuscado);

                ctx.SaveChanges();
            }
        }

        public TipoEquipamento BuscarPorId(int id)
        {
            return ctx.TipoEquipamentos.FirstOrDefault(t => t.IdTipoEquipamento == id);
        }

        public void Cadastrar(TipoEquipamento novoTipoEquipamento)
        {
            ctx.TipoEquipamentos.Add(novoTipoEquipamento);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoEquipamentos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<TipoEquipamento> Listar()
        {
            return ctx.TipoEquipamentos.ToList();
        }
    }
}
