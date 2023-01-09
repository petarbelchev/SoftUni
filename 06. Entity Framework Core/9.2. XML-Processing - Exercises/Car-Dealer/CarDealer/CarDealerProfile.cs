namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DTOs.Export;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Import
            CreateMap<ImpSupplierDTO, Supplier>();
            CreateMap<ImpPartDTO, Part>();
            CreateMap<ImpCarDTO, Car>();
            CreateMap<ImpCustomerDTO, Customer>();
            CreateMap<ImpSaleDTO, Sale>();

            //Export
            CreateMap<Car, ExpCarWithDistanceDTO>();
            CreateMap<Car, ExpBmwCarDTO>();
            CreateMap<Supplier, ExpLocalSupplierDTO>()
                .ForMember(d => d.PartsCount, mo => mo.MapFrom(s => s.Parts.Count));

            //Config for task 18
            CreateMap<Customer, ExpTotalSalesByCustomerDTO>()
                .ForMember(d => d.BoughtCars, mo => mo.MapFrom(s => s.Sales.Count))
                .ForMember(dto => dto.SpentMoney, obj => 
                    obj.MapFrom(c => c.Sales
                        .Select(s => s.Car.PartCars
                            .Select(pc => pc.Part.Price))
                        .SelectMany(x => x)
                        .Sum()));

            CreateMap<Car, ExpCarWithAttrDTO>();
            CreateMap<Sale, ExpSaleAppliedDiscountDTO>()
                .ForMember(d => d.CustomerName, mo => mo.MapFrom(s => s.Customer.Name))
                .ForMember(d => d.Price, mo => mo.MapFrom(s => s.Car.PartCars.Sum(pc => pc.Part.Price)))
                .ForMember(d => d.PriceWithDiscount, mo => 
                    mo.MapFrom(s => GetCarPriceWithDiscount(s.Car.PartCars.Sum(pc => pc.Part.Price), s.Discount)));
        }

        private static decimal GetCarPriceWithDiscount(decimal carPrice, decimal discount)
            => carPrice - (carPrice * (discount / 100));
    }
}
