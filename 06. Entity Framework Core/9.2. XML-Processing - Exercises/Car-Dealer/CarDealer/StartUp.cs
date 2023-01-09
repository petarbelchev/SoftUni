namespace CarDealer
{
    using Data;
    using Models;
    using DTOs.Export;
    using DTOs.Import;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                //Query 9. Import Suppliers
                //string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
                //Console.WriteLine(ImportSuppliers(context, inputXml));

                //Query 10. Import Parts
                //string inputXml2 = File.ReadAllText("../../../Datasets/parts.xml");
                //Console.WriteLine(ImportParts(context, inputXml2));

                //Query 11. Import Cars
                //string inputXml3 = File.ReadAllText("../../../Datasets/cars.xml");
                //Console.WriteLine(ImportCars(context, inputXml3));

                //Query 12. Import Customers
                //string inputXml = File.ReadAllText("../../../Datasets/customers.xml");
                //Console.WriteLine(ImportCustomers(context, inputXml));

                //Query 13. Import Sales
                //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");
                //Console.WriteLine(ImportSales(context, inputXml));

                //Query 14. Export Cars With Distance
                //string xmlString = GetCarsWithDistance(context);
                //XDocument xDocument = XDocument.Parse(xmlString);
                //using (var writer = new StreamWriter("../../../Results/cars.xml"))
                //{
                //    xDocument.Save(writer);
                //}

                //Query 15. Export Cars from make BMW
                //string xmlString = GetCarsFromMakeBmw(context);
                //XDocument xDocument = XDocument.Parse(xmlString);
                //using (var writer = new StreamWriter("../../../Results/bmw-cars.xml"))
                //{
                //    xDocument.Save(writer);
                //}

                //Query 16. Export Local Suppliers
                //string xmlString = GetLocalSuppliers(context);
                //XDocument xDocument = XDocument.Parse(xmlString);
                //using (var writer = new StreamWriter("../../../Results/local-suppliers.xml"))
                //{
                //    xDocument.Save(writer);
                //}

                //Query 17. Export Cars with Their List of Parts
                //string xmlString = GetCarsWithTheirListOfParts(context);
                //XDocument xDocument = XDocument.Parse(xmlString);
                //using (var writer = new StreamWriter("../../../Results/cars-and-parts.xml"))
                //{
                //    xDocument.Save(writer);
                //}

                //Query 18. Export Total Sales by Customer
                //string xmlString = GetTotalSalesByCustomer(context);
                //XDocument xDocument = XDocument.Parse(xmlString);
                //using (var writer = new StreamWriter("../../../Results/customers-total-sales.xml"))
                //{
                //    xDocument.Save(writer);
                //}

                //Query 19. Export Sales with Applied Discount
                string xmlString = GetSalesWithAppliedDiscount(context);
                XDocument xDocument = XDocument.Parse(xmlString);
                using (var writer = new StreamWriter("../../../Results/sales-discounts.xml"))
                {
                    xDocument.Save(writer);
                }
            }
        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ImpSupplierDTO[]), new XmlRootAttribute("Suppliers"));

            using var reader = new StringReader(inputXml);

            ImpSupplierDTO[] supplierDTOs = (ImpSupplierDTO[])xmlSerializer
                .Deserialize(reader);

            IMapper mapper = MapperProvider();

            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDTOs);

            context.Suppliers.AddRange(suppliers);
            int importedCount = context.SaveChanges();

            return $"Successfully imported {importedCount}";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ImpPartDTO[]), new XmlRootAttribute("Parts"));

            using var stringReader = new StringReader(inputXml);

            ImpPartDTO[] partDTOs = (ImpPartDTO[])xmlSerializer
                .Deserialize(stringReader);

            int[] suppliersIds = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            IMapper mapper = MapperProvider();

            Part[] parts = mapper.Map<Part[]>(partDTOs
                .Where(p => suppliersIds.Contains(p.SupplierId)));

            context.Parts.AddRange(parts);
            int importedCount = context.SaveChanges();

            return $"Successfully imported {importedCount}";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ImpCarDTO[]), new XmlRootAttribute("Cars"));

            using var stringReader = new StringReader(inputXml);

            ImpCarDTO[] carDTOs = (ImpCarDTO[])xmlSerializer.Deserialize(stringReader);

            IMapper mapper = MapperProvider();
            List<Car> cars = new List<Car>();

            foreach (ImpCarDTO carDTO in carDTOs)
            {
                Car car = mapper.Map<Car>(carDTO);

                int[] carPartsIds = carDTO.PartsIds
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                var carParts = new List<PartCar>();

                foreach (int partId in carPartsIds)
                {
                    carParts.Add(new PartCar
                    {
                        Car = car,
                        PartId = partId
                    });
                }

                car.PartCars = carParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ImpCustomerDTO[]), new XmlRootAttribute("Customers"));

            using var reader = new StringReader(inputXml);

            ImpCustomerDTO[] customerDTOs = (ImpCustomerDTO[])xmlSerializer
                .Deserialize(reader);

            IMapper mapper = MapperProvider();

            Customer[] customers = mapper.Map<Customer[]>(customerDTOs);

            context.Customers.AddRange(customers);
            int importedCount = context.SaveChanges();

            return $"Successfully imported {importedCount}";
        }

        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ImpSaleDTO[]), new XmlRootAttribute("Sales"));

            using var reader = new StringReader(inputXml);

            ImpSaleDTO[] saleDTOs = (ImpSaleDTO[])xmlSerializer
                .Deserialize(reader);

            int[] carIds = context.Cars.Select(c => c.Id).ToArray();

            IMapper mapper = MapperProvider();

            Sale[] sales = mapper.Map<Sale[]>(saleDTOs
                .Where(s => carIds.Contains(s.CarId)));

            context.Sales.AddRange(sales);
            int importedCount = context.SaveChanges();

            return $"Successfully imported {importedCount}";
        }

        //Query 14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExpCarWithDistanceDTO[] carWithDistanceDTOs = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExpCarWithDistanceDTO>(
                    new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>()))
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ExpCarWithDistanceDTO[]), new XmlRootAttribute("cars"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            using (var stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, carWithDistanceDTOs, xsn);
            }

            return sb.ToString().TrimEnd();
        }

        //Query 15. Export Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExpBmwCarDTO[] bmwCarDTOs = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExpBmwCarDTO>(
                    new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>()))
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ExpBmwCarDTO[]), new XmlRootAttribute("cars"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            using (var stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, bmwCarDTOs, xsn);
            }

            return sb.ToString().TrimEnd();
        }

        //Query 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExpLocalSupplierDTO[] localSupplierDTOs = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExpLocalSupplierDTO>(
                    new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>()))
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ExpLocalSupplierDTO[]), new XmlRootAttribute("suppliers"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            using (var stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, localSupplierDTOs, xsn);
            }

            return sb.ToString().Trim();
        }

        //Query 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExpCarWithPartsDTO[] carWithPartsDTOs = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExpCarWithPartsDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .OrderByDescending(p => p.Part.Price)
                        .Select(p => new ExpPartDTO
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .ToArray()
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ExpCarWithPartsDTO[]), new XmlRootAttribute("cars"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            using (var stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, carWithPartsDTOs, xsn);
            }

            return sb.ToString().TrimEnd();
        }

        //Query 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExpTotalSalesByCustomerDTO[] salesByCustomerDTOs = context.Customers
                .Where(c => c.Sales.Any())
                //--AutoMapper Approach--
                .ProjectTo<ExpTotalSalesByCustomerDTO>(
                    new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>()))
                //--ManuelMapping Approach--
                //.Select(c => new ExpTotalSalesByCustomerDTO
                //{
                //    Name = c.Name,
                //    BoughtCars = c.Sales.Count,
                //    SpentMoney = c.Sales
                //        .Select(sale => sale.Car.PartCars
                //            .Select(pc => pc.Part.Price))
                //        .SelectMany(x => x)
                //        .Sum()
                //})
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ExpTotalSalesByCustomerDTO[]), new XmlRootAttribute("customers"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            using (var strWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(strWriter, salesByCustomerDTOs, xsn);
            }

            return sb.ToString().TrimEnd();
        }

        //Query 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExpSaleAppliedDiscountDTO[] sales = context.Sales
                .ProjectTo<ExpSaleAppliedDiscountDTO>(
                    new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>()))
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ExpSaleAppliedDiscountDTO[]), new XmlRootAttribute("sales"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            using (var strWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(strWriter, sales, xsn);
            }

            return sb.ToString().TrimEnd();
        }

        private static IMapper MapperProvider()
        {
            var mapConfig = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            return new Mapper(mapConfig);
        }
    }
}