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
    public class ContatoCoreServices : AncestralServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public ContatoCoreServices(ContatoContext contexto) : base(contexto)
        { 
            this.mapa = new ContatoCoreMap();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ContatoCorePoco> Browse()
        {
            var lista = this.contexto.ContatoCores.ToList();
            var listaPoco = this.mapa.GetMapper.Map<List<ContatoCorePoco>>(lista);
            return listaPoco;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContatoCorePoco Read(int id)
        {
            var contato = this.contexto.ContatoCores.Where(c => c.ContatoId == id).SingleOrDefault();
            var poco = this.mapa.GetMapper.Map<ContatoCorePoco>(contato);
            return poco;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public ContatoCorePoco Edit(ContatoCorePoco poco)
        {
            ContatoCore contato = this.mapa.GetMapper.Map<ContatoCore>(poco);
            this.contexto.Entry<ContatoCore>(contato).State = EntityState.Modified;
            this.contexto.SaveChanges();
            ContatoCorePoco pocoAlterado = this.mapa.GetMapper.Map<ContatoCorePoco>(contato);
            return pocoAlterado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        public ContatoCorePoco Add(ContatoCorePoco poco)
        {
            ContatoCore contato = this.mapa.GetMapper.Map<ContatoCore>(poco);
            this.contexto.ContatoCores.Add(contato);
            this.contexto.SaveChanges();
            ContatoCorePoco pocoNovo = this.mapa.GetMapper.Map<ContatoCorePoco>(contato);
            return pocoNovo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContatoCorePoco Delete(int id)
        {
            ContatoCore contato = this.contexto.ContatoCores.Where(c => c.ContatoId == id).SingleOrDefault();
            this.contexto.ContatoCores.Remove(contato);
            this.contexto.SaveChanges();
            ContatoCorePoco pocoDeletado = this.mapa.GetMapper.Map<ContatoCorePoco>(contato);
            return pocoDeletado;
        }
    }
}
