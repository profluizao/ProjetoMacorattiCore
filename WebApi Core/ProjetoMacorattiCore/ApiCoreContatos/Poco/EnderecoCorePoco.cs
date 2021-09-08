using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreContatos.Poco
{
    /// <summary>
    /// 
    /// </summary>
    public class EnderecoCorePoco
    {
        /// <summary>
        /// 
        /// </summary>
        public int EnderecoId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ContatoId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Local { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SiglaUf { get; set; }
    }
}
