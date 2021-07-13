using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.BLL.Services.Compras;
using DLL.BLL.ViewModels;
using DLL.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.Controllers
{
    public class CarrinhoComprasController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoCompras _carrinhoCompras;


        public CarrinhoComprasController(IProdutoRepository produtoRepository, CarrinhoCompras carrinhoCompras)
        {
            _produtoRepository = produtoRepository;
            _carrinhoCompras = carrinhoCompras;
        }

        public IActionResult Index()
        {
            _carrinhoCompras.ItensCarrinho = _carrinhoCompras.TodosItemsCarrinho();

            var carrinhoComprasViewModel = new CarrinhoComprasViewModel()
            {
                CarrinhoCompras = _carrinhoCompras,
                TotalCompra = _carrinhoCompras.TotalCompra()
            };

            return View(carrinhoComprasViewModel);
        }


        public RedirectToActionResult AdicionarNoCarrinho(int Id)
        {
            var produtoSelecionado = _produtoRepository.TodosProdutos.FirstOrDefault(x => x.ID.Equals(Id));

            if (produtoSelecionado != null)
            {
                _carrinhoCompras.AdicionarCarrinho(produtoSelecionado, 1);
            }
            return RedirectToAction(nameof(Index));

        }


        public RedirectToActionResult RemoverNoCarrinho(int Id)
        {
            var produtoSelecionado = _produtoRepository.TodosProdutos.FirstOrDefault(x => x.ID.Equals(Id));

            if (produtoSelecionado != null)
            {
                _carrinhoCompras.RemoverCarrinho(produtoSelecionado);
            }
            return RedirectToAction(nameof(Index));
        }

        public RedirectToActionResult LimparCarrinho()
        {

            _carrinhoCompras.LimparCarrinho();
            return RedirectToAction(nameof(Index));
        }





    }
}
