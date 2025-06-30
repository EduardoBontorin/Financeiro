using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Local;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Locais
{
    public class GetAllLocaisEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
          app.MapGet("/", HandleAsync)
          .WithName("Locais: Get All")
          .WithSummary("Recupera todos os Locais")
          .WithDescription("Recupera todos os Locais")
          .WithOrder(4)
          .Produces<PagedResponse<Category?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
             ILocalHandler handler,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {

            var request = new GetAllLocaisRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            // Aqui poderia passar outros parametros

            var result = await handler.GetAllAsync(request);

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}
