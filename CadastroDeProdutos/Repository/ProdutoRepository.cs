using CadastroDeProdutos.Data;
using CadastroDeProdutos.Models;
using System.Xml.Linq;

namespace CadastroDeProdutos.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        

        private readonly BancoContext _bancoContext;
        private IWebHostEnvironment _env;
        public ProdutoRepository(BancoContext bancoContext, IWebHostEnvironment env)
        {
            _bancoContext = bancoContext;
            _env = env;
        }
        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            if (produto.Upload != null)
            {
                produto.imageFileName = produto.Upload.FileName;
                var file = Path.Combine
                    (_env.ContentRootPath
                    , "wwwroot/images"
                    , produto.Upload.FileName);

                using (var filestream = new FileStream(file, FileMode.Create))
                {
                    produto.Upload.CopyTo(filestream);
                }
            }

            produto.imageFile = produto.imageFileName;
            produto.dataInsercao = DateTime.Now;
            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();
            return produto;
        }

        public bool Apagar(int id)
        {
            ProdutoModel produtoDB = PegarPeloId(id);

            if (produtoDB == null) throw new System.Exception("Erro na deleção do produto");

            _bancoContext.Produtos.Remove(produtoDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel produtoDB = PegarPeloId(produto.Id);

            if (produtoDB == null) throw new System.Exception("Erro na atualização do produto");
            if (produto.Upload != null)
            {
                produto.imageFileName = produto.Upload.FileName;
                var file = Path.Combine
                    (_env.ContentRootPath
                    , "wwwroot/images"
                    , produto.Upload.FileName);

                using (var filestream = new FileStream(file, FileMode.Create))
                {
                    produto.Upload.CopyTo(filestream);
                }
            }

            produtoDB.nome = produto.nome;
            produtoDB.preço = produto.preço;
            produtoDB.quantidade = produto.quantidade;
            produtoDB.imageFileName = produto.imageFileName;
            produtoDB.imageFile = produto.imageFileName;

            _bancoContext.Produtos.Update(produtoDB);
            _bancoContext.SaveChanges();

            return produtoDB;

        }

        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produtos.ToList();
        }

        public ProdutoModel PegarPeloId(int id)
        {
            return _bancoContext.Produtos.FirstOrDefault(x => x.Id == id);
       }
    }
}
