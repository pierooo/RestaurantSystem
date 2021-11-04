using AutoMapper;
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
            this.CreateMap<RestaurantSystemDataAccess.Entities.OrderDetails, OrderDetails>()
                .ForMember(x => x.Order, y => y.MapFrom(z => z.Order.ID))
                .ForMember(x => x.Product, y => y.MapFrom(z => z.Product.ID))
                .ForMember(x => x.UnitPrice, y => y.MapFrom(z => z.UnitPrice))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));
        }
    }
}
