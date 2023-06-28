using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Laboratorio14.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
