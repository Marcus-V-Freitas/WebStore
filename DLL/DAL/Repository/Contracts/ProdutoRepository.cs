using DLL.BLL.Models;
using DLL.DAL.Repository.Database;
using DLL.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL.DAL.Repository.Contracts
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly WebStoreContext _context;

        public ProdutoRepository(WebStoreContext context)
        {
            _context = context;
        }


        public IEnumerable<Produto> TodosProdutos
        {
            get
            {
                return _context.Produtos.ToList();
            }
        }

        public IEnumerable<Produto> TodosProdutosVenda
        {
            get
            {
                return _context.Produtos.Where(x => x.AVenda.Equals(true));
            }
        }

        public Produto ProdutoPorId(int Id)
        {
            return _context.Produtos.FirstOrDefault(x => x.ID.Equals(Id));
        }
    }
}
