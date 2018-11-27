using Dinheirinho.Models;
using Dinheirinho.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dinheirinho.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovimentacaoPage : ContentPage
	{
        private readonly MovimentacaoService movimentacaoService = new MovimentacaoService();
        private Movimentacao entidade;

        public MovimentacaoPage (Movimentacao entidade)
		{
            this.InitializeComponent();

            this.BindingContext = entidade;
            this.entidade = entidade;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //var posicao = await Geolocation.GetLastKnownLocationAsync();
            //this.item.Latitude = posicao.Latitude;
            //this.item.Longitude = posicao.Longitude;

            //Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(posicao.Latitude, posicao.Longitude), Distance.FromMiles(0.5)));
        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            await movimentacaoService.SalvarAsync(entidade);
            await Navigation.PopAsync();
        }

        private async void btnEscolherFoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                entidade.Foto = "nophoto.png";
                return;
            }

            var foto = await CrossMedia.Current.PickPhotoAsync();

            if (foto == null)
            {
                entidade.Foto = "nophoto.png";
                return;
            }

            entidade.Foto = foto.Path;
        }

        private async void btnTirarFoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Ops", "Nenhuma câmera detectada :(", "OK");
                entidade.Foto = "nophoto.png";
                return;
            }

            var armazenamento = new StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Name = "Dinheirinhos.jpg"
            };

            var foto = await CrossMedia.Current.TakePhotoAsync(armazenamento);

            if (foto == null)
            {
                entidade.Foto = "nophoto.png";
                return;
            }

            entidade.Foto = foto.Path;
        }
    }
}