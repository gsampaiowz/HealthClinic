using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;
using webapi_event__tarde.Utils;

namespace webapi_event__tarde.Repositories
    {
    public class UsuarioRepository : IUsuarioRepository
        {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, Usuario usuario)
            {
            Usuario usuarioBuscado = BuscarPorId(id);

            if (usuarioBuscado != null)
                {
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = Criptografia.GerarHash(usuario.Senha!);
                usuarioBuscado.IdTipoUsuario = usuario.IdTipoUsuario;

                _eventContext.Usuario.Update(usuarioBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public Usuario BuscarPorEmailESenha(string email, string senha)
            {
            try
                {
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                        {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TipoUsuario
                            {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                            }
                        }).FirstOrDefault(u => u.Email == email)!;

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
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                        {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,

                        IdTipoUsuario = u.IdTipoUsuario,

                        TipoUsuario = new TipoUsuario
                            {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                            }
                        }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Usuario usuario)
            {
            try
                {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Usuario.Add(usuario);

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
                _eventContext.Usuario.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
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
                return _eventContext.Usuario.Select(u => new Usuario
                    {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,

                    IdTipoUsuario = u.IdTipoUsuario,

                    TipoUsuario = new TipoUsuario
                        {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUsuario!.Titulo
                        }
                    }).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }

        //Método para listar as presenças de evento de um usuário
        public List<PresencaEvento> ListarMinhas(Guid id)
            {
            try
                {
                PresencaEvento presencaEvento = new();
                return _eventContext.PresencaEvento.Where(pe => pe.IdUsuario == id && pe.Situacao == true).Select(pe => new PresencaEvento
                    {
                    IdPresencaEvento = pe.IdPresencaEvento,
                    Situacao = pe.Situacao,

                    IdEvento = pe.IdEvento,

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
