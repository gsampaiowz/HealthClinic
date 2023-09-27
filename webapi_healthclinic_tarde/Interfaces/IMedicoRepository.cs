using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Interfaces
    {
    public interface IMedicoRepository
        {
        List<Medico> Listar();
        Medico BuscarPorId(Guid id);
        void Cadastrar(Medico novoMedico);
        void Atualizar(Guid id, Medico medicoAtualizado);
        void Deletar(Guid id);
        }
    }
