using Dima.Core.Common;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Transactions
{
    public partial class ListTransactionsPage : ComponentBase
    {
        #region Properties
        public bool isBusy { get; set; }
        public List<Transaction> Transactions { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;
        public int CurrentYear { get; set; } = DateTime.Now.Year;
        public int CurrentMonth { get; set; } = DateTime.Now.Month;

        public int[] Years { get; set; } =
        {
             DateTime.Now.AddYears(-3).Year,
            DateTime.Now.AddYears(-2).Year,
            DateTime.Now.AddYears(-1).Year,
            DateTime.Now.Year,
            DateTime.Now.AddYears(1).Year,
            DateTime.Now.AddYears(2).Year,
            DateTime.Now.AddYears(3).Year
        };

        #endregion

        #region Services

        [Inject]
        public ITransactionHandler Handler { get; set; } = null!;

        [Inject]
        public ISnackbar SnackBar { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;


        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync() => await GetTransactions();

        #endregion

        #region Methods

        public async void OnDeleteButtonClickedAsync(long id, string title)
        {
            var result = await DialogService.ShowMessageBox("Atenção", $"Deseja eliminar o lançamento {title}?", yesText: "EXCLUIR", cancelText: "CANCELAR");

            if (result is true)
                await OnDeleteAsync(id, title);
        }

        public Func<Transaction, bool> Filter =>
            Transaction =>
            {
                if (string.IsNullOrEmpty(SearchTerm))
                    return true;

                return Transaction.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                    Transaction.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase);
            };

        private async Task OnDeleteAsync(long id, string title)
        {
            isBusy = true;
            try
            {
                var result = await Handler.DeleteAsync(new DeleteTransactionRequest { Id = id });
                if (result.IsSuccess)
                {
                    SnackBar.Add("Lançamento removido", Severity.Success);
                    Transactions.RemoveAll(x => x.Id == id);
                    StateHasChanged();
                }
                else 
                {
                    SnackBar.Add(result.Message ?? "Falha ao remover transação", Severity.Error);
                }
            }
            catch (Exception ex)
            {
                SnackBar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                isBusy = false;
            }
        }
        private async Task GetTransactions()
        {
            isBusy = true;
            try
            {
                var request = new GetTransactionsByPeriodRequest()
                {
                    StartDate = DateTime.Now.GetFirstDay(CurrentYear, CurrentMonth),
                    EndDate = DateTime.Now.GetLastDay(CurrentYear, CurrentMonth),
                    PageNumber = 1,
                    PageSize = 1000
                };
                var result = await Handler.GetByPeriodAsync(request);

                if (result.IsSuccess)
                    Transactions = result.Data ?? [];
            }
            catch (Exception ex)
            {
                SnackBar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                isBusy = false;
            }

        }
        #endregion
    }
}
