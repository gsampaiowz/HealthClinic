using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;

namespace webapi_event__tarde.Repositories
    {
    public class TipoEventoRepository : ITipoEventoRepository
        {
        private readonly EventContext _eventContext;

        public TipoEventoRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, TipoEvento tipoEvento)
            {
            TipoEvento tipoEventoBuscado = BuscarPorId(id);

            if (tipoEventoBuscado != null)
                {
                tipoEventoBuscado.Titulo = tipoEvento.Titulo;

                _eventContext.TipoEvento.Update(tipoEventoBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public TipoEvento BuscarPorId(Guid id)
            {
            try
                {
                return _eventContext.TipoEvento.Find(id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(TipoEvento tipoEvento)
            {
            try
                {
                _eventContext.TipoEvento.Add(tipoEvento);
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
                _eventContext.TipoEvento.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<TipoEvento> Listar()
            {
            try
                {
                return _eventContext.TipoEvento.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
