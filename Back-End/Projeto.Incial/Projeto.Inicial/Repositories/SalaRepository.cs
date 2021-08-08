using projeto.inicial.webApi.Interfaces;
using Projeto.Inicial.Contexts;
using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Incial.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        BlogContext ctx = new BlogContext();

        /// <summary>
        /// atualiza as informações de cada coluna da tabela Sala
        /// </summary>
        /// <param name="id"> id da sala que terá a atualização</param>
        /// <param name="SalaAtualizada"> novo objeto atualizado </param>
        public void Atualizar(int id, Sala SalaAtualizada)
        {
            Sala salaBuscada = BuscarPorId(id);

            if (SalaAtualizada.Andar != null)
            {
                salaBuscada.Andar = SalaAtualizada.Andar;

                ctx.Salas.Update(salaBuscada);

                ctx.SaveChanges();
            }

            if (SalaAtualizada.Metragem != 0)
            {
                salaBuscada.Metragem = SalaAtualizada.Metragem;

                ctx.Salas.Update(salaBuscada);

                ctx.SaveChanges();
            }

            if (SalaAtualizada.Nome!= null)
            {
                salaBuscada.Nome = SalaAtualizada.Nome;
                
                ctx.Salas.Update(salaBuscada);
                
                ctx.SaveChanges();
            }
        }

        public Sala BuscarPorId(int id)
        {
            return ctx.Salas.FirstOrDefault(s => s.IdSala == id);
        }

        /// <summary>
        /// cadastra uma sala nova e salva no banco
        /// </summary>
        /// <param name="novaSala"> novo objeto cadastrado </param>
        public void Cadastrar(Sala novaSala)
        {
            ctx.Salas.Add(novaSala);

            ctx.SaveChanges();
        }

        /// <summary>
        /// dela uma sala existente e salva no banco
        /// </summary>
        /// <param name="id"> id da sala que será deletada </param>
        public void Deletar(int id)
        {
            ctx.Salas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// lista todas as salas existentes
        /// </summary>
        /// <returns> uma lista com todas as salas </returns>
        public List<Sala> Listar()
        {
            return ctx.Salas.ToList();       
        }
    }
}
