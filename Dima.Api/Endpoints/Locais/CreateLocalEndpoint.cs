using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Apontamento;
using Dima.Core.Requests.Local;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Locais
{
    public class CreateLocalEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
          app.MapPost("/", HandleAsync)
          .WithName("Local: Create")
          .WithSummary("Cria um novo Local de produção")
          .WithDescription("Cria um novo Local de produção")
          .WithOrder(3)
          .Produces<Response<Local>>();


        private static async Task<IResult> HandleAsync(ILocalHandler handler, CreateLocalRequest request, ClaimsPrincipal user)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? Results.Created($"/{result.Data?.Id}", result) : Results.BadRequest(result);
        }
    }
}
