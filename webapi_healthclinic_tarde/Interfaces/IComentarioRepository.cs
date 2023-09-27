using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Interfaces
    {
    public interface IComentarioRepository
        {
        List<Comentario> Listar();
        Comentario BuscarPorId(Guid id);
        void Cadastrar(Comentario novoComentario);
        void Deletar(Guid id);
        void Atualizar(Guid id, Comentario comentarioAtualizado);

        }
    }
