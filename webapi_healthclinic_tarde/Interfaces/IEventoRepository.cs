using webapi_event__tarde.Domains;

namespace webapi_event__tarde.Interfaces
    {
    public interface IEventoRepository
        {
        List<Evento> Listar();
        Evento BuscarPorId(Guid id);
        void Cadastrar(Evento evento);
        void Atualizar(Guid id, Evento evento);
        void Deletar(Guid id);
        public List<ComentarioEvento> ListarComentariosEvento(Guid id);
        }
    }
