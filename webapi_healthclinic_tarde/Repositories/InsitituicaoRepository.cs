using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;

namespace webapi_event__tarde.Repositories
    {
    public class InstituicaoRepository : IInstituicaoRepository
        {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, Instituicao instituicao)
            {
            Instituicao instituicaoBuscado = BuscarPorId(id);
                                                             
            if (instituicaoBuscado != null)
                {
                instituicaoBuscado.NomeFantasia = instituicao.NomeFantasia;
                instituicaoBuscado.CNPJ = instituicao.CNPJ;
                instituicaoBuscado.Endereco = instituicao.Endereco;

                _eventContext.Instituicao.Update(instituicaoBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public Instituicao BuscarPorId(Guid id)
            {
            try
                {
                return _eventContext.Instituicao.Find(id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Instituicao instituicao)
            {
            try
                {
                _eventContext.Instituicao.Add(instituicao);
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
                _eventContext.Instituicao.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Instituicao> Listar()
            {
            try
                {
                return _eventContext.Instituicao.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
