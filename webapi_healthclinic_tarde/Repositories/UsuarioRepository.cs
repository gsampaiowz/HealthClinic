using Microsoft.EntityFrameworkCore;
using webapi_event__tarde.Utils;
using webapi_healthclinic_tarde.Contexts;
using webapi_healthclinic_tarde.Domains;
using webapi_healthclinic_tarde.Interfaces;

namespace webapi_healthclinic_tarde.Repositories
    {
    public class UsuarioRepository : IUsuarioRepository
        {
#pragma warning disable IDE0052
        private readonly HealthClinicContext ctx;
#pragma warning restore IDE0052

        public UsuarioRepository()
            {
            ctx = new HealthClinicContext();
            }

        public void Atualizar(Guid id, Usuario usuarioAtualizado)
            {
            try
                {
                Usuario usuario = BuscarPorId(id) ?? throw new Exception("Usuario não encontrada");

                usuario.NomeUsuario = usuarioAtualizado.NomeUsuario;
                usuario.Email = usuarioAtualizado.Email;
                usuario.Senha = Criptografia.GerarHash(usuarioAtualizado.Senha);
                usuario.IdTipoDeUsuario = usuarioAtualizado.IdTipoDeUsuario;

                ctx.Usuario.Update(usuario);
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Usuario BuscarPorEmailESenha(string email, string senha)
            {
            try
                {
                Usuario usuarioBuscado = ctx.Usuario
                    .Include(u => u.IdTipoDeUsuarioNavigation).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                    {
                    if (Criptografia.CompararHash(senha, usuarioBuscado.Senha!))
                        {
                        return usuarioBuscado;
                        }
                    return null!;
                    }
                return null!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Usuario BuscarPorId(Guid id)
            {
            try
                {
                return ctx.Usuario.Select(u => new Usuario
                    {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoDeUsuario = u.IdTipoDeUsuario,

                    IdTipoDeUsuarioNavigation = new TipoDeUsuario
                        {
                        IdTipoDeUsuario = u.IdTipoDeUsuario,
                        NomeTipoDeUsuario = u.IdTipoDeUsuarioNavigation!.NomeTipoDeUsuario
                        }

                    }).FirstOrDefault(c => c.IdUsuario == id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Usuario novoUsuario)
            {
            try
                {
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);
                ctx.Usuario.Add(novoUsuario);
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
                ctx.Usuario.Remove(BuscarPorId(id));
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Usuario> Listar()
            {
            try
                {
                return ctx.Usuario.Select(u => new Usuario
                    {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoDeUsuario = u.IdTipoDeUsuario,

                    IdTipoDeUsuarioNavigation = new TipoDeUsuario
                        {
                        IdTipoDeUsuario = u.IdTipoDeUsuarioNavigation!.IdTipoDeUsuario,
                        NomeTipoDeUsuario = u.IdTipoDeUsuarioNavigation!.NomeTipoDeUsuario
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
