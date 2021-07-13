using DLL.BLL.Models;
using DLL.BLL.Services.Sessao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.DAL.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Cliente Login(string email, string senha);
    }
}
