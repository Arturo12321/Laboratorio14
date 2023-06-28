using Laboratorio14.Models;
using Laboratorio14.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laboratorio14.ViewModels
{
    public class ViewModelProducts : BaseViewModel
    {
        private string name;
        public String Name
        {
            get { return name; }
            set { SetValue(ref this.name, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetValue(ref this.description, value);}
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { SetValue(ref this.productId, value);}
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set { SetValue(ref this.price, value); }
        }

        private DateTime fechaVencimiento;
        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { SetValue(ref this.fechaVencimiento, value); }

        }
        private List<Product> products;
        public List<Product> Products
        {
            get { return this.products; }
            set { SetValue(ref this.products, value); }
        }

        private Product product;
        public Product Product
        {
            get { return this.product; }
            set { SetValue(ref this.product, value); }
        }
        public ICommand SearchCommand { get; set; }
        public ICommand InsertCommand { get; set; }

        public ICommand SelectOneCommand { get; set; }


        public ViewModelProducts()
        {
            ProductService service = new ProductService();
            Products = service.Get();

            SearchCommand = new Command(() =>
            {
                ProductService service = new ProductService();
                Products = service.Get();
            });

            InsertCommand = new Command(() =>
            {
                ProductService service = new ProductService();
                if (ProductId != 0)
                {
                    Console.WriteLine(ProductId);

                    FirstName = "";
                    LastName = "";
                    IdPerson = 0;
                }
                else
                {
                    int newPersonId = service.Get().Count + 1;
                    service.Create(new Person { FirstName = FirstName, LastName = LastName, PersonId = newPersonId });
                    FirstName = "";
                    LastName = "";
                }
                People = service.Get();
            });

            SelectOneCommand = new Command<int>(execute: (int parameter) =>
            {
                PersonService service = new PersonService();
                int ide = parameter;
                Person = service.GetById(ide);
                FirstName = Person.FirstName;
                LastName = Person.LastName;
                IdPerson = Person.PersonId;
                //Console.WriteLine(IdPerson);
            });

            
        }


    }
}
