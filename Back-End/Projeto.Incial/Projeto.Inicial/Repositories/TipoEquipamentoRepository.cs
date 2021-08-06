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

        /// <summary>
        /// atualiza as informações de um tipo de equipamento existente
        /// </summary>
        /// <param name="id"> id do tipo de equipamento que será atualizado </param>
        /// <param name="TipoEquipamentoAtualizado"> objeto com a atualização </param>
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

        /// <summary>
        /// cadastra um novo tipo de equipamento e salva no banco
        /// </summary>
        /// <param name="novoTipoEquipamento"> novo objeto cadastrado </param>
        public void Cadastrar(TipoEquipamento novoTipoEquipamento)
        {
            ctx.TipoEquipamentos.Add(novoTipoEquipamento);

            ctx.SaveChanges();
        }

        /// <summary>
        /// deleta um tipo de equipamento existente e salva no banco
        /// </summary>
        /// <param name="id"> id do tipo de equipamento que será deletado </param>
        public void Deletar(int id)
        {
            ctx.TipoEquipamentos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// lista todos os tipos de equipamentos existentes
        /// </summary>
        /// <returns> uma lista de tipos de equipamentos</returns>
        public List<TipoEquipamento> Listar()
        {
            return ctx.TipoEquipamentos.ToList();
        }
    }
}
