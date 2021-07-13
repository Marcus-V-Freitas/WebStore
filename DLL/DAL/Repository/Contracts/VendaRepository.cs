using DLL.BLL.Models;
using DLL.BLL.Services.Compras;
using DLL.BLL.Services.Sessao;
using DLL.DAL.Repository.Database;
using DLL.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.DAL.Repository.Contracts
{
    public class VendaRepository : IVendaRepository
    {

        private readonly WebStoreContext _context;
        private readonly CarrinhoCompras _carrinhoCompras;
        private readonly LoginCliente _loginCliente;

        public VendaRepository(WebStoreContext context, CarrinhoCompras carrinhoCompras, LoginCliente loginCliente)
        {
            _context = context;
            _carrinhoCompras = carrinhoCompras;
            _loginCliente = loginCliente;
        }

        public void CriarVenda(Venda venda)
        {
            venda.Horario = DateTime.Now;
            venda.Total = _carrinhoCompras.TotalCompra();
            venda.ClienteId = _loginCliente.GetCliente().ID;
            //venda.Cliente = _loginCliente.GetCliente();

            _context.Vendas.Add(venda);

            _context.SaveChanges();

            var ItemsVenda = _carrinhoCompras.TodosItemsCarrinho();
            foreach (var item in ItemsVenda)
            {
                var itemVenda = new ItemVenda()
                {
                    Quantidade = item.Quantidade,
                    Preço = item.Produto.Preço,
                    ProdutoId = item.Produto.ID,
                    VendaId = venda.Id
                };


                _context.ItemsVenda.Add(itemVenda);
            }

            _context.SaveChanges();
        }
    }
}
