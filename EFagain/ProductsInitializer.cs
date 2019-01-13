using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFagain
{
    public class ProductsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductsContext>
    {
        protected override void Seed(ProductsContext context)
        {
            var dildoProduct = new List<Product>
            {
                new Product { Name = "BigPinkDildo", Quantity = 10},
                new Product { Name = "MidRedDildo", Quantity = 7},
                new Product { Name = "LittleWhiteDildo", Quantity = 5},
                new Product { Name = "HugeBlackDildo", Quantity = 3},
                new Product { Name = "SuperHugeYellowVibroDildo", Quantity = 1}
            };
            var dildoShopAddress = new Address { Country = "USA", City = "NewYork", Street = "Thompson Street", BuildingNumber = 42 };
            var dildoShop = new Shop { Name = "DildoShop", Products = dildoProduct, Address = dildoShopAddress};


            var dollProduct = new List<Product>
            {
                new Product {Name = "MollyDoll", Quantity = 10},
                new Product { Name = "SandraDoll", Quantity = 7},
                new Product { Name = "MonikaDoll", Quantity = 5},
                new Product { Name = "LucyDoll", Quantity = 3},
                new Product { Name = "AnnDoll", Quantity = 1}
            };
            var dollShopAddress = new Address { Country = "China", City = " Shanghai ", Street = "YauMaTei", BuildingNumber = 11 };
            var dollShop = new Shop { Name = "DollShop", Products = dollProduct, Address = dollShopAddress };
            context.Shops.Add(dildoShop);
            context.Shops.Add(dollShop);
            context.SaveChanges();
        }
    }
}
