using webapi_event__tarde.Domains;

namespace webapi_event__tarde.Interfaces
    {
    public interface IUsuarioRepository
        {
        List<Usuario> Listar();
        Usuario BuscarPorEmailESenha(string email, string senha);
        Usuario BuscarPorId(Guid id);
        void Cadastrar(Usuario usuario);
        void Atualizar(Guid id, Usuario usuario);
        void Deletar(Guid id);

        List<PresencaEvento> ListarMinhas(Guid id);
        }
    }