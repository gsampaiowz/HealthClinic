using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Interfaces
    {
    public interface IPacienteRepository
        {
        List<Paciente> Listar();
        Paciente BuscarPorId(Guid id);
        void Cadastrar(Paciente novoPaciente);
        void Atualizar(Guid id, Paciente pacienteAtualizado);
        void Deletar(Guid id);
        }
    }
