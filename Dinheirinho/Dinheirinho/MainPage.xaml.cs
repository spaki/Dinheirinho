using Dinheirinho.Models;
using Dinheirinho.Services;
using Dinheirinho.Views;
using System;
using Xamarin.Forms;

namespace Dinheirinho
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            lvMenu.ItemsSource = MenuItemService.ListMenuItems();
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MovimentacoesPage)));
        }

        private void LvMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MenuItemInfo)e.SelectedItem;
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            IsPresented = false;
        }
    }
}
