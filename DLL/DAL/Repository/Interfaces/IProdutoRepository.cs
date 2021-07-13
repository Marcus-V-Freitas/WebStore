using DLL.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.DAL.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> TodosProdutos { get; }

        IEnumerable<Produto> TodosProdutosVenda { get; }

        Produto ProdutoPorId(int Id);
    }
}
