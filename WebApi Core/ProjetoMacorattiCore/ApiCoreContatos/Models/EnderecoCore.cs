using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiCoreContatos.Models
{
    [Table("EnderecoCore")]
    public partial class EnderecoCore
    {
        [Key]
        [Column("EnderecoID")]
        public int EnderecoId { get; set; }
        [Column("ContatoID")]
        public int ContatoId { get; set; }
        [Required]
        public string Local { get; set; }
        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }
        [Required]
        [Column("SiglaUF")]
        [StringLength(2)]
        public string SiglaUf { get; set; }

        [ForeignKey(nameof(ContatoId))]
        [InverseProperty(nameof(ContatoCore.EnderecoCores))]
        public virtual ContatoCore Contato { get; set; }
    }
}
