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
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            this.CreateMap<AddCategoryRequest, RestaurantSystemDataAccess.Entities.Category>()
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
            this.CreateMap<RestaurantSystemDataAccess.Entities.Category, Category>()
                .ForMember(x => x.ID, y => y.MapFrom(z => z.ID))
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.CategoryName))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));
        }
    }
}
