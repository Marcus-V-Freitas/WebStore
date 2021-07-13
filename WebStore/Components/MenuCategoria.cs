using DLL.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Components
{
    public class MenuCategoria : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public MenuCategoria(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.TodasCategorias.OrderBy(x => x.Nome);

            return View(categorias);
        }
    }
}
