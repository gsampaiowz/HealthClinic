using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;

namespace webapi_event__tarde.Repositories
    {
    public class PresencaEventoRepository : IPresencaEventoRepository
        {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, PresencaEvento presencaEvento)
            {
            PresencaEvento presencaEventoBuscado = BuscarPorId(id);

            if (presencaEventoBuscado != null)
                {
                presencaEventoBuscado.Situacao = presencaEvento.Situacao;
                presencaEventoBuscado.IdEvento = presencaEvento.IdEvento;
                presencaEventoBuscado.IdUsuario = presencaEvento.IdUsuario;

                _eventContext.PresencaEvento.Update(presencaEventoBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public PresencaEvento BuscarPorId(Guid id)
            {
            try
                {
                return _eventContext.PresencaEvento.Select(pe => new PresencaEvento
                    {
                    IdPresencaEvento = pe.IdPresencaEvento,
                    Situacao = pe.Situacao,

                    IdUsuario = pe.IdUsuario,
                    IdEvento = pe.IdEvento,

                    Usuario = new Usuario
                        {
                        IdUsuario = pe.Usuario!.IdUsuario,
                        Nome = pe.Usuario!.Nome,
                        Email = pe.Usuario!.Email
                        },

                    Evento = new Evento
                        {
                        IdEvento = pe.Evento!.IdEvento,
                        NomeEvento = pe.Evento!.NomeEvento,
                        DataEvento = pe.Evento!.DataEvento,
                        Descricao = pe.Evento!.Descricao,

                        IdInstituicao = pe.Evento!.IdInstituicao,
                        IdTipoEvento = pe.Evento!.IdTipoEvento,

                        Instituicao = new Instituicao
                            {
                            IdInstituicao = pe.Evento!.Instituicao!.IdInstituicao,
                            NomeFantasia = pe.Evento!.Instituicao!.NomeFantasia,
                            Endereco = pe.Evento!.Instituicao!.Endereco,
                            CNPJ = pe.Evento!.Instituicao!.CNPJ,
                            },

                        TipoEvento = new TipoEvento
                            {
                            IdTipoEvento = pe.Evento!.TipoEvento!.IdTipoEvento,
                            Titulo = pe.Evento!.TipoEvento!.Titulo
                            }
                        }
                    }).FirstOrDefault(pe => pe.IdPresencaEvento == id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(PresencaEvento presencaEvento)
            {
            try
                {
                _eventContext.PresencaEvento.Add(presencaEvento);
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
                _eventContext.PresencaEvento.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<PresencaEvento> Listar()
            {
            try
                {
                return _eventContext.PresencaEvento.Select(pe => new PresencaEvento
                    {
                    IdPresencaEvento = pe.IdPresencaEvento,
                    Situacao = pe.Situacao,

                    IdUsuario = pe.IdUsuario,
                    IdEvento = pe.IdEvento,

                    Usuario = new Usuario
                        {
                        IdUsuario = pe.Usuario!.IdUsuario,
                        Nome = pe.Usuario!.Nome,
                        Email = pe.Usuario!.Email
                        },

                    Evento = new Evento
                        {
                        IdEvento = pe.Evento!.IdEvento,
                        NomeEvento = pe.Evento!.NomeEvento,
                        DataEvento = pe.Evento!.DataEvento,
                        Descricao = pe.Evento!.Descricao,

                        IdInstituicao = pe.Evento!.IdInstituicao,
                        IdTipoEvento = pe.Evento!.IdTipoEvento,

                        Instituicao = new Instituicao
                            {
                            IdInstituicao = pe.Evento!.Instituicao!.IdInstituicao,
                            NomeFantasia = pe.Evento!.Instituicao!.NomeFantasia,
                            Endereco = pe.Evento!.Instituicao!.Endereco,
                            CNPJ = pe.Evento!.Instituicao!.CNPJ,
                            },

                        TipoEvento = new TipoEvento
                            {
                            IdTipoEvento = pe.Evento!.TipoEvento!.IdTipoEvento,
                            Titulo = pe.Evento!.TipoEvento!.Titulo
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
