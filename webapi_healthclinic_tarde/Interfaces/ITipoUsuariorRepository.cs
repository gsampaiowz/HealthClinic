using webapi_event__tarde.Domains;

namespace webapi_event__tarde.Interfaces
    {
    public interface ITipoUsuarioRepository
        {
        List<TipoUsuario> Listar();
        TipoUsuario BuscarPorId(Guid id);
        void Cadastrar(TipoUsuario tipoUsuario);
        void Atualizar(Guid id, TipoUsuario tipoUsuario);
        void Deletar(Guid id);
        }
    }
