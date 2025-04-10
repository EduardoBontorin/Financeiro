using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions
{
    public class GetTransactionByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
            app.MapGet("/{id}", HandleAsync)
            .WithName("Transactions: GetById")
            .WithSummary("Obtem uma transação")
            .WithDescription("Obtem uma transação")
            .WithOrder(3)
            .Produces<Response<Transaction?>>();


        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ITransactionHandler handler,long Id)
        {
            var request = new GetTransactionByIdRequest
            {
                Id = Id,
                UserId = user.Identity?.Name ?? string.Empty
            };
           
            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}
