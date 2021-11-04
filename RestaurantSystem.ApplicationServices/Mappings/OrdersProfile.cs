using AutoMapper;
using RestaurantSystem.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.Mappings
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            this.CreateMap<RestaurantSystemDataAccess.Entities.Order, Order>()
                .ForMember(x => x.ID, y => y.MapFrom(z => z.ID))
                .ForMember(x => x.Employee, y => y.MapFrom(z => z.Employee.FirstName))
                .ForMember(x => x.RestaurantTable, y => y.MapFrom(z => z.RestaurantTable.ID))
                .ForMember(x => x.OrderDate, y => y.MapFrom(z => z.OrderDate))
                .ForMember(x => x.TotalPrice, y => y.MapFrom(z => z.TotalPrice))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
    }
}
