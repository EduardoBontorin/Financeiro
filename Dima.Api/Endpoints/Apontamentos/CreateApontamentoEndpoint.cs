using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Apontamento;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Apontamentos
{
    public class CreateApontamentoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
            app.MapPost("/", HandleAsync)
            .WithName("Apontamentos: Create")
            .WithSummary("Cria um novo apontamento de produção")
            .WithDescription("Cria um novo apontamento de produção")
            .WithOrder(1)
            .Produces<Response<Apontamento>>();
            

        private static async Task<IResult> HandleAsync(IApontamentoHandler handler,CreateApontamentoRequest request,ClaimsPrincipal user) 
        {      
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? Results.Created($"/{result.Data?.Id}", result) : Results.BadRequest(result);
        }
        
    }
}
