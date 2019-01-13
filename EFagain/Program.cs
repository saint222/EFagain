using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFagain
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ProductsContext())
            {
                var shop = context.Shops.Where(x => x.ID == 1);
                var address = context.Addresses.FirstOrDefault();
                var products = context.Products;
                foreach (Shop i in shop)
                {
                    Console.WriteLine($"Here is the {i.Name}, situated in {i.Address.Country}, {i.Address.City}, {i.Address.Street} and it's building number is {i.Address.BuildingNumber}.");
                }
                
                foreach (var prod in products)
                {
                    Console.WriteLine($"{prod.Name}-{prod.Quantity} pieces;");
                }


            }
            Console.ReadLine();
        }
    }
}
