﻿using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.CQRS;
using RestaurantSystemDataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetProductByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery()
            {
                ProductID = request.ProductID
            };
            var product = await this.queryExecutor.Execute(query);
            var mappedProduct = this.mapper.Map<Domain.Models.Product>(product);

            var response = new GetProductByIdResponse()
            {
                Data = mappedProduct
            };
            return response;
        }
    }
}
