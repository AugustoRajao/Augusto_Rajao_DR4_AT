using CadastroDeProdutos.Models;
using CadastroDeProdutos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;

        }
        public IActionResult Index()
        {

            List<ProdutoModel> produtos = _produtoRepository.BuscarTodos();
            var listaOrdenada = produtos.OrderBy(produto => produto.dataInsercao).ToList();

            return View(listaOrdenada);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepository.PegarPeloId(id);
            return View(produto);
        }
        public IActionResult ApagarValidacao(int id)
        {
            ProdutoModel produto = _produtoRepository.PegarPeloId(id);
            return View(produto);
        }
        public IActionResult Apagar(int id)
        {
            _produtoRepository.Apagar(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Adicionar(ProdutoModel produto)
        {
            _produtoRepository.Adicionar(produto);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(ProdutoModel produto)
        {
            _produtoRepository.Atualizar(produto);
            return RedirectToAction("Index");
        }
    }
}
