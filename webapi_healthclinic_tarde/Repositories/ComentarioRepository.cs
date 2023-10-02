using Microsoft.EntityFrameworkCore;
using webapi_healthclinic_tarde.Contexts;
using webapi_healthclinic_tarde.Domains;
using webapi_healthclinic_tarde.Interfaces;

namespace webapi_healthclinic_tarde.Repositories
    {
    public class ComentarioRepository : IComentarioRepository
        {
#pragma warning disable IDE0052
        private readonly HealthClinicContext ctx;
#pragma warning restore IDE0052

        public ComentarioRepository()
            {
            ctx = new HealthClinicContext();
            }

        public void Atualizar(Guid id, Comentario comentarioAtualizado)
            {
            try
                {
                Comentario comentario = BuscarPorId(id) ?? throw new Exception("Comentario não encontrada");

                comentario.Descricao = comentarioAtualizado.Descricao;
                comentario.IdConsulta = comentarioAtualizado.IdConsulta;
                comentario.Exibe = comentarioAtualizado.Exibe;

                ctx.Comentario.Update(comentario);
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Comentario BuscarPorId(Guid id)
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
                    }).FirstOrDefault(c => c.IdComentario == id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Comentario novoComentario)
            {
            try
                {
                ctx.Comentario.Add(novoComentario);
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
                ctx.Comentario.Remove(BuscarPorId(id));
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Comentario> Listar()
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
                    }).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }


