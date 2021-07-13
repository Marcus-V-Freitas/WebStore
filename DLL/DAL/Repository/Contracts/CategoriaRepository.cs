using DLL.BLL.Models;
using DLL.DAL.Repository.Database;
using DLL.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL.DAL.Repository.Contracts
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly WebStoreContext _context;


        public CategoriaRepository(WebStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> TodasCategorias
        {
            get
            {
                return _context.Categorias.ToList();
            }
        }
    }
}
