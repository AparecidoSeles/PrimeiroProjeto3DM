using projeto.inicial.webApi.Interfaces;
using Projeto.Inicial.Contexts;
using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Incial.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository
    {

        BlogContext ctx = new BlogContext();

        public void Atualizar(int id, Equipamento equipamentoAtualizado)
        {
            Equipamento equipamentoBuscado = BuscarPorId(id);

            if (equipamentoAtualizado.Marca != null)
            {
                equipamentoBuscado.Marca = equipamentoAtualizado.Marca;

                ctx.Equipamentos.Update(equipamentoBuscado);

                ctx.SaveChanges();
            }

            if (equipamentoAtualizado.Nome != null)
            {
                equipamentoBuscado.Nome = equipamentoAtualizado.Nome;

                ctx.Update(equipamentoBuscado);

                ctx.SaveChanges();
            }

            if (equipamentoAtualizado.NumeroPatrimonio != null)
            {
                equipamentoBuscado.NumeroPatrimonio = equipamentoAtualizado.NumeroPatrimonio;

                ctx.Update(equipamentoBuscado);

                ctx.SaveChanges();
            }

            if (equipamentoAtualizado.NumeroSerie != null)
            {
                equipamentoBuscado.NumeroSerie = equipamentoAtualizado.NumeroSerie;
             
                ctx.Update(equipamentoBuscado);
                
                ctx.SaveChanges();
            }

            if (equipamentoAtualizado.Situacao != null)
            {
                equipamentoBuscado.Situacao = equipamentoAtualizado.Situacao;

                ctx.Update(equipamentoBuscado);

                ctx.SaveChanges();
            }

            if (equipamentoAtualizado.IdTipoEquipamento != null)
            {
                equipamentoBuscado.IdTipoEquipamento = equipamentoAtualizado.IdTipoEquipamento;

                ctx.Update(equipamentoBuscado);

                ctx.SaveChanges();
            }
        }

        public Equipamento BuscarPorId(int id)
        {
            return ctx.Equipamentos.FirstOrDefault(e => e.IdEquipamento == id);
        }

        public void Cadastrar(Equipamento novoEquipamento)
        {
            ctx.Equipamentos.Add(novoEquipamento);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Equipamento> Listar()
        {
            return ctx.Equipamentos.ToList();
        }
    }
}
