using Dima.Core.Models;
using Dima.Core.Requests.Apontamento;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Local;
using Dima.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Handlers
{
    public interface IApontamentoHandler
    {
        Task<Response<Apontamento?>> CreateAsync(CreateApontamentoRequest request);
        Task<Response<Apontamento?>> UpdateAsync(UpdateApontamentoRequest request);
        Task<Response<Apontamento?>> DeleteAsync(DeleteApontamentoRequest request);
        Task<PagedResponse<List<Apontamento>?>> GetAllAsync(GetAllApontamentosRequest request);
    }
}
