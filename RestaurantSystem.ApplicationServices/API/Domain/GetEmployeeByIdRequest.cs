using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;

namespace RestaurantSystem.Controllers
{
    public class GetEmployeeByIdRequest : RequestBase, IRequest<GetEmployeeByIdResponse>
    {
        public int EmployeeID { get; set; }
    }
}