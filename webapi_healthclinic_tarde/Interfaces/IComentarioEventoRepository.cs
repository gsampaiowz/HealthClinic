using webapi_event__tarde.Domains;

namespace webapi_event__tarde.Interfaces
    {
    public interface IComentarioEventoRepository
        {
        List<ComentarioEvento> Listar();
        ComentarioEvento BuscarPorId(Guid id);
        void Cadastrar(ComentarioEvento comentarioEvento);
        void Atualizar(Guid id, ComentarioEvento comentarioEvento);
        void Deletar(Guid id);
        }
    }
