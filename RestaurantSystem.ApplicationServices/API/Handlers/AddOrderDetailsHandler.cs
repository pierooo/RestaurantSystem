using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.ErrorHandling;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.CQRS;
using RestaurantSystemDataAccess.CQRS.Commands;
using RestaurantSystemDataAccess.CQRS.Queries;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Handlers
{
    public class AddOrderDetailsHandler : IRequestHandler<AddOrderDetailsRequest, AddOrderDetailsResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddOrderDetailsHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<AddOrderDetailsResponse> Handle(AddOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var queryProduct = new GetProductByIdQuery()
            {
                ID = request.ProductID
            };
            var product = await this.queryExecutor.Execute(queryProduct);

            var queryOrder = new GetOrderByIdQuery()
            {
                ID = request.OrderID
            };
            var order = await this.queryExecutor.Execute(queryOrder);
            if(product != null && order != null)
            {
                order.TotalPriceNetto += ((decimal)request.Quantity * product.UnitPriceNetto);
                order.TotalPriceBrutto += ((decimal)request.Quantity * (product.UnitPriceNetto * ((decimal)1 + (product.VAT / (decimal)100))));             
                var command1 = new PutOrderCommand() { Parameter = order };
                var orderDetails = this.mapper.Map<OrderDetails>(request);
                orderDetails.UnitPriceNetto = product.UnitPriceNetto;
                orderDetails.VAT = product.VAT;
                var command2 = new AddOrderDetailsCommad() { Parameter = orderDetails };
                try
                {
                    await this.commandExecutor.Execute(command1);
                    var orderDetailsFromDb = await this.commandExecutor.Execute(command2);
                    return new AddOrderDetailsResponse()
                    {
                        Data = this.mapper.Map<Domain.Models.OrderDetails>(orderDetailsFromDb)
                    };
                }catch
                {
                    return new AddOrderDetailsResponse()
                    {
                        Error = new ErrorModel(ErrorType.TooManyRequest)
                    };
                }
            }
            else
            {
                return new AddOrderDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.ValidationError)
                };
            }

            
        }
    }
}
