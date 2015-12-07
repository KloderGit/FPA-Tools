using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using QuestionsEntityClassLibrary;

namespace QuestionsProject
{
    [ValueConversion(typeof(Object), typeof(string))]
    public class TitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
    System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return false;

            Console.WriteLine(value.GetType());

            if (value.GetType().BaseType == typeof(Chapter)) {
                Chapter v = (Chapter)value;
                return v.Text;
            }
            if (value.GetType().BaseType == typeof(Variant))
            {
                Variant v = (Variant)value;
                return v.Chapter.Text;
            }
            return "Не определено...";

        }
        public object ConvertBack(object value, Type targetType, object parameter,
    System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
