using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            //Gravar no banco de dados

            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }


        public ContatoModel Atualizar(ContatoModel contato)
        {
            //Busca o dados

            ContatoModel contatoDb = ListarPorId(contato.Id);

            //valida contato
            if (contatoDb == null) 
            {
                throw new Exception($"Houve um erro na atualização do contato: {contato.Nome}");
            
            }
            //altera contato
            contatoDb.Nome = contato.Nome;
            contatoDb.Telefone = contato.Telefone;
            contatoDb.Email = contato.Email;

            //atualiza contato
            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();


            //retorna contato
            return contatoDb;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);


            if (contatoDb == null)
            {
                throw new Exception($"Houve um erro na exclusão do contato: {contatoDb.Nome}");
            }

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
