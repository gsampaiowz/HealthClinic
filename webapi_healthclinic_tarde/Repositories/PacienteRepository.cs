using Microsoft.EntityFrameworkCore;
using webapi_healthclinic_tarde.Contexts;
using webapi_healthclinic_tarde.Domains;
using webapi_healthclinic_tarde.Interfaces;

namespace webapi_healthclinic_tarde.Repositories
    {
    public class PacienteRepository : IPacienteRepository
        {
#pragma warning disable IDE0052
        private readonly HealthClinicContext ctx;
#pragma warning restore IDE0052

        public PacienteRepository()
            {
            ctx = new HealthClinicContext();
            }

        public void Atualizar(Guid id, Paciente pacienteAtualizado)
            {
            try
                {
                Paciente paciente = BuscarPorId(id) ?? throw new Exception("Paciente não encontrada");

                paciente.Telefone = pacienteAtualizado.Telefone;
                paciente.Rg = pacienteAtualizado.Rg;
                paciente.Cpf = pacienteAtualizado.Cpf;
                paciente.Endereco = pacienteAtualizado.Endereco;
                paciente.DataNascimento = pacienteAtualizado.DataNascimento;

                ctx.Paciente.Update(paciente);
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Paciente BuscarPorId(Guid id)
            {
            try
                {
                return ctx.Paciente.Include(p => p.IdUsuarioNavigation).FirstOrDefault(c => c.IdPaciente == id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Paciente novoPaciente)
            {
            try
                {
                ctx.Paciente.Add(novoPaciente);
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
                ctx.Paciente.Remove(BuscarPorId(id));
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Paciente> Listar()
            {
            try
                {
                return ctx.Paciente.Include(p => p.IdUsuarioNavigation).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
