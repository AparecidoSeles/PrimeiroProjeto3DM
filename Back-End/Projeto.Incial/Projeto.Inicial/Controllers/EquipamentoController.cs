using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto.inicial.webApi.Interfaces;
using Projeto.Incial.Repositories;
using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Incial.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        private IEquipamentoRepository _equipamentoRepository { get; set; }

        public EquipamentoController()
        {
            _equipamentoRepository = new EquipamentoRepository();
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
        public IActionResult Post(Equipamento novoEquipamento)
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
        public IActionResult Put(int id, Equipamento EquipamentoAtualizado)
        {
            try
            {
                _equipamentoRepository.Atualizar(id, EquipamentoAtualizado);

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