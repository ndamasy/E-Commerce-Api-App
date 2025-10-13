using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Data
{
    public class StoreDbContext(DbContextOptions<StoreDbContext> options):DbContext(options)
    {
        #region Db Sets
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductBrand> ProductBrands { get; set; } = null!;
        public DbSet<ProductType> ProductTypes { get; set; } = null!;
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
