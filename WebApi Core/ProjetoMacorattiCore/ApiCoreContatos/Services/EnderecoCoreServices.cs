using ApiCoreContatos.Map;
using ApiCoreContatos.Models;
using ApiCoreContatos.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreContatos.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class EnderecoCoreServices : AncestralServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public EnderecoCoreServices(ContatoContext contexto) : base(contexto)
        {
            this.mapa = new EnderecoCoreMap();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<EnderecoCorePoco> Browse()
        {
            var lista = this.contexto.EnderecoCores.ToList();
            var listaPoco = this.mapa.GetMapper.Map<List<EnderecoCorePoco>>(lista);
            return listaPoco;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EnderecoCorePoco Read(int id)
        {
            var endereco = this.contexto.EnderecoCores.Where(c => c.EnderecoId == id).SingleOrDefault();
            var poco = this.mapa.GetMapper.Map<EnderecoCorePoco>(endereco);
            return poco;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public EnderecoCorePoco Edit(EnderecoCorePoco poco)
        {
            EnderecoCore endereco = this.mapa.GetMapper.Map<EnderecoCore>(poco);
            this.contexto.Entry<EnderecoCore>(endereco).State = EntityState.Modified;
            this.contexto.SaveChanges();
            EnderecoCorePoco pocoAlterado = this.mapa.GetMapper.Map<EnderecoCorePoco>(endereco);
            return pocoAlterado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public EnderecoCorePoco Add(EnderecoCorePoco poco)
        {
            EnderecoCore endereco = this.mapa.GetMapper.Map<EnderecoCore>(poco);
            this.contexto.EnderecoCores.Add(endereco);
            this.contexto.SaveChanges();
            EnderecoCorePoco pocoNovo = this.mapa.GetMapper.Map<EnderecoCorePoco>(endereco);
            return pocoNovo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EnderecoCorePoco Delete(int id)
        {
            var endereco = this.contexto.EnderecoCores.Where(c => c.EnderecoId == id).SingleOrDefault();
            //this.contexto.Entry<EnderecoCore>(endereco).State = EntityState.Deleted;
            this.contexto.EnderecoCores.Remove(endereco);
            this.contexto.SaveChanges();
            var pocoDeletado = this.mapa.GetMapper.Map<EnderecoCorePoco>(endereco);
            return pocoDeletado;
        }
    }
}
