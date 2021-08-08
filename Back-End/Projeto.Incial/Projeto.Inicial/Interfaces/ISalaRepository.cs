using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto.inicial.webApi.Interfaces
{
    interface ISalaRepository
    {
        /// <summary>
        /// lista todas as salas
        /// </summary>
        /// <returns> uma lista de salas</returns>
        List<Sala> Listar();

        /// <summary>
        /// cadastra uma nova sala
        /// </summary>
        /// <param name="novaSala"> novaSala será o novo objeto cadastrado </param>
        void Cadastrar(Sala novaSala);

        /// <summary>
        /// atualiza uma sala existente
        /// </summary>
        /// <param name="id"> busca o id da sala que terá a atualização </param>
        /// <param name="salaAtualizada"> será a sala com a atualização </param>
        void Atualizar(int id, Sala SalaAtualizada);

        /// <summary>
        /// deleta uma sala existente
        /// </summary>
        /// <param name="id"> id da sala que sera deletada </param>
        void Deletar(int id);

        /// <summary>
        /// Busca uma sala pelo id
        /// </summary>
        /// <param name="id"> id da sala que sera buscada </param>
        /// <returns> uma sala </returns>
        Sala BuscarPorId(int id);
    }
}
