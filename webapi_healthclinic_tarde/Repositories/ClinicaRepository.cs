using webapi_healthclinic_tarde.Contexts;
using webapi_healthclinic_tarde.Domains;
using webapi_healthclinic_tarde.Interfaces;

namespace webapi_healthclinic_tarde.Repositories
    {
    public class ClinicaRepository : IClinicaRepository
        {
#pragma warning disable IDE0052
        private readonly HealthClinicContext ctx;
#pragma warning restore IDE0052

        public ClinicaRepository()
            {
            ctx = new HealthClinicContext();
            }

        public void Atualizar(Guid id, Clinica clinicaAtualizada)
            {
            try
                {
                Clinica clinica = BuscarPorId(id) ?? throw new Exception("Clinica não encontrada");

                clinica.Unidade = clinicaAtualizada.Unidade;
                clinica.Cnpj = clinicaAtualizada.Cnpj;
                clinica.Endereco = clinicaAtualizada.Endereco;
                clinica.HoraAbertura = clinicaAtualizada.HoraAbertura;
                clinica.HoraEncerramento = clinicaAtualizada.HoraEncerramento;

                ctx.Clinica.Update(clinica);
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Clinica BuscarPorId(Guid id)
            {
            try
                {
                return ctx.Clinica.Find(id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Clinica novaClinica)
            {
            try
                {
                ctx.Clinica.Add(novaClinica);
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
                ctx.Clinica.Remove(BuscarPorId(id));
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Clinica> Listar()
            {
            try
                {
                return ctx.Clinica.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }


