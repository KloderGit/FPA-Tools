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
            if (value == null) { return "Выберите тему"; }

            return selectValue(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
    System.Globalization.CultureInfo culture)
        {
            return value;
        }

        private string selectValue(Object _value) {

            string txt = "Выберите тему!!";

            if (_value is Chapter)
            {
                Chapter v = (Chapter)_value;
                txt = v.Text;
            }
            if (_value is Variant)
            {
                Variant v = (Variant)_value;
                txt = v.Chapter.Text;
            }

            return txt;
        }
    }
}
