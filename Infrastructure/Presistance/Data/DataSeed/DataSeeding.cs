using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistance.Data.DataSeed
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        void IDataSeeding.DataSeeding()
        {
            //to make migration automatically
           if (_dbContext.Database.GetPendingMigrations().Any())
           {
                _dbContext.Database.Migrate();
            }


            //Data Seeding for ProductBrands
            if (!_dbContext.ProductBrands.Any())
            {
                var BrandsData = File.ReadAllText("../Infrastructure/Presistance/Data/DataSeed/Brands.json");
                var Brands = JsonSerializer.Deserialize<List<DomainLayer.Models.ProductBrand>>(BrandsData);
                if (Brands is not null && Brands.Any())
                {
                    _dbContext.ProductBrands.AddRange(Brands);
                   
                }
             
            }
            //Data Seeding for ProductTypes
            if (!_dbContext.ProductTypes.Any())
            {
                var TypeData = File.ReadAllText("../Infrastructure/Presistance/Data/DataSeed/types.json");
                var Type = JsonSerializer.Deserialize<List<DomainLayer.Models.ProductType>>(TypeData);
                if (Type is not null && Type.Any())
                {
                    _dbContext.ProductTypes.AddRange(Type);
                    
                }
            }
            //Data Seeding for Products
            if (!_dbContext.Products.Any())
            {

                var ProductData = File.ReadAllText("../Infrastructure/Presistance/Data/DataSeed/products.json");
                var Product = JsonSerializer.Deserialize<List<DomainLayer.Models.Product>>(ProductData);
                if (Product is not null && Product.Any())
                {
                    _dbContext.Products.AddRange(Product);
                    
                }
            }

            _dbContext.SaveChanges();

        }
    }
}
