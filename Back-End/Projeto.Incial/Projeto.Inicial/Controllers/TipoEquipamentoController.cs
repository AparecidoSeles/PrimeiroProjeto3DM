using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Incial.Interfaces;
using Projeto.Incial.Repositories;
using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Incial.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEquipamentoController : ControllerBase
    {
        private ITipoEquipamentoRepository _equipamentoRepository { get; set; }

        public TipoEquipamentoController()
        {
            _equipamentoRepository = new TipoEquipamentoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_equipamentoRepository.Listar());
            }

            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(TipoEquipamento novoEquipamento)
        {
            try
            {
                _equipamentoRepository.Cadastrar(novoEquipamento);

                return StatusCode(201);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoEquipamento tipoEquipamentoAtualizado)
        {
            try
            {
                _equipamentoRepository.Atualizar(id, tipoEquipamentoAtualizado);

                return StatusCode(204);
            }

            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _equipamentoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
