using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Apontamento;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Apontamentos
{
    public class GetAllApontamentosEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
          app.MapGet("/", HandleAsync)
          .WithName("Apontamentos: Get All")
          .WithSummary("Recupera todas os apontamentos")
          .WithDescription("Recupera todos os apontamentos com paginação")
          .WithOrder(2)
          .Produces<PagedResponse<Apontamento?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
             IApontamentoHandler handler,
             [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
             [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {

            var request = new GetAllApontamentosRequest
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
