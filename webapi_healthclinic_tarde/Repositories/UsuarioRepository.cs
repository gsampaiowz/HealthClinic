using Microsoft.EntityFrameworkCore;
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
                usuario.Senha = usuarioAtualizado.Senha;
                usuario.IdTipoDeUsuario = usuarioAtualizado.IdTipoDeUsuario;

                ctx.Usuario.Update(usuario);
                ctx.SaveChanges();
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
                return ctx.Usuario.Include(u => u.IdTipoDeUsuarioNavigation).FirstOrDefault(c => c.IdUsuario == id)!;
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
                return ctx.Usuario.Include(u => u.IdTipoDeUsuarioNavigation).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
