using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.BLL.Models;
using DLL.BLL.ViewModels;
using DLL.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult ListaProdutos(string categoria)
        {


            IEnumerable<Produto> produtos;
            string categoriaAtual;

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = _produtoRepository.TodosProdutos.OrderBy(x => x.ID);
                categoriaAtual = "Todos Produtos";
            }
            else
            {
                produtos = _produtoRepository.TodosProdutos.Where(x => x.Categoria.Nome.Equals(categoria));
                categoriaAtual = _categoriaRepository.TodasCategorias.FirstOrDefault(x => x.Nome.Equals(categoria))?.Nome;
            }

            return View(new ProdutoViewModel { Produtos = produtos, CategoriaAtual = categoriaAtual });
        }

        public IActionResult Detalhes(int Id)
        {
            var produto = _produtoRepository.ProdutoPorId(Id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }
    }
}
