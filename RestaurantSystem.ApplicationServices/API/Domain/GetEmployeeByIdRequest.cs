using MediatR;

namespace RestaurantSystem.Controllers
{
    public class GetEmployeeByIdRequest : IRequest<GetEmployeeByIdResponse>
    {
        public int EmployeeID { get; set; }
    }
}