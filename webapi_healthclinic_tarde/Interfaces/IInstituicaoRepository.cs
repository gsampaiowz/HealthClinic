using webapi_event__tarde.Domains;

namespace webapi_event__tarde.Interfaces
    {
    public interface IInstituicaoRepository
        {
        List<Instituicao> Listar();
        Instituicao BuscarPorId(Guid id);
        void Cadastrar(Instituicao instituicao);
        void Atualizar(Guid id, Instituicao instituicao);
        void Deletar(Guid id);
        }
    }
