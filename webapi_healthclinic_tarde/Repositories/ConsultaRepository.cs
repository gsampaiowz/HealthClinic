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
                    }).FirstOrDefault(c => c.IdConsulta == id)!;
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
                    }).ToList();
                }
            catch (Exception)
                {
                throw;

                }
            }

        //Retorna o comentário de uma determinada consulta
        public Comentario ConsultaComentario(Guid id)
            {
            try
                {

            return ctx.Comentario.Select(c => new Comentario
                {
                IdComentario = c.IdComentario,
                Descricao = c.Descricao,
                IdConsulta = c.IdConsulta,
                Exibe = c.Exibe,

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
                }).FirstOrDefault(c => c.IdConsulta == id)!;
                }
            catch (Exception)
                {

                throw;
                }
            }

        //Retorna o prontuário de uma determinada consulta
        public Prontuario ConsultaProntuario(Guid id)
            {
            try
                {
            return ctx.Prontuario.Select(c => new Prontuario
                {
                IdProntuario = c.IdProntuario,
                Descricao = c.Descricao,
                IdConsulta = c.IdConsulta,
                }).FirstOrDefault(c => c.IdConsulta == id)!;
                }
            catch (Exception)
                {

                throw;
                }
            }
        }
    }
