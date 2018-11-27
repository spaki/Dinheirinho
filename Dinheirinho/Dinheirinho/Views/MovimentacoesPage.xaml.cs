using Dinheirinho.Models;
using Dinheirinho.Services;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dinheirinho.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovimentacoesPage : ContentPage
	{
        private readonly MovimentacaoService movimentacaoService = new MovimentacaoService();

        public MovimentacoesPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            await CarregarTela();
        }

        private async void BtnNova_Clicked(object sender, EventArgs e)
        {
            //((MainPage)Application.Current.MainPage).Detail = new NavigationPage(new MovimentacaoPage(new Movimentacao()));
            await Navigation.PushAsync(new MovimentacaoPage(new Movimentacao()));
        }

        private async void MenuItemAtualizar_OnClicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var entidade = (Movimentacao)menuItem.CommandParameter;
            await Navigation.PushAsync(new MovimentacaoPage(entidade));
        }

        private async void MenuItemApagar_OnClicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var entidade = (Movimentacao)menuItem.CommandParameter;
            await movimentacaoService.DesativarAsync(entidade);
            await CarregarTela();
        }

        private async Task CarregarTela()
        {
            lvMovimentacoes.ItemsSource = await movimentacaoService.ListarTodasAsync(null);
            lblSaldo.Text = (await movimentacaoService.ObterSaldo()).ToString("C") ;
        }
    }
}