using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;

namespace webapi_event__tarde.Repositories
    {
    public class EventoRepository : IEventoRepository
        {
        private readonly EventContext _eventContext;

        public EventoRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, Evento evento)
            {
            Evento eventoBuscado = BuscarPorId(id);

            if (eventoBuscado != null)
                {
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.IdInstituicao = evento.IdInstituicao;
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                eventoBuscado.NomeEvento = evento.NomeEvento;

                _eventContext.Evento.Update(eventoBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public Evento BuscarPorId(Guid id)
            {
            try
                {
                return _eventContext.Evento.Select(e => new Evento
                    {
                    IdEvento = e.IdEvento,
                    NomeEvento = e.NomeEvento,
                    Descricao = e.Descricao,
                    DataEvento = e.DataEvento,

                    IdInstituicao = e.IdInstituicao,
                    IdTipoEvento = e.IdTipoEvento,

                    Instituicao = new Instituicao
                        {
                        IdInstituicao = e.IdInstituicao,
                        NomeFantasia = e.Instituicao!.NomeFantasia,
                        Endereco = e.Instituicao.Endereco,
                        CNPJ = e.Instituicao.CNPJ,
                        },

                    TipoEvento = new TipoEvento
                        {
                        IdTipoEvento = e.IdTipoEvento,
                        Titulo = e.TipoEvento!.Titulo
                        }
                    }).FirstOrDefault(e => e.IdEvento == id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Evento evento)
            {
            try
                {
                _eventContext.Evento.Add(evento);
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
                _eventContext.Evento.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Evento> Listar()
            {
            try
                {
                return _eventContext.Evento.Select(e => new Evento
                    {
                    IdEvento = e.IdEvento,
                    NomeEvento = e.NomeEvento,
                    Descricao = e.Descricao,
                    DataEvento = e.DataEvento,

                    IdInstituicao = e.IdInstituicao,
                    IdTipoEvento = e.IdTipoEvento,

                    Instituicao = new Instituicao
                        {
                        IdInstituicao = e.IdInstituicao,
                        NomeFantasia = e.Instituicao!.NomeFantasia,
                        Endereco = e.Instituicao.Endereco,
                        CNPJ = e.Instituicao.CNPJ,
                        },

                    TipoEvento = new TipoEvento
                        {
                        IdTipoEvento = e.IdTipoEvento,
                        Titulo = e.TipoEvento!.Titulo
                        }
                    }).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }

        //Método para listar os comentários de um determinado evento
        public List<ComentarioEvento> ListarComentariosEvento(Guid id)
            {
            try
                {
                return _eventContext.ComentarioEvento.Where(ce => ce.IdEvento == id).Select(ce => new ComentarioEvento
                    {
                    IdComentarioEvento = ce.IdComentarioEvento,
                    Texto = ce.Texto,
                    Exibe = ce.Exibe,

                    IdEvento = ce.IdEvento,

                    Evento = new Evento
                        {
                        IdEvento = ce.IdEvento,
                        NomeEvento = ce.Evento!.NomeEvento,
                        Descricao = ce.Evento.Descricao,
                        DataEvento = ce.Evento.DataEvento,

                        IdInstituicao = ce.Evento.IdInstituicao,
                        IdTipoEvento = ce.Evento.IdTipoEvento,

                        Instituicao = new Instituicao
                            {
                            IdInstituicao = ce.Evento.IdInstituicao,
                            NomeFantasia = ce.Evento.Instituicao!.NomeFantasia,
                            Endereco = ce.Evento.Instituicao.Endereco,
                            CNPJ = ce.Evento.Instituicao.CNPJ,
                            },

                        TipoEvento = new TipoEvento
                            {
                            IdTipoEvento = ce.Evento.IdTipoEvento,
                            Titulo = ce.Evento.TipoEvento!.Titulo
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
