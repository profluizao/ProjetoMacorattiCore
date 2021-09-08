using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiCoreContatos.Models
{
    [Table("ContatoCore")]
    public partial class ContatoCore
    {
        public ContatoCore()
        {
            EnderecoCores = new HashSet<EnderecoCore>();
        }

        [Key]
        [Column("ContatoID")]
        public int ContatoId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(40)]
        public string Telefone { get; set; }

        [InverseProperty(nameof(EnderecoCore.Contato))]
        public virtual ICollection<EnderecoCore> EnderecoCores { get; set; }
    }
}
