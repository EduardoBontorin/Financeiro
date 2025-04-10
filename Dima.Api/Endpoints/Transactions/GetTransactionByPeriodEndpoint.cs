using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions
{
    public class GetTransactionByPeriodEndpoint : IEndpoint
    {

        public static void Map(IEndpointRouteBuilder app) =>
            app.MapGet("/", HandleAsync)
            .WithName("Transactions: GetByPeriod")
            .WithSummary("Obtem transações a partir de um período")
            .WithDescription("Obtem transações a partir de um período")
            .WithOrder(4)
            .Produces<PagedResponse<List<Transaction>?>>();


        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ITransactionHandler handler,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int pageSize = Configuration.DefaultPageSize, 
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber)
        {
            var request = new GetTransactionsByPeriodRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                StartDate = startDate,
                EndDate = endDate,
                PageSize = pageSize,
                PageNumber = pageNumber
            };

            var result = await handler.GetByPeriodAsync(request);

            return result.IsSuccess ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}

