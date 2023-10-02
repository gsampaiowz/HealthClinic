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
                return ctx.Paciente.Select(p => new Paciente
                    {
                    IdPaciente = p.IdPaciente,
                    Cpf = p.Cpf,
                    DataNascimento = p.DataNascimento,
                    Endereco = p.Endereco,
                    Rg = p.Rg,
                    Telefone = p.Telefone,
                    Cep = p.Cep,
                    IdUsuario = p.IdUsuario,

                    IdUsuarioNavigation = new Usuario
                        {
                        IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                        NomeUsuario = p.IdUsuarioNavigation.NomeUsuario,
                        }
                    }).FirstOrDefault(c => c.IdPaciente == id)!;
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
                return ctx.Paciente.Select(p => new Paciente
                    {
                    IdPaciente = p.IdPaciente,
                    Cpf = p.Cpf,
                    DataNascimento = p.DataNascimento,
                    Endereco = p.Endereco,
                    Rg = p.Rg,
                    Telefone = p.Telefone,
                    Cep = p.Cep,
                    IdUsuario = p.IdUsuario,

                    IdUsuarioNavigation = new Usuario
                        {
                        IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                        Email = p.IdUsuarioNavigation.Email,
                        Senha = p.IdUsuarioNavigation.Senha,
                        IdTipoDeUsuario = p.IdUsuarioNavigation.IdTipoDeUsuario,
                        }
                    }).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }

        // Lista todas as consultas referentes um determinado paciente
        public List<Consulta> PacienteConsultas(Guid id)
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
                    }).Where(c => c.IdPaciente == id).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
