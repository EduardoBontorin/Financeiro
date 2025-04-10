using Dima.Api.Data;
using Dima.Core.Common;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class TransactionHandler(AppDbContext context) : ITransactionHandler
    {
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            try 
            {
                var transaction = new Transaction()
                {
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    Title = request.Title,
                    Type = request.Type,
                    Amount = request.Amount,
                    CreatedAt = DateTime.Now,
                    PaidOrReceivedAt = request.PaidOrReceivedAt
                };
                await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, code: 201, "Transação criada com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<Transaction?>(null,code:500,message:$"Erro ao criar transação - {ex.Message}");
            }
        }

        public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
        {
            try 
            {
                var transaction = new Transaction();
                transaction = await context.Transactions.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transaction is null)
                {
                    return new Response<Transaction?>(null, 404, "Transação não encontrada");
                }

                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 200, "Transação removida com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<Transaction?>(null, 500, $"Falha ao remover transação, {ex.Message}");
            }
        }

        public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            try 
            {
                var transaction = new Transaction();
                transaction = await context.Transactions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return transaction is null ? new Response<Transaction?>(null, 404, "Categoria não encontrada")
                    : new Response<Transaction?>(transaction, 200, "Categoria encontrada");
            }
            catch (Exception ex)
            {
                return new Response<Transaction?>(null, 500, $"Falha ao obter categoria, {ex.Message}");
            }
        }

        public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
        {
            try 
            {
                request.StartDate ??= DateTime.Now.GetFirstDay();
                request.EndDate ??= DateTime.Now.GetLastDay();
            }
            catch (Exception ex) 
            {
                return new PagedResponse<List<Transaction>?>(null, 500, $"Não foi possível determinar a data de inicio ou término, {ex.Message}");
            }

            try 
            {
                var query = context.Transactions.AsNoTracking()
                .Where(x => x.PaidOrReceivedAt >= request.StartDate
                && x.PaidOrReceivedAt <= request.EndDate
                && x.UserId == request.UserId).OrderBy(x => x.PaidOrReceivedAt);

                var transactions = await query.Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize).ToListAsync();
                var count = await query.CountAsync();

                return new PagedResponse<List<Transaction>?>(transactions, count, request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                return new PagedResponse<List<Transaction>?>(null,500,$"Erro ao obter transações {ex.Message}");
            }
        }

        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            try 
            {
                var transaction = new Transaction();
                transaction = await context.Transactions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transaction is null) 
                {
                    return new Response<Transaction?>(null, 404, "Categoria não localizada");
                }

                transaction.Title = request.Title;
                transaction.CategoryId = request.CategoryId;
                transaction.Amount = request.Amount;
                transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;
                transaction.Type = request.Type;

                context.Transactions.Update(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 200, "Transação atualizada com sucesso");
                    
            }
            catch (Exception ex)
            {
                return new Response<Transaction?>(null, 500, "Não foi possível atualizar a transação");
            }
        }
    }
}
