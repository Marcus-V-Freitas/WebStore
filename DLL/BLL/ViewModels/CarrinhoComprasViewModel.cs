using DLL.BLL.Services.Compras;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.BLL.ViewModels
{
   public class CarrinhoComprasViewModel
    {
        public CarrinhoCompras CarrinhoCompras { get; set; }

        public decimal TotalCompra { get; set; }
    }

}
