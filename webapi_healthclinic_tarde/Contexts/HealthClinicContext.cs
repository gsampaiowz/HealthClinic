using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Contexts;

public partial class HealthClinicContext : DbContext
{
    public HealthClinicContext()
    {
    }

    public HealthClinicContext(DbContextOptions<HealthClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clinica> Clinica { get; set; }

    public virtual DbSet<Comentario> Comentario { get; set; }

    public virtual DbSet<Consulta> Consulta { get; set; }

    public virtual DbSet<Especialidade> Especialidade { get; set; }

    public virtual DbSet<Medico> Medico { get; set; }

    public virtual DbSet<Paciente> Paciente { get; set; }

    public virtual DbSet<Prontuario> Prontuario { get; set; }

    public virtual DbSet<Situacao> Situacao { get; set; }

    public virtual DbSet<TipoDeUsuario> TipoDeUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NOTE10-S14\\SQLEXPRESS; initial catalog=HealthClinic_Tarde; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinica>(entity =>
        {
            entity.HasKey(e => e.IdClinica).HasName("PK__Clinica__52A909516EB4B0C4");

            entity.ToTable("Clinica");

            entity.HasIndex(e => e.Endereco, "UQ__Clinica__4DF3E1FFD8E1F9CB").IsUnique();

            entity.HasIndex(e => e.Unidade, "UQ__Clinica__A2FB7B6758FF6EF3").IsUnique();

            entity.HasIndex(e => e.Cnpj, "UQ__Clinica__AA57D6B42D4BA149").IsUnique();

            entity.Property(e => e.IdClinica).ValueGeneratedNever();
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Endereco)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Unidade)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PK__Comentar__DDBEFBF953CC096F");

            entity.ToTable("Comentario");

            entity.Property(e => e.IdComentario).ValueGeneratedNever();
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__IdCon__6FE99F9F");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("PK__Consulta__9B2AD1D8D63B6287");

            entity.Property(e => e.IdConsulta).ValueGeneratedNever();
            entity.Property(e => e.Data).HasColumnType("date");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__IdMedi__6754599E");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__IdPaci__68487DD7");

            entity.HasOne(d => d.IdSituacaoNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdSituacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__IdSitu__693CA210");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidade).HasName("PK__Especial__5676CEFF612FD50B");

            entity.ToTable("Especialidade");

            entity.HasIndex(e => e.NomeEspecialidade, "UQ__Especial__D6E5EBAE35E4304F").IsUnique();

            entity.Property(e => e.IdEspecialidade).ValueGeneratedNever();
            entity.Property(e => e.NomeEspecialidade)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__Medico__C326E652A4AA5DEE");

            entity.ToTable("Medico");

            entity.HasIndex(e => e.IdUsuario, "UQ__Medico__5B65BF96B1B456C2").IsUnique();

            entity.Property(e => e.IdMedico).ValueGeneratedNever();
            entity.Property(e => e.Crm)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("CRM");

            entity.HasOne(d => d.IdClinicaNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdClinica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medico__IdClinic__5AEE82B9");

            entity.HasOne(d => d.IdEspecialidadeNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdEspecialidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medico__IdEspeci__59FA5E80");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Medico)
                .HasForeignKey<Medico>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medico__IdUsuari__59063A47");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49BF5622A29");

            entity.ToTable("Paciente");

            entity.HasIndex(e => e.Rg, "UQ__Paciente__321537C81E0C6770").IsUnique();

            entity.HasIndex(e => e.Telefone, "UQ__Paciente__4EC504B6FB425D17").IsUnique();

            entity.HasIndex(e => e.IdUsuario, "UQ__Paciente__5B65BF96AB88511B").IsUnique();

            entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F89731F7D6AC7E").IsUnique();

            entity.Property(e => e.IdPaciente).ValueGeneratedNever();
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("CEP");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.DataNascimento).HasColumnType("date");
            entity.Property(e => e.Endereco)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Rg)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("RG");
            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Paciente)
                .HasForeignKey<Paciente>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paciente__IdUsua__619B8048");
        });

        modelBuilder.Entity<Prontuario>(entity =>
        {
            entity.HasKey(e => e.IdProntuario).HasName("PK__Prontuar__3AB81E66A9794A5D");

            entity.ToTable("Prontuario");

            entity.HasIndex(e => e.IdConsulta, "UQ__Prontuar__9B2AD1D9D9BB5C5B").IsUnique();

            entity.Property(e => e.IdProntuario).ValueGeneratedNever();
            entity.Property(e => e.Descricao).HasColumnType("text");

            entity.HasOne(d => d.IdConsultaNavigation).WithOne(p => p.Prontuario)
                .HasForeignKey<Prontuario>(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prontuari__IdCon__6D0D32F4");
        });

        modelBuilder.Entity<Situacao>(entity =>
        {
            entity.HasKey(e => e.IdSituacao).HasName("PK__Situacao__810BCE3AB1E464A2");

            entity.ToTable("Situacao");

            entity.HasIndex(e => e.TituloSituacao, "UQ__Situacao__E031B903BA2D9490").IsUnique();

            entity.Property(e => e.IdSituacao).ValueGeneratedNever();
            entity.Property(e => e.TituloSituacao)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoDeUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoDeUsuario).HasName("PK__TipoDeUs__8C8B582ADC422FAB");

            entity.ToTable("TipoDeUsuario");

            entity.HasIndex(e => e.NomeTipoDeUsuario, "UQ__TipoDeUs__D2C28208915A5563").IsUnique();

            entity.Property(e => e.IdTipoDeUsuario).ValueGeneratedNever();
            entity.Property(e => e.NomeTipoDeUsuario)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97B58373B1");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534BC6F1020").IsUnique();

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomeUsuario)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoDeUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoDeUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__IdTipoD__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
