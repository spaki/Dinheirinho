using Dinheirinho.Models;
using Dinheirinho.Views;
using System.Collections.ObjectModel;

namespace Dinheirinho.Services
{
    public class MenuItemService
    {
        public static ObservableCollection<MenuItemInfo> ListMenuItems() =>
            new ObservableCollection<MenuItemInfo> {
                new MenuItemInfo() { Title = "Movimentações", Icon = "movimentacao.png", TargetType = typeof(MovimentacoesTabPage) },
                new MenuItemInfo() { Title = "About", Icon = "about.png", TargetType = typeof(AboutPage) }
            };
    }
}
