using Dinheirinho.Services;
using Microcharts;
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
	public partial class GraficosPage : ContentPage
	{
        private readonly MovimentacaoService movimentacaoService = new MovimentacaoService();

        public GraficosPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var somaDasEntradas = await movimentacaoService.ObterSomaDasEntradas();
            var somaDasSaidas = await movimentacaoService.ObterSomaDasSaidas();

            var entradas = new Microcharts.Entry(somaDasEntradas) { Label = "Eu ganhei :)", Color = SkiaSharp.SKColor.Parse("#FF32CD32") };
            var saidas = new Microcharts.Entry(somaDasSaidas) { Label = "Eu gastei :(", Color = SkiaSharp.SKColor.Parse("#FFE9967A") };

            var barChart = new BarChart { Entries = new[] { entradas, saidas } };
            this.chart.Chart = barChart;
        }
    }
}