using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Local;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class LocalHandler(AppDbContext context) : ILocalHandler
    {
        public async Task<Response<Local?>> CreateAsync(CreateLocalRequest request)
        {
            try
            {
                var local = new Local
                {
                    CodigoLocal = request.CodigoLocal,
                    LocalDeApontamento = request.LocalDeApontamento,
                    
                };
                await context.Locais.AddAsync(local);
                await context.SaveChangesAsync();

                return new Response<Local?>(local, code: 201, "Local criado com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<Local?>(null, code: 500, $"Erro ao criar local - {ex.Message}");
            }
        }

        public async Task<Response<Local?>> DeleteAsync(DeleteLocalRequest request)
        {
            try
            {
                var local = new Local();
                local = await context.Locais.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (local is null)
                {
                    return new Response<Local?>(null, 404, "Local não encontrado");
                }
                context.Locais.Remove(local);
                await context.SaveChangesAsync();

                return new Response<Local?>(local, code: 200, "Local removido com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<Local?>(null, 500, $"Falha ao remover Local - {ex.Message}");
            }
        }

        public async Task<PagedResponse<List<Local>?>> GetAllAsync(GetAllLocaisRequest request)
        {
            try
            {
                var query = context.Locais.AsNoTracking().OrderBy(x => x.CodigoLocal);

                var locais = await query.Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize).ToListAsync();
                var count = await query.CountAsync();

                return new PagedResponse<List<Local>?>(locais, count, request.PageNumber, request.PageSize);

            }
            catch (Exception ex)
            {
                return new PagedResponse<List<Local>?>(null, 500, $"Falha ao obter locais {ex.Message}");
            }
        }

        public Task<Response<Local?>> UpdateAsync(UpdateLocalRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
