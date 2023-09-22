using webapi_event__tarde.Domains;

namespace webapi_event__tarde.Interfaces
    {
    public interface IPresencaEventoRepository
        {
        List<PresencaEvento> Listar();
        PresencaEvento BuscarPorId(Guid id);
        void Cadastrar(PresencaEvento presencaEvento);
        void Atualizar(Guid id, PresencaEvento presencaEvento);
        void Deletar(Guid id);
        }
    }
