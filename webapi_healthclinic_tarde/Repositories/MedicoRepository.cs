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
                return ctx.Medico.Select(m => new Medico
                    {
                    IdMedico = m.IdMedico,
                    IdUsuario = m.IdUsuario,
                    IdClinica = m.IdClinica,
                    IdEspecialidade = m.IdEspecialidade,
                    Crm = m.Crm,

                    IdUsuarioNavigation = new Usuario
                        {
                        IdUsuario = m.IdUsuarioNavigation.IdUsuario,
                        NomeUsuario = m.IdUsuarioNavigation.NomeUsuario,
                        },
                    }).FirstOrDefault(c => c.IdMedico == id)!;
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
                return ctx.Medico.Select(m => new Medico
                    {
                    IdMedico = m.IdMedico,
                    IdUsuario = m.IdUsuario,
                    IdClinica = m.IdClinica,
                    IdEspecialidade = m.IdEspecialidade,
                    Crm = m.Crm,

                    IdUsuarioNavigation = new Usuario
                        {
                        IdUsuario = m.IdUsuarioNavigation.IdUsuario,
                        NomeUsuario = m.IdUsuarioNavigation.NomeUsuario,
                        },
                    }).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }

        // Lista todas as consultas referentes um determinado médico
        public List<Consulta> MedicoConsultas(Guid id)
            {
            try
                {
                return ctx.Consulta.Select(c => new Consulta
                    {
                    IdConsulta = c.IdConsulta,
                    IdPaciente = c.IdPaciente,
                    IdMedico = c.IdMedico,
                    IdSituacao = c.IdSituacao,
                    Data = c.Data,
                    Horario = c.Horario,

                    IdSituacaoNavigation = new Situacao
                        {
                        IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                        TituloSituacao = c.IdSituacaoNavigation.TituloSituacao,
                        },
                    }).Where(c => c.IdMedico == id).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }

        // Lista todas os comentários referentes um determinado médico
        public List<Comentario> MedicoComentarios(Guid id)
            {
            try
                {
                return ctx.Comentario.Select(c => new Comentario
                    {
                    IdComentario = c.IdComentario,
                    IdConsulta = c.IdConsulta,
                    Exibe = c.Exibe,
                    Descricao = c.Descricao,

                    IdConsultaNavigation = new Consulta
                        {
                        IdConsulta = c.IdConsultaNavigation.IdConsulta,

                        IdPacienteNavigation = new Paciente
                            {
                            IdPaciente = c.IdConsultaNavigation.IdPacienteNavigation.IdPaciente,
                            IdUsuarioNavigation = new Usuario
                                {
                                IdUsuario = c.IdConsultaNavigation.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario,
                                NomeUsuario = c.IdConsultaNavigation.IdPacienteNavigation.IdUsuarioNavigation.NomeUsuario
                                }
                            }
                        }
                    }).Where(c => c.IdConsultaNavigation.IdMedicoNavigation.IdMedico == id).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
