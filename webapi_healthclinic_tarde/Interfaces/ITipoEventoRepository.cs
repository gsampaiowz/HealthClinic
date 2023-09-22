using webapi_event__tarde.Domains;

namespace webapi_event__tarde.Interfaces
    {
    public interface ITipoEventoRepository
        {
        List<TipoEvento> Listar();
        TipoEvento BuscarPorId(Guid id);
        void Cadastrar(TipoEvento tipoEvento);
        void Atualizar(Guid id, TipoEvento tipoEvento);
        void Deletar(Guid id);
        }
    }
