using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
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

            if (User.Claims.FirstOrDefault() != null)
            {
                (request as RequestBase).AuthenticationName = this.User.FindFirstValue(ClaimTypes.Name);
                (request as RequestBase).AuthenticationRole = this.User.FindFirstValue(ClaimTypes.Role);
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

        private static HttpStatusCode GetHttpStatusCode(string error)
        {
            return error switch
            {
                ErrorType.NotFound => HttpStatusCode.NotFound,
                ErrorType.InternalServerError => HttpStatusCode.InternalServerError,
                ErrorType.Unautorized => HttpStatusCode.Unauthorized,
                ErrorType.RequestTooLarge => HttpStatusCode.RequestEntityTooLarge,
                ErrorType.UnSupportedMediaType => HttpStatusCode.UnsupportedMediaType,
                ErrorType.UnSupportedMethod => HttpStatusCode.MethodNotAllowed,
                ErrorType.TooManyRequest => HttpStatusCode.TooManyRequests,
                _ => HttpStatusCode.BadRequest,
            };
        }
    }
}
