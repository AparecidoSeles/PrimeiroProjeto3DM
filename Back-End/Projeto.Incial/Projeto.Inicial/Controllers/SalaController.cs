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
    public class SalaController : ControllerBase
    {

        private ISalaRepository _salaRepository { get; set; }

        public SalaController()
        {
            _salaRepository = new SalaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_salaRepository.Listar());
            }

            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Sala novaSala)
        {
            try
            {
                _salaRepository.Cadastrar(novaSala);

                return StatusCode(201);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Sala SalaAtualizada)
        {
            try
            {
                _salaRepository.Atualizar(id, SalaAtualizada);

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
                _salaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
