using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Interfaces
    {
    public interface IProntuarioRepository
        {
        List<Prontuario> Listar();
        Prontuario BuscarPorId(Guid id);
        void Cadastrar(Prontuario novoProntuario);
        void Atualizar(Guid id, Prontuario prontuarioAtualizado);
        void Deletar(Guid id);
        }
    }
