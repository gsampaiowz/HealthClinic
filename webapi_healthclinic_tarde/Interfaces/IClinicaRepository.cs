using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Interfaces
    {
    public interface IClinicaRepository
        {
        List<Clinica> Listar();
        Clinica BuscarPorId(Guid id);
        void Cadastrar(Clinica novaClinica);
        void Atualizar(Guid id, Clinica clinicaAtualizada);
        void Deletar(Guid id);
        }
    }
