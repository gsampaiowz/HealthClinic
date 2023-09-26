using webapi_healthclinic_tarde.Domains;

namespace webapi_healthclinic_tarde.Interfaces
    {
    public interface IConsultaRepository
        {
        List<Consulta> Listar();
        Consulta BuscarPorId(Guid id);
        void Cadastrar(Consulta novaConsulta);
        void Atualizar(Guid id, Consulta consultaAtualizada);
        void Deletar(Guid id);
        }
    }
