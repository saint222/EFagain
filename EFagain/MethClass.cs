using EFagain;
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
                Console.WriteLine("1 - Show the DildoShop.");
                Console.WriteLine("2 - Show the DollShop.");
                Console.WriteLine("3 - Add a new product.");
                Console.WriteLine("4 - Add a new shop.");
                Console.WriteLine("5 - Buy a product");
                Console.WriteLine("6 - Change a shop name");    
                Console.WriteLine("7 - Change quantity of the products");
                Console.WriteLine("8 - Exit.");

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
                        BuyProducts();
                        break;
                    case "6":
                        ChangeShopName();
                        break;
                    case "7":
                        ChangeProductQuantity();
                        break;
                    case "8":
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
                //var shop = context.Shops.FirstOrDefault(1); // альтернативный вариант
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
                //var shop = context.Shops.FirstOrDefault(1); // альтернативный вариант
                var shop = context.Shops.Find(2); // возможный вариант с методом Find ()
                Console.WriteLine($"Here is the {shop.Name}, situated in {shop.Address.Country}, {shop.Address.City}, {shop.Address.Street} and it's building number is {shop.Address.BuildingNumber}.");
                Console.WriteLine($"The products from the {shop.Name} and their quantity are:");
                foreach (var prod in shop.Products)
                {
                    Console.WriteLine($"{prod.Name}-{prod.Quantity} pieces;");
                }
            }

        }
        public void AddProduct()
        {
            var product = new Product();
            Console.WriteLine("Enter a name of a new product...");
            product.Name = Console.ReadLine();
            var correct = false;
            while (!correct)
            {
                Console.WriteLine("Enter quantity of a new product...");
                var quantity = 0;
                var result = Console.ReadLine();
                var unnessValue = int.TryParse(result, out quantity);
                if (quantity != 0)
                {
                    product.Quantity = quantity;
                    using (var context = new ProductsContext())
                    {
                        Console.WriteLine("Choose a shop for a new product...");

                        foreach (var shop in context.Shops)
                        {
                            Console.WriteLine($"{shop.ID}-{shop.Name};");
                        }
                        var shopId = 0;
                        var result_1 = Console.ReadLine();
                        var unnessVal = int.TryParse(result_1, out shopId);
                        if (shopId != 0)
                        {
                            var shop = context.Shops.Find(shopId);
                            if (shop != null)
                            {
                                shop.Products.Add(product);
                                context.SaveChanges();
                                correct = true;
                            }
                            else
                            {
                                Console.WriteLine("There is no shop with such Id, try again!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input, try again!");
                            correct = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input, try again!");
                    correct = false;
                }
            }
        }
        public void AddShop()
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
            var correct = false;
            while (!correct)
            {
                Console.WriteLine("Enter a building number of a new shop address...");
                var buildingNumber = 0;
                var result = Console.ReadLine();
                var unnessValue = int.TryParse(result, out buildingNumber);
                if (buildingNumber != 0)
                {
                    shop.Address.BuildingNumber = buildingNumber;
                    using (var context = new ProductsContext())
                    {
                        context.Shops.Add(shop);
                        context.SaveChanges();
                        correct = true;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input, try again!");
                    correct = false;
                }
            }
        }


        public void BuyProducts()
        {
            using (var context = new ProductsContext())
            {
                var correct = false;
                while (!correct)
                {
                    Console.WriteLine("Choose a shop to buy product you want, press Enter and wait for some seconds......");
                    foreach (var shop in context.Shops)
                    {
                        Console.WriteLine($"{shop.ID}-{shop.Name};");
                    }
                    var shopId = 0;
                    var result = Console.ReadLine();
                    var nnnesValue = int.TryParse(result, out shopId);
                    if (shopId != 0)
                    {
                        var shop = context.Shops.Find(shopId);
                        if (shop != null)
                        {
                            Console.WriteLine($"The products from the chosen shop and their quantity are:");
                            foreach (var prod in shop.Products)
                            {
                                Console.WriteLine($"{prod.ID} - {prod.Name}-{prod.Quantity} pieces;");
                            }
                            correct = true;
                        }
                        else
                        {
                            Console.WriteLine("There is no shop with such Id, try again!");
                            correct = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, try again!");
                        correct = false;
                    }
                }
                var correct_1 = false;
                while (!correct_1)
                {
                    Console.WriteLine("Choose a product to buy and press Enter...");
                    var productId = 0;
                    var result = Console.ReadLine();
                    var unnessValue = int.TryParse(result, out productId);
                    if (productId != 0)
                    {
                        var product = context.Products.Find(productId);

                        if (product != null)
                        {
                            Console.WriteLine("How many pieces would you like to buy?");
                            var choice = 0;
                            var result_1 = Console.ReadLine();
                            var unnessValue_1 = int.TryParse(result_1, out choice);
                            if (choice != 0)
                            {
                                if (choice <= product.Quantity)
                                {
                                    product.Quantity = product.Quantity - choice;
                                    context.SaveChanges();
                                    correct_1 = true;
                                }

                                else
                                {
                                    Console.WriteLine("There are no so many products at the stock, sorry...");
                                    correct_1 = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input, trrrrrrrrrray again!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no a product with such Id, try again, please!");
                            correct_1 = false;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Incorrect choice...");
                        correct_1 = false;
                    }
                }
            }
        }


        public void ChangeProductQuantity()
        {
            using (var context = new ProductsContext())
            {
                var correct = false;
                while (!correct)
                {
                    Console.WriteLine("Choose a shop to change product quantity, press Enter and wait for some seconds...");
                    foreach (var shop in context.Shops)
                    {
                        Console.WriteLine($"{shop.ID}-{shop.Name};");
                    }
                    var shopId = 0;
                    var result = Console.ReadLine();
                    var unnesValue = int.TryParse(result, out shopId);
                    if (shopId != 0)
                    {
                        var shop = context.Shops.Find(shopId);
                        if (shop != null)
                        {
                            Console.WriteLine($"The products from the chosen shop and their quantity are:");
                            foreach (var prod in shop.Products)
                            {
                                Console.WriteLine($"{prod.ID} - {prod.Name}-{prod.Quantity} pieces;");
                            }
                            correct = true;
                        }
                        else
                        {
                            Console.WriteLine("Fuck...there is no shop with such Id, try again!");
                            correct = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input of the shop, try again!");
                        correct = false;
                    }
                }
                var correct_2 = false;
                while (!correct_2)
                {
                    Console.WriteLine("Make a choice of a product to change it's quantity and press Enter...");
                    var productId = 0;
                    var result_1 = Console.ReadLine();
                    var unnesValue_2 = int.TryParse(result_1, out productId);
                    if (productId != 0)
                    {
                        var product = context.Products.Find(productId);
                        if (product != null)
                        {
                            Console.WriteLine("How many pieces of the chosen product are expected to be?");
                            var choice = Int32.Parse(Console.ReadLine());
                            product.Quantity = choice;
                            Console.WriteLine("Done...");
                            context.SaveChanges();
                            correct_2 = true;
                        }
                        else
                        {
                            Console.WriteLine("Fuck...there is no shop with such Id, try again!");
                            correct_2 = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, try again, please!");
                        correct_2 = false;
                    }
                }
            }
        }

        public void ChangeShopName()
        {
            var correct = false;
            while (!correct)
            {
                using (var context = new ProductsContext())
                {
                    Console.WriteLine("Choose a shop to shange it' name and press Enter.");
                    foreach (var shopVar in context.Shops)
                    {
                        Console.WriteLine($"{shopVar.ID} - {shopVar.Name};");
                    }
                }

                using (var context = new ProductsContext())
                {
                    var shopId = 0;
                    var result = Console.ReadLine();
                    var unnessValue = int.TryParse(result, out shopId);
                    if (shopId != 0)
                    {
                        var shop = context.Shops.Find(shopId);
                        if (shop != null)
                        {
                            Console.WriteLine("What a new name for the chosen shop?");
                            var newName = Console.ReadLine();                            
                            shop.Name = newName;
                            context.SaveChanges();
                            Console.WriteLine("Done!");
                            correct = true;
                        }
                        else
                        {
                            Console.WriteLine("There is no shop with such Id, try again!");
                            correct = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                        correct = false;
                    }
                }

            }         


        }

    }
}










