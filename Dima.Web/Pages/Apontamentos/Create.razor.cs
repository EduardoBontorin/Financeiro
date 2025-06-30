using Dima.Core.Handlers;
using Dima.Core.Requests.Apontamento;
using Dima.Core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Apontamentos
{
    public class CreateApontamentoPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public bool ColetandoLocal { get; set; } = false;
        public CreateApontamentoRequest InputModel { get; set; } = new();


        #endregion

        #region Services
        [Inject]
        public IApontamentoHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            try
            {
                var result = await Handler.CreateAsync(InputModel);
                if (result.IsSuccess)
                {
                    NavigationManager.NavigateTo("/categorias");
                    Snackbar.Add(result.Message!, Severity.Success);
                }
                else
                {
                    Snackbar.Add(result.Message!, Severity.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task RegistrarApontamentoAsync() 
        {
            IsBusy = true;
            try
            {
                if (ColetandoLocal && InputModel.OrdemDeProducao != string.Empty)
                {
                    ColetandoLocal = true; 
                }
                else if(ColetandoLocal && InputModel.LocalId !=0) 
                {
                    var result = await Handler.CreateAsync(InputModel);
                    if (result.IsSuccess)
                    {
                        NavigationManager.NavigateTo("/categorias");
                        Snackbar.Add(result.Message!, Severity.Success);
                        ColetandoLocal = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Snackbar.Add(ex.Message, Severity.Error);
                ColetandoLocal = false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
