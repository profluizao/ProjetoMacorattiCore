using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiContatos.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Contatos = new HashSet<Contato>();
        }

        [Key]
        public int EnderecoId { get; set; }
        [StringLength(150)]
        public string Local { get; set; }
        [StringLength(100)]
        public string Cidade { get; set; }
        [StringLength(100)]
        public string Estado { get; set; }

        [InverseProperty(nameof(Contato.Endereco))]
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
