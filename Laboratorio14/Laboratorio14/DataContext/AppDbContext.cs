using Laboratorio14.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio14.DataContext
{
    public class AppDbContext : DbContext
    {
        string DbPath = string.Empty;

        public DbSet<Product> Products { get; set; }

        public AppDbContext(string dbPath)
        {
            this.DbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }
    }
}
