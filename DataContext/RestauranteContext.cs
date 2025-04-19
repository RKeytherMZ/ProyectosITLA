using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Proyect_Restaurante.Models;

namespace Proyect_Restaurante.DataContext
{
    public class RestauranteContext : DbContext
    {
       
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Orden> Ordens { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        public RestauranteContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8A66KAE\\SQLEXPRESS01;Database=RestauranteDB;Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=True");

        }
    }
}

