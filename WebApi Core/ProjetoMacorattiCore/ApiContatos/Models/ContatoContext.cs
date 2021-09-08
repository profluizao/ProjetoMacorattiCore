using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiContatos.Models
{
    public partial class ContatoContext : DbContext
    {
        public ContatoContext()
        {
        }

        public ContatoContext(DbContextOptions<ContatoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contato> Contatos { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=ClienteDB;User Id=usuario;Password=senha123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Contato>(entity =>
            {
                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.Contatos)
                    .HasForeignKey(d => d.EnderecoId)
                    .HasConstraintName("FK_dbo.Contatos_dbo.Enderecos_EnderecoId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
