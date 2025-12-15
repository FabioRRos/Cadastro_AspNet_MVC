using ControleDeContatos.Models;

namespace ControleDeContatos.Repository
{
    public interface IContatoRepository
    {
        bool Apagar(int id);
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

    }
}
