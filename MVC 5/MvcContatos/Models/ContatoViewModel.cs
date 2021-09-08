using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcContatos.Models
{
    public class ContatoViewModel
    {
        public int ContatoId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}