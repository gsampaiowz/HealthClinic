using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;

namespace webapi_event__tarde.Repositories
    {
    public class ComentarioEventoRepository : IComentarioEventoRepository
        {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, ComentarioEvento comentarioEvento)
            {
            ComentarioEvento comentarioEventoBuscado = BuscarPorId(id);

            if (comentarioEventoBuscado != null)
                {
                comentarioEventoBuscado.Texto = comentarioEvento.Texto;
                comentarioEventoBuscado.Exibe = comentarioEvento.Exibe;
                comentarioEventoBuscado.IdUsuario = comentarioEvento.IdUsuario;
                comentarioEventoBuscado.IdEvento = comentarioEvento.IdEvento;

                _eventContext.ComentarioEvento.Update(comentarioEventoBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public ComentarioEvento BuscarPorId(Guid id)
            {
            try
                {
                return _eventContext.ComentarioEvento.Select(ce => new ComentarioEvento
                    {
                    IdComentarioEvento = ce.IdComentarioEvento,
                    Texto = ce.Texto,
                    Exibe = ce.Exibe,

                    IdEvento = ce.IdEvento,

                    Evento = new Evento
                        {
                        IdEvento = ce.Evento!.IdEvento,
                        NomeEvento = ce.Evento!.NomeEvento,
                        DataEvento = ce.Evento!.DataEvento,
                        Descricao = ce.Evento!.Descricao,

                        IdInstituicao = ce.Evento!.IdInstituicao,
                        IdTipoEvento = ce.Evento!.IdTipoEvento,

                        Instituicao = new Instituicao
                            {
                            IdInstituicao = ce.Evento!.Instituicao!.IdInstituicao,
                            NomeFantasia = ce.Evento!.Instituicao!.NomeFantasia,
                            Endereco = ce.Evento!.Instituicao!.Endereco,
                            CNPJ = ce.Evento!.Instituicao!.CNPJ,
                            },

                        TipoEvento = new TipoEvento
                            {
                            IdTipoEvento = ce.Evento!.TipoEvento!.IdTipoEvento,
                            Titulo = ce.Evento!.TipoEvento!.Titulo
                            }
                        },

                    Usuario = new Usuario
                        {
                        IdUsuario = ce.IdUsuario,
                        Nome = ce.Usuario!.Nome,
                        Email = ce.Usuario!.Email
                        }
                    }).FirstOrDefault(ce => ce.IdComentarioEvento == id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(ComentarioEvento comentarioEvento)
            {
            try
                {
                _eventContext.ComentarioEvento.Add(comentarioEvento);
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
                _eventContext.ComentarioEvento.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<ComentarioEvento> Listar()
            {
            try
                {
                return _eventContext.ComentarioEvento.Select(ce => new ComentarioEvento
                    {
                    IdComentarioEvento = ce.IdComentarioEvento,
                    Texto = ce.Texto,
                    Exibe = ce.Exibe,

                    IdEvento = ce.IdEvento,

                    Evento = new Evento
                        {
                        IdEvento = ce.Evento!.IdEvento,
                        NomeEvento = ce.Evento!.NomeEvento,
                        DataEvento = ce.Evento!.DataEvento,
                        Descricao = ce.Evento!.Descricao,

                        IdInstituicao = ce.Evento!.IdInstituicao,
                        IdTipoEvento = ce.Evento!.IdTipoEvento,

                        Instituicao = new Instituicao
                            {
                            IdInstituicao = ce.Evento!.Instituicao!.IdInstituicao,
                            NomeFantasia = ce.Evento!.Instituicao!.NomeFantasia,
                            Endereco = ce.Evento!.Instituicao!.Endereco,
                            CNPJ = ce.Evento!.Instituicao!.CNPJ,
                            },

                        TipoEvento = new TipoEvento
                            {
                            IdTipoEvento = ce.Evento!.TipoEvento!.IdTipoEvento,
                            Titulo = ce.Evento!.TipoEvento!.Titulo
                            }
                        },

                    Usuario = new Usuario
                        {
                        IdUsuario = ce.IdUsuario,
                        Nome = ce.Usuario!.Nome,
                        Email = ce.Usuario!.Email
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
