﻿using AutoMapper;
using RestaurantSystem.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.Mappings
{
    public class RestaurantTablesProfile : Profile
    {
        public RestaurantTablesProfile()
        {
            this.CreateMap<RestaurantSystemDataAccess.Entities.RestaurantTable, RestaurantTable>()
                .ForMember(x => x.ID, y => y.MapFrom(z => z.ID))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
    }
}