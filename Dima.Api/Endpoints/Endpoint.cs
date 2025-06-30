using Dima.Api.Common.Api;
using Dima.Api.Endpoints.Apontamentos;
using Dima.Api.Endpoints.Categories;
using Dima.Api.Endpoints.Identity;
using Dima.Api.Endpoints.Locais;
using Dima.Api.Endpoints.Transactions;
using Dima.Api.Models;

namespace Dima.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app) 
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("v1/identity")
             .WithTags("Identity")
             .MapIdentityApi<User>();

            endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutEndpoint>()
            .MapEndpoint<GetRolesEndpoint>();


            endpoints.MapGroup("v1/categories")
                .WithTags("Categories")
                .RequireAuthorization()
                .MapEndpoint<CreateCategoryEndpoint>()
                .MapEndpoint<DeleteCategoryEndpoint>()
                .MapEndpoint<GetAllCategoriesEndpoint>()
                .MapEndpoint<GetCategoryByIdEndpoint>()
                .MapEndpoint<UpdateCategoryEndpoint>();

            endpoints.MapGroup("v1/transactions")
              .WithTags("Transactions")
              .RequireAuthorization()
              .MapEndpoint<CreateTransactionEndpoint>()
              .MapEndpoint<DeleteTransactionEndpoint>()
              .MapEndpoint<GetTransactionByPeriodEndpoint>()
              .MapEndpoint<GetTransactionByIdEndpoint>()
              .MapEndpoint<UpdateTransactionEndpoint>();

            endpoints.MapGroup("v1/Apontamento")
              .WithTags("Apontamentos")
              .RequireAuthorization()
              .MapEndpoint<CreateApontamentoEndpoint>()
              .MapEndpoint<GetAllApontamentosEndpoint>();

            endpoints.MapGroup("v1/Local")
              .WithTags("Locais")
              .RequireAuthorization()
              .MapEndpoint<CreateLocalEndpoint>()
              .MapEndpoint<GetAllLocaisEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
