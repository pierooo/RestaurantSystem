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
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            this.CreateMap<AddEmployeeRequest, RestaurantSystemDataAccess.Entities.Employee>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role))
                .ForMember(x => x.BirthDate, y => y.MapFrom(z => z.BirthDate))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.PostalCode))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber));

            this.CreateMap<RestaurantSystemDataAccess.Entities.Employee, Employee>()
                .ForMember(x => x.ID, y => y.MapFrom(z => z.ID))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role))
                .ForMember(x => x.BirthDate, y => y.MapFrom(z => z.BirthDate))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.Address))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.PostalCode))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber));
        }
    }
}
