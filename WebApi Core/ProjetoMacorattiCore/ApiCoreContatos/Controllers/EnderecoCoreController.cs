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
    [Route("api/endereco")]
    [ApiController]
    public class EnderecoCoreController : ControllerBase
    {
        private EnderecoCoreServices servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public EnderecoCoreController(ContatoContext contexto)
        {
            this.servico = new EnderecoCoreServices(contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var lista = this.servico.Browse();
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
            var poco = this.servico.Read(id);
            return Ok(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] EnderecoCorePoco poco)
        {
            if (poco is null)
            {
                throw new ArgumentNullException(nameof(poco));
            }
            var pocoNovo = this.servico.Add(poco);
            return Ok(pocoNovo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] EnderecoCorePoco poco)
        {
            if (poco is null)
            {
                throw new ArgumentNullException(nameof(poco));
            }
            var pocoAlterado = this.servico.Edit(poco);
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
            var poco = this.servico.Delete(id);
            return Ok(poco);
        }
    }
}
