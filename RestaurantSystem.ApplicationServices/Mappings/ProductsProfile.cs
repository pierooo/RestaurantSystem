﻿using AutoMapper;
using RestaurantSystem.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.Mappings
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            this.CreateMap<RestaurantSystemDataAccess.Entities.Product, Product>()
            .ForMember(x => x.ProductName, y => y.MapFrom(z => z.ProductName))
            .ForMember(x => x.Category, y => y.MapFrom(z => z.Category.CategoryName))
            .ForMember(x => x.UnitPrice, y => y.MapFrom(z => z.UnitPrice))
            .ForMember(x => x.UnitsInStock, y => y.MapFrom(z => z.UnitsInStock))
            .ForMember(x => x.Discontinued, y => y.MapFrom(z => z.Discontinued));

        }

    }
}
