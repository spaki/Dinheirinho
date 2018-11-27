using System;
using System.Globalization;
using Xamarin.Forms;

namespace Dinheirinho.Converters
{
    public class MovimentacaoColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value?.ToString() == "Entrada")
                return Color.LimeGreen;

            return Color.DarkSalmon;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
