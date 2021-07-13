using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.BLL.Services.Sessao;
using DLL.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClienteModel = DLL.BLL.Models.Cliente;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace WebStore.Areas.Cliente.Controllers
{
    [Area(nameof(Cliente))]
    [Route("Cliente/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly LoginCliente _loginCliente;
        private readonly IClienteRepository _clienteRepository;


        public HomeController(LoginCliente loginCliente, IClienteRepository clienteRepository)
        {
            _loginCliente = loginCliente;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ClienteModel cliente)
        {

            ClienteModel clienteDB = _clienteRepository.Login(cliente.Email, cliente.Senha);


            if (clienteDB != null)
            {
                _loginCliente.Login(clienteDB);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                ViewData["MSG_E"] = "Email não existe";
            }

            return View();
        }

        public RedirectToActionResult Logout()
        {
            _loginCliente.Logout();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
