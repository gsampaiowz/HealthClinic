using Microsoft.EntityFrameworkCore;
using webapi_event__tarde.Domains;

namespace webapi_event__tarde.Contexts
    {
    public class EventContext : DbContext
        {
        //Cria as tabelas no banco de dados
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        
        //Configuração para criar o banco de dados com a string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.UseSqlServer("Server = NOTE10-S14\\SQLEXPRESS; Database = eventPlus_tarde; User Id = sa; Password = Senai@134; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
            }
        }
    }
