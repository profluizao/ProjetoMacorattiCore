using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiContatos.Models
{
    [Index(nameof(EnderecoId), Name = "IX_EnderecoId")]
    public partial class Contato
    {
        [Key]
        public int ContatoId { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(40)]
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }

        [ForeignKey(nameof(EnderecoId))]
        [InverseProperty("Contatos")]
        public virtual Endereco Endereco { get; set; }
    }
}
