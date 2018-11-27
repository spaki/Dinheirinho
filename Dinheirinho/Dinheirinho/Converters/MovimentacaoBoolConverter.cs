using System;
using System.Globalization;
using Xamarin.Forms;

namespace Dinheirinho.Converters
{
    public class MovimentacaoBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value?.ToString() == "Entrada")
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
                return "Entrada";

            return "Saída";
        }
    }
}
