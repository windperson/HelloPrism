using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloPrism.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is String)
            {
                var colorStr = value as string;
                switch (colorStr)
                {
                    case "1":
                        return Color.Aqua;
                    case "2":
                        return Color.Black;
                    case "3":
                        return Color.Blue;

                    case "4":
                        return Color.Fuchsia;
                    default:
                        return Color.Accent;
                }
            }
            else
            {
                return Color.Accent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
