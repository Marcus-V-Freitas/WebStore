using DLL.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.BLL.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produto> ProdutoAVenda { get; set; }
    }
}
