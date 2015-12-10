using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using QuestionsEntityClassLibrary;

namespace QuestionsProject
{
    [ValueConversion(typeof(Object), typeof(Variant))]
    public class ConverterWrapperBigVariant : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
    System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            return selectValue(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
    System.Globalization.CultureInfo culture)
        {
            return value;
        }

        private Variant selectValue(Object _value)
        {
            Variant vr = null;

            if (_value is Chapter)
            {
                vr = null;
            }
            if (_value is Variant)
            {
                vr = (Variant)_value;
            }

            return vr;
        }
    }
}
