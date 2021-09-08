using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcContatos.Models
{
    public class EnderecoViewModel
    {
        public int EnderecoId { get; set; }

        public int ContatoId { get; set; }

        public string Local { get; set; }

        public string Cidade { get; set; }

        public string SiglaUf { get; set; }
    }
}