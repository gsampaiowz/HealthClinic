using Microsoft.EntityFrameworkCore;
using webapi_healthclinic_tarde.Contexts;
using webapi_healthclinic_tarde.Domains;
using webapi_healthclinic_tarde.Interfaces;

namespace webapi_healthclinic_tarde.Repositories
    {
    public class MedicoRepository : IMedicoRepository
        {
#pragma warning disable IDE0052
        private readonly HealthClinicContext ctx;
#pragma warning restore IDE0052

        public MedicoRepository()
            {
            ctx = new HealthClinicContext();
            }

        public void Atualizar(Guid id, Medico medicoAtualizado)
            {
            try
                {
                Medico medico = BuscarPorId(id) ?? throw new Exception("Medico não encontrada");

                medico.IdClinica = medicoAtualizado.IdClinica;
                medico.IdEspecialidade = medicoAtualizado.IdEspecialidade;
                medico.IdUsuario = medicoAtualizado.IdUsuario;
                medico.Crm = medicoAtualizado.Crm;

                ctx.Medico.Update(medico);
                ctx.SaveChanges();
                }
            catch (Exception)
                {

                throw;
                }
            }

        public Medico BuscarPorId(Guid id)
            {
            try
                {
                return ctx.Medico.Include(m => m.IdUsuarioNavigation).Include(m => m.IdClinicaNavigation).Include(m => m.IdEspecialidadeNavigation).FirstOrDefault(c => c.IdMedico == id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Medico novoMedico)
            {
            try
                {
                ctx.Medico.Add(novoMedico);
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
                ctx.Medico.Remove(BuscarPorId(id));
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Medico> Listar()
            {
            try
                {
                return ctx.Medico.Include(m => m.IdUsuarioNavigation).Include(m => m.IdClinicaNavigation).Include(m => m.IdEspecialidadeNavigation).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
