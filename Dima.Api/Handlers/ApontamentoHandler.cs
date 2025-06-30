using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Apontamento;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class ApontamentoHandler(AppDbContext context) : IApontamentoHandler
    {
        public async Task<Response<Apontamento?>> CreateAsync(CreateApontamentoRequest request)
        {
            try
            {
                var local = context.Locais.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoLocal == request.LocalId);
                if(local is null)
                {
                    return new Response<Apontamento?>(null, code: 404, $"Erro ao criar apontamento, local inválido");
                }
                var apontamento = new Apontamento
                {
                    OrdemDeProducao = request.OrdemDeProducao,
                    Usuario = request.UserId
                };

                

                await context.Apontamentos.AddAsync(apontamento);
                await context.SaveChangesAsync();

                return new Response<Apontamento?>(apontamento, code: 201, "Apontamento criado com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<Apontamento?>(null, code: 500, $"Erro ao criar apontamento - {ex.Message}");
            }
        }

        public async Task<Response<Apontamento?>> DeleteAsync(DeleteApontamentoRequest request)
        {

            try
            {
                var apontamento = new Apontamento();
                apontamento = await context.Apontamentos.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (apontamento is null)
                {
                    return new Response<Apontamento?>(null, 404, "Apontamento não encontrado");
                }
                context.Apontamentos.Remove(apontamento);
                await context.SaveChangesAsync();

                return new Response<Apontamento?>(apontamento, code: 200, "Apontamento removido com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<Apontamento?>(null, 500, $"Falha ao remover apontamento - {ex.Message}");
            }
        }

        public async Task<PagedResponse<List<Apontamento>?>> GetAllAsync(GetAllApontamentosRequest request)
        {
            try
            {
                var query = context.Apontamentos.AsNoTracking().OrderBy(x => x.DataApontamento);

                var apontamentos = await query.Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize).ToListAsync();
                var count = await query.CountAsync();

                return new PagedResponse<List<Apontamento>?>(apontamentos, count, request.PageNumber, request.PageSize);

            }
            catch (Exception ex)
            {
                return new PagedResponse<List<Apontamento>?>(null, 500, $"Falha ao obter apontamentos {ex.Message}");
            }
        }

        public Task<Response<Apontamento?>> UpdateAsync(UpdateApontamentoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
