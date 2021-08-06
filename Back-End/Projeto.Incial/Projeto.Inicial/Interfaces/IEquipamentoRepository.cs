using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto.inicial.webApi.Interfaces
{
    interface IEquipamentoRepository
    {
        /// <summary>
        /// lista todas os equipamentos
        /// </summary>
        /// <returns> uma lista de equipamentos</returns>
        List<Equipamento> Listar();

        /// <summary>
        /// cadastra um novo equipamento
        /// </summary>
        /// <param name="novoEquipamento"> novoEquipamento será o novo objeto cadastrado </param>
        void Cadastrar(Equipamento novoEquipamento);

        /// <summary>
        /// atualiza um equipamento existente
        /// </summary>
        /// <param name="id"> busca o id do equipamento que terá a atualização </param>
        /// <param name="equipamentoAtualizado"> será o equipamento com a atualização </param>
        void Atualizar(int id, Equipamento equipamentoAtualizado);

        /// <summary>
        /// deleta uma equipamento existente
        /// </summary>
        /// <param name="id"> id do equipamento que sera deletado </param>
        void Deletar(int id);
    }
}
