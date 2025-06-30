using Dima.Core.Models;
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
    public interface ILocalHandler
    {
        Task<Response<Local?>> CreateAsync(CreateLocalRequest request);
        Task<Response<Local?>> UpdateAsync(UpdateLocalRequest request);
        Task<Response<Local?>> DeleteAsync(DeleteLocalRequest request);
        Task<PagedResponse<List<Local>?>> GetAllAsync(GetAllLocaisRequest request);

    }
}
