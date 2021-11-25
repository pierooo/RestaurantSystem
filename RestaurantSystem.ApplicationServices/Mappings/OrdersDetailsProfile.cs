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
    public class OrdersDetailsProfile : Profile
    {
        public OrdersDetailsProfile()
        {
            this.CreateMap<PutOrderDetailsRequest, RestaurantSystemDataAccess.Entities.OrderDetails>()
                .ForMember(x => x.ID, y => y.MapFrom(z => z.OrderDetailsID))
                .ForMember(x => x.OrderID, y => y.MapFrom(z => z.OrderID))
                .ForMember(x => x.ProductID, y => y.MapFrom(z => z.ProductID))
                .ForMember(x => x.UnitPrice, y => y.MapFrom(z => z.UnitPrice))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));
            this.CreateMap<AddOrderDetailsRequest, RestaurantSystemDataAccess.Entities.OrderDetails>()
                .ForMember(x => x.OrderID, y => y.MapFrom(z => z.OrderID))
                .ForMember(x => x.ProductID, y => y.MapFrom(z => z.ProductID))
                .ForMember(x => x.UnitPrice, y => y.MapFrom(z => z.UnitPrice))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));
            this.CreateMap<RestaurantSystemDataAccess.Entities.OrderDetails, OrderDetails>()
                .ForMember(x => x.OrderID, y => y.MapFrom(z => z.OrderID))
                .ForMember(x => x.ProductID, y => y.MapFrom(z => z.ProductID))
                .ForMember(x => x.UnitPrice, y => y.MapFrom(z => z.UnitPrice))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));
        }
    }
}
