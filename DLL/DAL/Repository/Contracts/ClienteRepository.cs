using DLL.BLL.Models;
using DLL.DAL.Repository.Database;
using DLL.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL.DAL.Repository.Contracts
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly WebStoreContext _context;

        public ClienteRepository(WebStoreContext context)
        {
            _context = context;
        }

        public Cliente Login(string email, string senha)
        {
            return _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Email.Equals(email) && x.Senha.Equals(senha));
        }
    }
}
