using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Confitec.Application.Interfaces;
using Confitec.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<object> Get()
        {            
            return _usuarioAppService.GetAll().Select(x => new { x.Id, x.Nome, x.Sobrenome, x.Email, x.DataNascimento, x.Escolaridade }).ToList(); 
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<UsuarioModel> GetById(int Id)
        {
            return _usuarioAppService.GetById(Id);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel model)
        {
            return _usuarioAppService.Add(model);
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<UsuarioModel> Patch(int Id, [FromBody] JsonPatchDocument<UsuarioModel> model)
        {
            var retorno = _usuarioAppService.Patch(Id, model);

            if (retorno)
                return Ok(new RetornoModel() { Sucesso = retorno, Mensagem = "Usuário atualizado com sucesso" });
            else
                return BadRequest(new RetornoModel() { Sucesso = retorno, Mensagem = "Erro ao atualizar usuário" });
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<UsuarioModel> Put(int Id, [FromBody] UsuarioModel model)
        {
            var retorno = _usuarioAppService.Put(Id, model);

            if (retorno)
                return Ok(new RetornoModel() { Sucesso = retorno, Mensagem = "Usuário atualizado com sucesso" });
            else
                return BadRequest(new RetornoModel() { Sucesso = retorno, Mensagem = "Erro ao atualizar usuário" });
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<object> Delete(int Id)
        {
            var retorno = _usuarioAppService.Remove(Id);
            
            if (retorno)
                return Ok(new RetornoModel() { Sucesso = retorno, Mensagem = "Usuário deletado com sucesso" });
            else
                return BadRequest(new RetornoModel() { Sucesso = retorno, Mensagem = "Erro ao deletar usuário" });
        }

    }
}