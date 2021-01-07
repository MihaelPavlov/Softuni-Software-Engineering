using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //01.Import Suppliers
            //var suppliersData = File.ReadAllText(@"..\..\..\Datasets\suppliers.json");
            //Console.WriteLine(ImportSuppliers(context,data));

            //02.Import Parts
            //var partsData = File.ReadAllText(@"..\..\..\Datasets\parts.json");
            //Console.WriteLine(ImportParts(context,data));

            //03.Import Cars 
            //var carData = File.ReadAllText(@"..\..\..\Datasets\cars.json");
            //Console.WriteLine(ImportCars(context,carData));

            //04.Import Customers
            //var customerData = File.ReadAllText(@"..\..\..\Datasets\customers.json");
            //Console.WriteLine(ImportCustomers(context,customerData));

            //05.Import Sales
            //var salesData = File.ReadAllText(@"..\..\..\Datasets\sales.json");
            //Console.WriteLine(ImportSales(context,salesData));

            //06.Export Ordered Customers
            //Console.WriteLine(GetOrderedCustomers(context));

            //07.Export Cars From Make Toyota
            //Console.WriteLine(GetCarsFromMakeToyota(context));

            //08.Export Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(context));

            //09.Export Cars with Their List of Parts
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //10.Export Total Sales By Customer
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //11.Export Sales With Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var importSuppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(importSuppliers);

            context.SaveChanges();

            return $"Successfully imported {importSuppliers.Count()}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var importParts = JsonConvert.DeserializeObject<List<Part>>(inputJson);
            var allSupplier = context.Suppliers;

            int count = 0;
            foreach (var item in importParts)
            {
                foreach (var supplier in allSupplier)
                {
                    if (item.SupplierId==supplier.Id)
                    {
                        context.Parts.Add(item);
                        count++;
                    }
                }
            }
     

            context.SaveChanges();

            return $"Successfully imported {count}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var importCars = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);

            foreach (var car in importCars)
            {
                var newCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                context.Cars.Add(newCar);
                foreach (var part in car.PartsId.Distinct())
                {
                    var newParts = new PartCar
                    {
                        PartId=part,
                        Car= newCar
                    };
                    context.PartCars.Add(newParts);
                }
            }
                context.SaveChanges();
            return $"Successfully imported {importCars.Count}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var importCutomers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(importCutomers);
            context.SaveChanges();
            return $"Successfully imported {importCutomers.Count}.";


        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var importSales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(importSales);
            context.SaveChanges();

            return $"Successfully imported {importSales.Count}.";

        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c=>c.IsYoungDriver)
                .Select(x=> new 
                {
                    x.Name,
                    BirthDate= x.BirthDate.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                    x.IsYoungDriver
                })
                .ToList();
           

            var toJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return toJson;
            
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c=> new 
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                
                })
                .ToList();

            var toJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return toJson;

        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var toJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return toJson;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(c => new
            {
                car= new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                },
                parts = c.PartCars.Select(ps => new
                {
                    ps.Part.Name,
                    Price = ps.Part.Price.ToString("F2")
                })
            }).ToList();

          
            var toJson = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return toJson;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {

            //Exception 
            var customers = context.Customers.Where(c => c.Sales.Count() > 0)
                .Select(c => new
                {
                    fullName = c.Sales.Select(s => s.Customer.Name).FirstOrDefault(),
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(s=>s.Car.PartCars.Sum(ps=>ps.Part.Price))
                })
                .OrderByDescending(c=>c.spentMoney)
                .OrderByDescending(c=>c.boughtCars)
                .ToList();

            var toJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return toJson;
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(s => new
            {
                car = new
                {
                    s.Car.Make,
                    s.Car.Model,
                    s.Car.TravelledDistance
                },
                customerName = s.Customer.Name,
                Discount= s.Discount.ToString("F2"),
                price = s.Car.PartCars.Sum(ps=>ps.Part.Price).ToString("F2"),
                priceWithDiscount = $"{s.Car.PartCars.Sum(ps =>ps.Part.Price) *(1 - s.Discount/100):F2}",
            }).Take(10).ToList();

            var toJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return toJson;
        }
    }
}