using AutoMapper;
using RestaurantSystem.ApplicationServices.API.Domain;
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
            this.CreateMap<PutOrderRequest, RestaurantSystemDataAccess.Entities.Order>()
                .ForMember(x => x.ID, y => y.MapFrom(z => z.OrderID))
                .ForMember(x => x.EmployeeID, y => y.MapFrom(z => z.EmployeeID))
                .ForMember(x => x.RestaurantTableID, y => y.MapFrom(z => z.RestaurantTableID))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
            this.CreateMap<AddOrderRequest, RestaurantSystemDataAccess.Entities.Order>()
                .ForMember(x => x.EmployeeID, y => y.MapFrom(z => z.EmployeeID))
                .ForMember(x => x.RestaurantTableID, y => y.MapFrom(z => z.RestaurantTableID))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
            this.CreateMap<RestaurantSystemDataAccess.Entities.Order, Order>()
                .ForMember(x => x.ID, y => y.MapFrom(z => z.ID))
                .ForMember(x => x.EmployeeID, y => y.MapFrom(z => z.EmployeeID))
                .ForMember(x => x.RestaurantTableID, y => y.MapFrom(z => z.RestaurantTableID))
                .ForMember(x => x.OrderDate, y => y.MapFrom(z => z.OrderDate))
                .ForMember(x => x.TotalPriceNetto, y => y.MapFrom(z => z.TotalPriceNetto))
                .ForMember(x => x.TotalPriceBrutto, y => y.MapFrom(z => z.TotalPriceBrutto))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
    }
}
