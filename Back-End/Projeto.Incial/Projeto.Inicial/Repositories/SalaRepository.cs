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

        public void Cadastrar(Sala novaSala)
        {
            ctx.Salas.Add(novaSala);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Salas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Sala> Listar()
        {
            return ctx.Salas.ToList();       
        }
    }
}
