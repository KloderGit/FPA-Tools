using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using QuestionsEntityClassLibrary;

namespace QuestionsProject
{
    [ValueConversion(typeof(Object), typeof(Array))]
    public class ConverterForListItems : IValueConverter
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

        private Array selectValue(Object _value)
        {
            Array array = null;

            if (_value.GetType().BaseType == typeof(Chapter))
            {
                Chapter ch = (Chapter)_value;
                array = ch.Quests.ToArray();
            }
            if (_value.GetType().BaseType == typeof(Variant))
            {
                Variant v = (Variant)_value;
                array = v.QuestItems.ToArray();
            }

            return array;
        }
    }
}
