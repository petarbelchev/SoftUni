using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));

            using (var context = new CarDealerContext())
            {
                //Query 9. Import Suppliers
                //string inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
                //Console.WriteLine(ImportSuppliers(context, inputJson));

                //Query 10. Import Parts
                //string inputJson = File.ReadAllText("../../../Datasets/parts.json");
                //Console.WriteLine(ImportParts(context, inputJson));

                //Query 11. Import Cars
                //string inputJson = File.ReadAllText("../../../Datasets/cars.json");
                //Console.WriteLine(ImportCars(context, inputJson));

                //Query 12. Import Customers
                //string inputJson = File.ReadAllText("../../../Datasets/customers.json");
                //Console.WriteLine(ImportCustomers(context, inputJson));

                //Query 13. Import Sales
                //string inputJson = File.ReadAllText("../../../Datasets/sales.json");
                //Console.WriteLine(ImportSales(context, inputJson));

                //Query 14. Export Ordered Customers
                //File.WriteAllText("../../../Results/ordered-customers.json", GetOrderedCustomers(context));

                //Query 15. Export Cars from Make Toyota
                //File.WriteAllText("../../../Results/toyota-cars.json", GetCarsFromMakeToyota(context));

                //Query 16. Export Local Suppliers
                //File.WriteAllText("../../../Results/local-suppliers.json", GetLocalSuppliers(context));

                //Query 17. Export Cars with Their List of Parts
                //File.WriteAllText("../../../Results/cars-and-parts.json", GetCarsWithTheirListOfParts(context));

                //Query 18. Export Total Sales by Customer
                //File.WriteAllText("../../../Results/customers-total-sales.json", GetTotalSalesByCustomer(context));

                //Query 19. Export Sales with Applied Discount
                File.WriteAllText("../../../Results/sales-discounts.json", GetSalesWithAppliedDiscount(context));
            }
        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            SupplierDTO[] supplierDTOs = JsonConvert.DeserializeObject<SupplierDTO[]>(inputJson);

            Supplier[] suppliers = Mapper.Map<Supplier[]>(supplierDTOs);

            int importedCount = 0;

            foreach (var supplier in suppliers)
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
                importedCount++;
            }

            return $"Successfully imported {importedCount}.";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            PartDTO[] partDTOs = JsonConvert.DeserializeObject<PartDTO[]>(inputJson);

            Part[] parts = Mapper.Map<Part[]>(partDTOs);

            int[] suppliersIds = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            int importedCount = 0;

            foreach (var part in parts.Where(p => suppliersIds.Contains(p.SupplierId)))
            {
                context.Parts.Add(part);
                context.SaveChanges();
                importedCount++;
            }

            return $"Successfully imported {importedCount}.";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            CarDTO[] carDTOs = JsonConvert.DeserializeObject<CarDTO[]>(inputJson);

            int[] partIds = context.Parts
                .Select(p => p.Id)
                .ToArray();

            int importedCars = 0;
            List<PartCar> partCars = new List<PartCar>();

            foreach (CarDTO carDTO in carDTOs)
            {
                Car car = Mapper.Map<Car>(carDTO);
                context.Cars.Add(car);
                context.SaveChanges();
                importedCars++;

                foreach (int partId in carDTO.PartsId
                                                .Distinct()
                                                .Where(partId => partIds.Contains(partId)))
                {
                    partCars.Add(new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    });
                }
            }

            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {importedCars}.";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            CustomersDTO[] customersDTOs = JsonConvert.DeserializeObject<CustomersDTO[]>(inputJson);

            Customer[] customers = Mapper.Map<Customer[]>(customersDTOs);

            int importedCustomers = 0;

            foreach (Customer customer in customers)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                importedCustomers++;
            }

            return $"Successfully imported {importedCustomers}.";
        }

        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            SaleDTO[] saleDTOs = JsonConvert.DeserializeObject<SaleDTO[]>(inputJson);

            Sale[] sales = Mapper.Map<Sale[]>(saleDTOs);

            int importedSales = 0;

            foreach (Sale sale in sales)
            {
                context.Sales.Add(sale);
                context.SaveChanges();
                importedSales++;
            }

            return $"Successfully imported {importedSales}.";
        }

        //Query 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenByDescending(c => c.IsYoungDriver == false)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    c.IsYoungDriver
                })
                .ToArray();

            string output = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return output;
        }

        //Query 15. Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToArray();

            string output = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return output;
        }

        //Query 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            string output = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return output;
        }

        //Query 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars
                        .Select(p => new
                        {
                            p.Part.Name,
                            Price = $"{p.Part.Price:F2}"
                        })
                        .ToArray()
                })
            .ToArray();

            string output = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return output;
        }

        //Query 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales
                        .Select(c => c.Car.PartCars
                            .Select(p => p.Part.Price)
                            .Sum())
                        .Sum()
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            string output = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return output;
        }

        //Query 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new { s.Car.Make, s.Car.Model, s.Car.TravelledDistance },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Select(p => p.Part.Price).Sum().ToString():F2}",
                    priceWithDiscount = getPriceWithDiscount(s.Car.PartCars.Select(p => p.Part.Price).Sum(), s.Discount)
                })
                .ToArray();

            string output = JsonConvert.SerializeObject(sales, Formatting.Indented);
            
            return output;
        }

        private static string getPriceWithDiscount(decimal price, decimal discount)
            => $"{price - (price * (discount / 100)):F2}";
    }
}