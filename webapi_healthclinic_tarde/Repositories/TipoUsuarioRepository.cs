using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;

namespace webapi_event__tarde.Repositories
    {
    public class TipoUsuarioRepository : ITipoUsuarioRepository
        {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
            {
            TipoUsuario tipoUsuarioBuscado = BuscarPorId(id);

            if (tipoUsuarioBuscado != null)
                {
                tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;

                _eventContext.TipoUsuario.Update(tipoUsuarioBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public TipoUsuario BuscarPorId(Guid id)
            {
            try
                {
                return _eventContext.TipoUsuario.Find(id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(TipoUsuario tipoUsuario)
            {
            try
                {
                _eventContext.TipoUsuario.Add(tipoUsuario);
                _eventContext.SaveChanges();
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
                _eventContext.TipoUsuario.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<TipoUsuario> Listar()
            {
            try
                {
                return _eventContext.TipoUsuario.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
