using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using QuestionsEntityClassLibrary;

namespace QuestionsProject
{
    [ValueConversion(typeof(Object), typeof(Chapter))]
    public class ConverterWraperBigChapter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
    System.Globalization.CultureInfo culture)
        {
            if (value == null) { return null; }

            return selectValue(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
    System.Globalization.CultureInfo culture)
        {
            return value;
        }

        private Chapter selectValue(Object _value)
        {

            Chapter ch = null;

            if (_value.GetType().BaseType == typeof(Chapter))
            {
                ch = (Chapter)_value;
            }

            return ch;
        }
    }
}
