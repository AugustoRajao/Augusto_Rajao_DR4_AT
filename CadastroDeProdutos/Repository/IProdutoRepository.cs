using CadastroDeProdutos.Models;

namespace CadastroDeProdutos.Repository
{
    public interface IProdutoRepository
    {
        ProdutoModel PegarPeloId(int id);
        List<ProdutoModel> BuscarTodos();
        ProdutoModel Adicionar(ProdutoModel produto);
        ProdutoModel Atualizar(ProdutoModel produto);

        bool Apagar(int id);
    }
}
