using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Interfaces
    {
    public interface IUsuarioRepository
        {
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
        void Cadastrar(Usuario novoUsuario);
        void Atualizar(Guid id, Usuario usuarioAtualizado);
        void Deletar(Guid id);
        }
    }
