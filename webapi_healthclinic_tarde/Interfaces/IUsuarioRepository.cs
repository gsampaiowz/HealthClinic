using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Interfaces
    {
    public interface IUsuarioRepository
        {
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
        Usuario BuscarPorEmailESenha(string email, string senha);
        void Cadastrar(Usuario novoUsuario);
        void Atualizar(Guid id, Usuario usuarioAtualizado);
        void Deletar(Guid id);
        }
    }
