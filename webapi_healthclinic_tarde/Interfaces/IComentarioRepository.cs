using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Interfaces
    {
    public interface IComentarioRepository
        {
        Comentario BuscarPorId(Guid id);
        void Deletar(Guid id);
        void Atualizar(Guid id, Comentario comentarioAtualizado);
        }
    }
