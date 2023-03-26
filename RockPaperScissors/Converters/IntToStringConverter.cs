using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Converters
{
    class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (value is int)
            {
                if ((int)value == 1)
                {
                    return "Stone";
                }
                if ((int)value == 2)
                {
                    return "Paper";
                }
                if ((int)value == 3)
                {
                    return "Scissors";
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
