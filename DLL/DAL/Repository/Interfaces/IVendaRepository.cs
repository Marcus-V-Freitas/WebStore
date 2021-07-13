using DLL.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.DAL.Repository.Interfaces
{
    public interface IVendaRepository
    {
        void CriarVenda(Venda venda);
    }
}
