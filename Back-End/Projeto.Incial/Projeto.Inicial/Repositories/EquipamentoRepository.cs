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

        /// <summary>
        /// atualiza as informações de cada coluna da tabela equipamento
        /// </summary>
        /// <param name="id"> id do equipamento que será atualizado </param>
        /// <param name="equipamentoAtualizado"> objeto com a nova informação </param>
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

        /// <summary>
        /// cadastra um novo equipamento e salva as informações no banco
        /// </summary>
        /// <param name="novoEquipamento"> novo objeto cadastrado </param>
        public void Cadastrar(Equipamento novoEquipamento)
        {
            ctx.Equipamentos.Add(novoEquipamento);

            ctx.SaveChanges();
        }

        /// <summary>
        /// dele um equipamento existente e salva no banco
        /// </summary>
        /// <param name="id"> id do equipamento que será deletado </param>
        public void Deletar(int id)
        {
            ctx.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// lista todos os equipamentos existentes
        /// </summary>
        /// <returns> uma lista de equipamentos </returns>
        public List<Equipamento> Listar()
        {
            return ctx.Equipamentos.ToList();
        }
    }
}
