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
            entity.HasKey(e => e.IdClinica).HasName("PK__Clinica__52A9095164431F83");

            entity.ToTable("Clinica");

            entity.HasIndex(e => e.Endereco, "UQ__Clinica__4DF3E1FFD76D696B").IsUnique();

            entity.HasIndex(e => e.Unidade, "UQ__Clinica__A2FB7B67B15A313E").IsUnique();

            entity.HasIndex(e => e.Cnpj, "UQ__Clinica__AA57D6B4D33FC2A2").IsUnique();

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
            entity.HasKey(e => e.IdComentario).HasName("PK__Comentar__DDBEFBF93EE1DA18");

            entity.ToTable("Comentario");

            entity.Property(e => e.IdComentario).ValueGeneratedNever();
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__IdCon__73BA3083");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__IdPac__74AE54BC");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("PK__Consulta__9B2AD1D8972EDBB4");

            entity.Property(e => e.IdConsulta).ValueGeneratedNever();
            entity.Property(e => e.Data).HasColumnType("date");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__IdMedi__6A30C649");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__IdPaci__6B24EA82");

            entity.HasOne(d => d.IdSituacaoNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdSituacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__IdSitu__6D0D32F4");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidade).HasName("PK__Especial__5676CEFFF85624C1");

            entity.ToTable("Especialidade");

            entity.HasIndex(e => e.NomeEspecialidade, "UQ__Especial__D6E5EBAE0FD72694").IsUnique();

            entity.Property(e => e.IdEspecialidade).ValueGeneratedNever();
            entity.Property(e => e.NomeEspecialidade)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__Medico__C326E65206628C97");

            entity.ToTable("Medico");

            entity.HasIndex(e => e.IdUsuario, "UQ__Medico__5B65BF9626DBC14D").IsUnique();

            entity.Property(e => e.IdMedico).ValueGeneratedNever();
            entity.Property(e => e.Crm)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("CRM");

            entity.HasOne(d => d.IdClinicaNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdClinica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medico__IdClinic__5DCAEF64");

            entity.HasOne(d => d.IdEspecialidadeNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdEspecialidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medico__IdEspeci__5CD6CB2B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Medico)
                .HasForeignKey<Medico>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medico__IdUsuari__5BE2A6F2");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49B442F6DB3");

            entity.ToTable("Paciente");

            entity.HasIndex(e => e.Rg, "UQ__Paciente__321537C8D6B5D609").IsUnique();

            entity.HasIndex(e => e.Telefone, "UQ__Paciente__4EC504B6B385E632").IsUnique();

            entity.HasIndex(e => e.IdUsuario, "UQ__Paciente__5B65BF9662E59F0C").IsUnique();

            entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F897318B5F3489").IsUnique();

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
                .HasConstraintName("FK__Paciente__IdUsua__6477ECF3");
        });

        modelBuilder.Entity<Prontuario>(entity =>
        {
            entity.HasKey(e => e.IdProntuario).HasName("PK__Prontuar__3AB81E66AC9F9AD4");

            entity.ToTable("Prontuario");

            entity.HasIndex(e => e.IdConsulta, "UQ__Prontuar__9B2AD1D9FE536DF4").IsUnique();

            entity.Property(e => e.IdProntuario).ValueGeneratedNever();
            entity.Property(e => e.Descricao).HasColumnType("text");

            entity.HasOne(d => d.IdConsultaNavigation).WithOne(p => p.Prontuario)
                .HasForeignKey<Prontuario>(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prontuari__IdCon__70DDC3D8");
        });

        modelBuilder.Entity<Situacao>(entity =>
        {
            entity.HasKey(e => e.IdSituacao).HasName("PK__Situacao__810BCE3A56CAF005");

            entity.ToTable("Situacao");

            entity.HasIndex(e => e.TituloSituacao, "UQ__Situacao__E031B903163A9570").IsUnique();

            entity.Property(e => e.IdSituacao).ValueGeneratedNever();
            entity.Property(e => e.TituloSituacao)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoDeUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoDeUsuario).HasName("PK__TipoDeUs__8C8B582A3C6E46CC");

            entity.ToTable("TipoDeUsuario");

            entity.HasIndex(e => e.NomeTipoDeUsuario, "UQ__TipoDeUs__D2C28208EAC545E7").IsUnique();

            entity.Property(e => e.IdTipoDeUsuario).ValueGeneratedNever();
            entity.Property(e => e.NomeTipoDeUsuario)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF9769980AAE");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D1053490A82EDA").IsUnique();

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
                .HasConstraintName("FK__Usuario__IdTipoD__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
