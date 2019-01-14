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
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Dear user! Please, make your choice and press Enter...");
                Console.WriteLine("1 - Show the DildoShop.");
                Console.WriteLine("2 - Show the DollShop.");
                Console.WriteLine("3 - Add a new product.");
                Console.WriteLine("4 - Add a new shop.");
                Console.WriteLine("5 - Exit.");

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
                        AddShop();
                        break;
                    case "5":
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
        static void AddShop()
        {
            var shop = new Shop();
            shop.Address = new Address();
            Console.WriteLine("Enter a name of a new shop...");
            shop.Name = Console.ReadLine();
            Console.WriteLine($"Ok, now let's create the address for a new shop!");
            Console.WriteLine("Enter a contry name of the new shop address...");
            shop.Address.Country = Console.ReadLine();
            Console.WriteLine("Enter a city name of the new shop address...");
            shop.Address.City = Console.ReadLine();
            Console.WriteLine("Enter a street name of a new shop address...");
            shop.Address.Street = Console.ReadLine();
            Console.WriteLine("Enter a building number of a new shop address...");
            shop.Address.BuildingNumber = Int32.Parse(Console.ReadLine());
            using (var context = new ProductsContext())
            {                
                context.Shops.Add(shop);
                context.SaveChanges();
            }
        }

    }
}
