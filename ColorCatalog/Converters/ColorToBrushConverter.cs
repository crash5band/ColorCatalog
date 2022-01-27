using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorCatalog.Converters
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Models.Color color = (Models.Color)value;
            if (color == null)
                throw new ArgumentNullException("value", $"value argument must be of type {typeof(Models.Color)}");

            return new SolidColorBrush(Color.FromRgb(color.R, color.G, color.B));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = (SolidColorBrush)value;
            return new Models.Color(brush.Color.R, brush.Color.G, brush.Color.B, brush.Color.A);
        }
    }
}
