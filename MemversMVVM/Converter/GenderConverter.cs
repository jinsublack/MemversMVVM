using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MemversMVVM.Converter
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
    
            if ((string)parameter == (string)value)
                return true;
            else
                return false;
            //return ((string)parameter == (string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if((bool)value)
            {
                return parameter;
            }
            else
            {
                if ((string)parameter == "F")
                    return "M";
                else
                    return "F";
            }
            //return (bool)value;
            
        }
    }
}
