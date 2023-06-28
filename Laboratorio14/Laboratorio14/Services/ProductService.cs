using Laboratorio14.DataContext;
using Laboratorio14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio14.Services
{
    internal class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService() => _context = App.GetContext();

        public bool Create(Product item)
        {
            try
            {
                _context.Products.Add(item);
                _context.SaveChanges();
                return true;    
            }
            catch (Exception) {
                return false;
            }
        }

        public bool CreateRange(List<Product> items)
        {
            try
            {
                _context.Products.AddRange(items);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Product> Get()
        {
            return _context.Products.ToList();
        }


        public List<Product> GetByText(string text)
        {
            return _context.Products.Where(x => x.Name.Contains(text) || x.Description.Contains(text)).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

 
  
    }
}
