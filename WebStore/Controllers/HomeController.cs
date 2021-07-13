using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.BLL.ViewModels;
using DLL.DAL.Repository.Database;
using DLL.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProdutoRepository _produtoRepository;


        public HomeController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                ProdutoAVenda = _produtoRepository.TodosProdutosVenda
            };

            return View(homeViewModel);
        }
    }
}
