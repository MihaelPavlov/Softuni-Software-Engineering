using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //01.Import Users
            //var data = File.ReadAllText(@"..\..\..\Datasets\users.json");
            //Console.WriteLine(ImportUsers(context, data));

            //02.Import Products 
            //var products = File.ReadAllText(@"..\..\..\Datasets\products.json");
            //Console.WriteLine(ImportProducts(context, products));

            //03.Import Categories
            //var categories = File.ReadAllText(@"..\..\..\Datasets\categories.json");
            //Console.WriteLine(ImportCategories(context, categories));

            //04.Import Categories And Products
            //var categoriesAndProductShop = File.ReadAllText(@"..\..\..\Datasets\categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesAndProductShop));

            //05.Export Products In Range
            //Console.WriteLine(GetProductsInRange(context));

            //06.Export Sold Products
            //Console.WriteLine(GetSoldProducts(context));

            //07.Export Categories by Products Count
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //08.Export Users And Products 
            Console.WriteLine(GetUsersWithProducts(context));




        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";

        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            int count = 0;
            foreach (var category in categories)
            {
                if (category.Name != null)
                {
                    context.Categories.Add(category);
                    count++;
                }
            }
            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToList();

            var jsonFormat = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return jsonFormat;

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Count() >= 1 && u.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName
                    })
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToList();

            var convertToJson = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

            return convertToJson;


        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
                });


            var convertToJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return convertToJson;


        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users.AsEnumerable()
                .Where(x => x.ProductsSold.Count() >= 1 && x.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(p => p.ProductsSold.Count(c => c.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count(b => b.Buyer != null),
                        products = x.ProductsSold
                                        .Where(ps => ps.Buyer != null)
                                        .Select(ps => new
                                        {
                                            name = ps.Name,
                                            price = ps.Price
                                        })
                                            .ToList()
                    }
                })
                .ToList();


            var usersWithCount = new
            {
                usersCount = users.Count(),
                users = users
            };


            var convertToJson = JsonConvert.SerializeObject(usersWithCount, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return convertToJson;
        }
    }
}
