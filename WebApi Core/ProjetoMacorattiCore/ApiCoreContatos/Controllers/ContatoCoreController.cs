using ApiCoreContatos.Models;
using ApiCoreContatos.Poco;
using ApiCoreContatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreContatos.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/contato")]
    [ApiController]
    public class ContatoCoreController : ControllerBase
    {
        private ContatoCoreServices contatoServico;

        private EnderecoCoreServices enderecoServico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public ContatoCoreController(ContatoContext contexto)
        { 
            this.contatoServico = new ContatoCoreServices(contexto);
            this.enderecoServico = new EnderecoCoreServices(contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var lista = this.contatoServico.Browse();
            return Ok(lista);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var poco = this.contatoServico.Read(id);
            return Ok(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/enderecos")]
        public IActionResult GetEnderecos(int id)
        {
            var lista = this.enderecoServico.Browse().Where(c => c.ContatoId == id);
            return Ok(lista);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ContatoCorePoco poco)
        {
            if (poco is null)
            {
                throw new ArgumentNullException(nameof(poco));
            }
            var pocoNovo = this.contatoServico.Add(poco);
            return Ok(pocoNovo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] ContatoCorePoco poco)
        {
            if (poco is null)
            {
                throw new ArgumentNullException(nameof(poco));
            }
            var pocoAlterado = this.contatoServico.Edit(poco);
            return Ok(pocoAlterado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var poco = this.contatoServico.Delete(id);
            return Ok(poco);
        }
    }
}
