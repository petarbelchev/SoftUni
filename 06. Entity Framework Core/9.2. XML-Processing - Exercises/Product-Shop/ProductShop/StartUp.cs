namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using Data;
    using Dtos.Import;
    using Models;
    using Dtos.Export.Category;
    using Dtos.Export.User;
    using Dtos.Export;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new ProductShopContext())
            {
                //Query 1. Import Users
                //string inputXml = XDocument.Load("../../../Datasets/users.xml").ToString();
                //Console.WriteLine(ImportUsers(context, inputXml));

                //Query 2. Import Products
                //string inputXml = XDocument.Load("../../../Datasets/products.xml").ToString();
                //Console.WriteLine(ImportProducts(context, inputXml));

                //Query 3. Import Categories
                //string inputXml = XDocument.Load("../../../Datasets/categories.xml").ToString();
                //Console.WriteLine(ImportCategories(context, inputXml));

                //Query 4. Import Categories and Products
                //string inputXml = XDocument.Load("../../../Datasets/categories-products.xml").ToString();
                //Console.WriteLine(ImportCategoryProducts(context, inputXml));

                //Query 5. Export Products In Range
                //string xmlString = GetProductsInRange(context);
                //XDocument xDocument = XDocument.Parse(xmlString);
                //using (StreamWriter writer = new StreamWriter("../../../Results/products-in-range.xml"))
                //{
                //    xDocument.Save(writer);
                //}

                //Query 6. Export Sold Products
                //string xmlString = GetSoldProducts(context);
                //XDocument xDocument = XDocument.Parse(xmlString);
                //using (StreamWriter writer = new StreamWriter("../../../Results/users-sold-products.xml"))
                //{
                //    xDocument.Save(writer);
                //}

                //Query 7. Export Categories By Products Count
                //string xmlString = GetCategoriesByProductsCount(context);
                //XDocument xDocument = XDocument.Parse(xmlString);
                //using (StreamWriter writer = new StreamWriter("../../../Results/categories-by-products.xml"))
                //{
                //    xDocument.Save(writer);
                //}

                //Query 8. Export Users and Products
                string xmlString = GetUsersWithProducts(context);
                XDocument xDocument = XDocument.Parse(xmlString);
                using (StreamWriter writer = new StreamWriter("../../../Results/users-and-products.xml"))
                {
                    xDocument.Save(writer);
                }
            }
        }

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportUserDTO[]), new XmlRootAttribute("Users"));

            ImportUserDTO[] userDTOs = (ImportUserDTO[])serializer.Deserialize(
                new StringReader(inputXml));

            IMapper mapper = MapperProvider();

            User[] users = mapper.Map<User[]>(userDTOs);

            context.Users.AddRange(users);
            int importedUsersCount = context.SaveChanges();

            return $"Successfully imported {importedUsersCount}";
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(ImportProductDTO[]), new XmlRootAttribute("Products"));

            ImportProductDTO[] productDTOs = (ImportProductDTO[])serializer.Deserialize(
                new StringReader(inputXml));

            IMapper mapper = MapperProvider();

            Product[] products = mapper.Map<Product[]>(productDTOs);

            context.Products.AddRange(products);
            int importedProductsCount = context.SaveChanges();

            return $"Successfully imported {importedProductsCount}";
        }

        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDTO[]),
                new XmlRootAttribute("Categories"));

            ImportCategoryDTO[] categoryDTOs = (ImportCategoryDTO[])serializer.Deserialize(
                new StringReader(inputXml));

            IMapper mapper = MapperProvider();

            Category[] categories = mapper.Map<Category[]>(categoryDTOs);

            context.Categories.AddRange(categories);
            int importedCategoriesCount = context.SaveChanges();

            return $"Successfully imported {importedCategoriesCount}";
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDTO[]),
                new XmlRootAttribute("CategoryProducts"));

            ImportCategoryProductDTO[] categoryProductDTOs = (ImportCategoryProductDTO[])xmlSerializer
                .Deserialize(new StringReader(inputXml));

            IMapper mapper = MapperProvider();

            CategoryProduct[] categoryProducts = mapper
                .Map<CategoryProduct[]>(categoryProductDTOs);

            context.CategoryProducts.AddRange(categoryProducts);
            int importedCatProdCount = context.SaveChanges();

            return $"Successfully imported {importedCatProdCount}";
        }

        //Query 5. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductsInRangeDTO[] products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductsInRangeDTO>(
                    new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>()))
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductsInRangeDTO[]),
                new XmlRootAttribute("Products"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            StringWriter writer = new StringWriter();

            using (writer)
            {
                xmlSerializer.Serialize(writer, products, xsn);
            }

            return writer.ToString();
        }

        //Query 6. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExpUserSoldProdDTO[] userSoldProductsDTOs = context.Users
                .Where(u => u.ProductsSold.Any())
                .Include(u => u.ProductsSold)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.LastName)
                .Take(5)
                .ToArray()
                .Select(u => new ExpUserSoldProdDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new ExpSoldProdDTO
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ExpUserSoldProdDTO[]), new XmlRootAttribute("Users"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            StringWriter writer = new StringWriter();

            using (writer)
            {
                xmlSerializer.Serialize(writer, userSoldProductsDTOs, xsn);
            }

            return writer.ToString();
        }

        //Query 7. Export Categories By Products Count
        //NOTE: Judge want strange average price rouding
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoriesByProductsCountDTO[] categoriesByProductsCountDTOs = context.Categories
                .ProjectTo<ExportCategoriesByProductsCountDTO>(
                    new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>()))
                .OrderByDescending(c => c.Count)
                .ThenByDescending(c => c.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ExportCategoriesByProductsCountDTO[]),
                new XmlRootAttribute("Categories"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            StringWriter writer = new StringWriter();

            using (writer)
            {
                xmlSerializer.Serialize(writer, categoriesByProductsCountDTOs, xsn);
            }

            return writer.ToString();
        }

        //Query 8. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersProdsShortDTOs = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .ToArray() // One more ToArray() because of Judge! 
                .Select(u => new ExpUserSoldProdLongDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExpSoldProdLongDTO
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .OrderByDescending(p => p.Price)
                            .Select(p => new ExpSoldProdDTO
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToArray()
                    }
                })
                .ToArray();

            ExpUsersProdsDTO usersProdsLongDTO = new ExpUsersProdsDTO
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = usersProdsShortDTOs
            };

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ExpUsersProdsDTO), new XmlRootAttribute("Users"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            StringWriter stringWriter = new StringWriter();

            using (stringWriter)
            {
                xmlSerializer.Serialize(stringWriter, usersProdsLongDTO, xsn);
            }

            return stringWriter.ToString();
        }

        private static IMapper MapperProvider()
        {
            MapperConfiguration mapConfig = new MapperConfiguration(cfg =>
                cfg.AddProfile(typeof(ProductShopProfile)));

            return new Mapper(mapConfig);
        }
    }
}