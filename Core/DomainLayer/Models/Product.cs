using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Product:BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = null!;
        #region product Brand
        public int BrandId { get; set; } //fk
        public ProductBrand ProductBrand { get; set; } = null!;

        #endregion
        #region product Type
        public int TypeId { get; set; } //fk
        public ProductBrand ProductType { get; set; } = null!;

        #endregion


    }
}
