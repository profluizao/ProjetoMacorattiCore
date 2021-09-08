using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiCoreContatos.Models
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

        public virtual DbSet<ContatoCore> ContatoCores { get; set; }
        public virtual DbSet<EnderecoCore> EnderecoCores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=(local);Database=ClienteDB;Trusted_Connection=True;");
                throw new Exception("String de Conexão não foi inicializada.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ContatoCore>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Telefone).IsUnicode(false);
            });

            modelBuilder.Entity<EnderecoCore>(entity =>
            {
                entity.Property(e => e.Cidade).IsUnicode(false);

                entity.Property(e => e.Local).IsUnicode(false);

                entity.Property(e => e.SiglaUf)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Contato)
                    .WithMany(p => p.EnderecoCores)
                    .HasForeignKey(d => d.ContatoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnderecoCore_ContatoCore");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
