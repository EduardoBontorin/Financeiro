using Dima.Core.Models;
using Dima.Core.Requests.Local;
using Dima.Core.Responses;
using System.Net.Http.Json;
using System.Net.Http;
using Dima.Core.Handlers;
using Dima.Core.Requests.Apontamento;

namespace Dima.Web.Handlers
{
    public class ApontamentoHandler(IHttpClientFactory httpClientFactory) : IApontamentoHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

        public async Task<Response<Apontamento?>> CreateAsync(CreateApontamentoRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/apontamentos", request);
            return await result.Content.ReadFromJsonAsync<Response<Apontamento?>>() ?? new Response<Apontamento?>(null, 400, "Falha ao criar local");
        }

        public Task<Response<Apontamento?>> DeleteAsync(DeleteApontamentoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<Apontamento>?>> GetAllAsync(GetAllApontamentosRequest request)
        {
            return await _client.GetFromJsonAsync<PagedResponse<List<Apontamento>?>>("v1/apontamentos") ?? new PagedResponse<List<Apontamento>?>(null, 400, "Falha ao Obter lista de locais");
        }

        public Task<Response<Apontamento?>> UpdateAsync(UpdateApontamentoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
