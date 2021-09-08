using ApiCoreContatos.Map;
using ApiCoreContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreContatos.Services
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AncestralServices
    {
        /// <summary>
        /// 
        /// </summary>
        protected ContatoContext contexto;

        /// <summary>
        /// 
        /// </summary>
        protected AncestralMap mapa;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public AncestralServices(ContatoContext contexto)
        {
            this.contexto = contexto;
        }
    }
}
