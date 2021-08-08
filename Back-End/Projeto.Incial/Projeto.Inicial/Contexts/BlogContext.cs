using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Projeto.Inicial.Domains;

#nullable disable

namespace Projeto.Inicial.Contexts
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipamento> Equipamentos { get; set; }
        public virtual DbSet<Escola> Escolas { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<TipoEquipamento> TipoEquipamentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source= PC-DA-XUXA; Initial Catalog= Projeto_Inicial; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Equipamento>(entity =>
            {
                entity.HasKey(e => e.IdEquipamento)
                    .HasName("PK__Equipame__75940D34E3BC8462");

                entity.ToTable("Equipamento");

                entity.Property(e => e.IdEquipamento).HasColumnName("idEquipamento");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdSala).HasColumnName("idSala");

                entity.Property(e => e.IdTipoEquipamento).HasColumnName("idTipoEquipamento");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.NumeroPatrimonio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numeroPatrimonio");

                entity.Property(e => e.NumeroSerie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numeroSerie");

                entity.Property(e => e.Situacao)
                    .HasColumnName("situacao")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK__Equipamen__idSal__2F10007B");

                entity.HasOne(d => d.IdTipoEquipamentoNavigation)
                    .WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.IdTipoEquipamento)
                    .HasConstraintName("FK__Equipamen__idTip__2E1BDC42");
            });

            modelBuilder.Entity<Escola>(entity =>
            {
                entity.HasKey(e => e.IdEscola)
                    .HasName("PK__Escola__034B40ED87165C5A");

                entity.ToTable("Escola");

                entity.Property(e => e.IdEscola).HasColumnName("idEscola");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala)
                    .HasName("PK__Sala__C4AEB19C485FB234");

                entity.ToTable("Sala");

                entity.Property(e => e.IdSala).HasColumnName("idSala");

                entity.Property(e => e.Andar)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("andar");

                entity.Property(e => e.IdEscola).HasColumnName("idEscola");

                entity.Property(e => e.Metragem)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("metragem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdEscolaNavigation)
                    .WithMany(p => p.Salas)
                    .HasForeignKey(d => d.IdEscola)
                    .HasConstraintName("FK__Sala__idEscola__29572725");
            });

            modelBuilder.Entity<TipoEquipamento>(entity =>
            {
                entity.HasKey(e => e.IdTipoEquipamento)
                    .HasName("PK__TipoEqui__38B9B7E39C9DC10F");

                entity.ToTable("TipoEquipamento");

                entity.Property(e => e.IdTipoEquipamento).HasColumnName("idTipoEquipamento");

                entity.Property(e => e.NomeTipoEquipamento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoEquipamento");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6AB429D9D");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdEscola).HasColumnName("idEscola");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdEscolaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEscola)
                    .HasConstraintName("FK__Usuario__idEscol__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
