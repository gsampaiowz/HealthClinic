using Microsoft.EntityFrameworkCore;
using webapi_healthclinic_tarde.Contexts;
using webapi_healthclinic_tarde.Domains;
using webapi_healthclinic_tarde.Interfaces;

namespace webapi_healthclinic_tarde.Repositories
    {
    public class ConsultaRepository : IConsultaRepository
        {
#pragma warning disable IDE0052
        private readonly HealthClinicContext ctx;
#pragma warning restore IDE0052

        public ConsultaRepository()
            {
            ctx = new HealthClinicContext();
            }

        public void Atualizar(Guid id, Consulta consultaAtualizada)
            {
            try
                {
                Consulta consulta = BuscarPorId(id) ?? throw new Exception("Consulta não encontrada");

                consulta.Data = consultaAtualizada.Data;
                consulta.IdPaciente = consultaAtualizada.IdPaciente;
                consulta.IdMedico = consultaAtualizada.IdMedico;
                consulta.IdSituacao = consultaAtualizada.IdSituacao;
                consulta.Horario = consultaAtualizada.Horario;

                ctx.Consulta.Update(consulta);
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Consulta BuscarPorId(Guid id)
            {
            try
                {
                return ctx.Consulta.Include(c => c.IdPacienteNavigation).Include(c => c.IdMedicoNavigation).Include(c => c.IdSituacaoNavigation).FirstOrDefault(c => c.IdConsulta == id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Consulta novaConsulta)
            {
            try
                {
                ctx.Consulta.Add(novaConsulta);
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Deletar(Guid id)
            {
            try
                {
                ctx.Consulta.Remove(BuscarPorId(id));
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Consulta> Listar()
            {
            try
                {
                return ctx.Consulta.Include(c => c.IdPacienteNavigation).Include(c => c.IdMedicoNavigation).Include(c => c.IdSituacaoNavigation).ToList();
                }
            catch (Exception)
                {
                throw;

                }
            }
        }
    }
