using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Local;
using Dima.Core.Responses;
using System.Net.Http.Json;

namespace Dima.Web.Handlers
{
    public class LocalHandler(IHttpClientFactory httpClientFactory) : ILocalHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Local?>> CreateAsync(CreateLocalRequest request)
        {
            var result =await _client.PostAsJsonAsync("v1/locais", request);
            return await result.Content.ReadFromJsonAsync<Response<Local?>>() ?? new Response<Local?>(null, 400, "Falha ao criar local");
        }

        public Task<Response<Local?>> DeleteAsync(DeleteLocalRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<Local>?>> GetAllAsync(GetAllLocaisRequest request)
        {
            return await _client.GetFromJsonAsync<PagedResponse<List<Local>?>>("v1/locais") ?? new PagedResponse<List<Local>?>(null, 400, "Falha ao Obter lista de locais");
        }

        public Task<Response<Local?>> UpdateAsync(UpdateLocalRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
