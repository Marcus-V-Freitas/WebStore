using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DLL.BLL.Models
{
    public class Venda
    {

        public int Id { get; set; }

        [Display(Name = "Detalhes da Compra")]
        public List<ItemVenda> itemsVenda { get; set; }


        [BindNever]
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }


        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime Horario { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
