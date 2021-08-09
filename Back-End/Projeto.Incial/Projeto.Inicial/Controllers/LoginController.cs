using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using projeto.inicial.webApi.Interfaces;
using projeto.inicial.webApi.VIewModels;
using Projeto.Incial.Repositories;
using Projeto.Inicial.Domains;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projeto.Incial.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _IUsuarioRepository { get; set; }

        public LoginController()
        {
            _IUsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel Login)
        {
            try
            {
                Usuario UsuarioBuscado = _IUsuarioRepository.Login(Login.Email, Login.Senha);

                if (UsuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, UsuarioBuscado.Nome)
                };

                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inicial-chave-autenticacao"));

                var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var Token = new JwtSecurityToken(
                        issuer: "Projeto.Incial",
                        audience: "Projeto.Incial",
                        claims: Claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: Creds
                );


                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(Token)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
