﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
            app.MapPost("/{id}", HandleAsync)
            .WithName("Transactions: Delete")
            .WithSummary("Remove uma transação")
            .WithDescription("Remove uma transação")
            .WithOrder(2)
            .Produces<Response<Transaction?>>();


        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ITransactionHandler handler,long Id)
        {
            var request = new DeleteTransactionRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = Id
            };
            var result = await handler.DeleteAsync(request);

            return result.IsSuccess 
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}
