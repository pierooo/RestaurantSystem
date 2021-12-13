﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestaurantSystem.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(
                               this.ModelState
                                    .Where(x => x.Value.Errors.Any())
                                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }
            var response = await this.mediator.Send(request);
            if(response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }
            return this.Ok(response);
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode,errorModel);
        }

        private object GetHttpStatusCode(string error)
        {
            switch (error)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorType.Unautorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.UnSupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnSupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ErrorType.TooManyRequest:
                    return HttpStatusCode.TooManyRequests;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}
