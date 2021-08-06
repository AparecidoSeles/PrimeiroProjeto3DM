using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Incial.Interfaces
{
    interface ITipoEquipamento
    {
        /// <summary>
        /// lista todos os tipos de equipamentos existentes
        /// </summary>
        /// <returns></returns>
        List<TipoEquipamento> Listar();

        /// <summary>
        /// cadastra um novo tipo de equipamento
        /// </summary>
        /// <param name="novoTipoEquipamento"> será o novo objeto cadastrado </param>
        void Cadastrar(TipoEquipamento novoTipoEquipamento);

        /// <summary>
        /// atualiza um tipo de equipamento existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TipoEquipamentoAtualizado"> será o objeto com a nova informação </param>
        void Atualizar(int id, TipoEquipamento TipoEquipamentoAtualizado);

        /// <summary>
        /// deleta um tipo de equipamento existente
        /// </summary>
        /// <param name="id"> id do tipo de equipamento que será deletado </param>
        void Deletar(int id);

    }
}
