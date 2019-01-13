using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFagain
{
    public class MethClass

    {
        public void Menu()
        {
            var exit = false;
            while (!exit)
            {
                Console.WriteLine("Dear user! Please, make your choice and press Enter...");
                Console.WriteLine("1 - Show DildoShop");
                Console.WriteLine("2 - Show DollShop");
                Console.WriteLine("3 - Add New Product");
                Console.WriteLine("4 - Exit");

                var answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        AboutDildoShop();
                        break;
                    case "2":
                        AboutDollShop();
                        break;
                        case "3":
                        AddProduct();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("wrong input");
                        break;
                }
            }
            Console.ReadLine();
        }


        public void AboutDildoShop()
        {
            using (var context = new ProductsContext())
            {
                //var shop = context.Shops.FirstOrDefault(); // альтернативный вариант
                var shop = context.Shops.Find(1); // возможный вариант с методом Find ()
                Console.WriteLine($"Here is the {shop.Name}, situated in {shop.Address.Country}, {shop.Address.City}, {shop.Address.Street} and it's building number is {shop.Address.BuildingNumber}.");
                Console.WriteLine($"The products from the {shop.Name} and their quantity are:");
                foreach (var prod in shop.Products)
                {
                    Console.WriteLine($"{prod.Name}-{prod.Quantity} pieces;");
                }
            }

        }
        public void AboutDollShop()
        {
            using (var context = new ProductsContext())
            {
                //var shop = context.Shops.FirstOrDefault(); // альтернативный вариант
                var shop = context.Shops.Find(2); // возможный вариант с методом Find ()
                Console.WriteLine($"Here is the {shop.Name}, situated in {shop.Address.Country}, {shop.Address.City}, {shop.Address.Street} and it's building number is {shop.Address.BuildingNumber}.");
                Console.WriteLine($"The products from the {shop.Name} and their quantity are:");
                foreach (var prod in shop.Products)
                {
                    Console.WriteLine($"{prod.Name}-{prod.Quantity} pieces;");
                }
            }

        }
        static void AddProduct()
        {
            var product = new Product();
            Console.WriteLine("Enter a name of a new product...");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter quantity of a new product...");
            product.Quantity = int.Parse(Console.ReadLine());
            
            using (var context = new ProductsContext())
            {
                Console.WriteLine("Press 1 or 2 for choosing the shop for a new product...");
                
                foreach (var shop in context.Shops)
                {
                    Console.WriteLine($"{shop.ID}-{shop.Name};");
                }
                var shopId = Int32.Parse(Console.ReadLine());
                if (shopId != 0)
                {
                    var shop = context.Shops.Find(shopId);
                    if (shop != null)
                    {
                        shop.Products.Add(product);
                    }
                    context.SaveChanges();
                }
                else
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }

            }
        }

    }
}
