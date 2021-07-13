using DLL.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.BLL.ViewModels
{
    public class ProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }

        public string CategoriaAtual { get; set; }
    }
}
