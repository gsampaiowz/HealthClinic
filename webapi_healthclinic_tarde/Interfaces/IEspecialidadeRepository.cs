using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Interfaces
    {
    public interface IEspecialidadeRepository
        {
        List<Especialidade> Listar();
        Especialidade BuscarPorId(Guid id);
        void Cadastrar(Especialidade novaEspecialidade);
        void Atualizar(Guid id, Especialidade especialidadeAtualizada);
        void Deletar(Guid id);
        }
    }
