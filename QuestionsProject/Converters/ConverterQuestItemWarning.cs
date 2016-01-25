using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using QuestionsEntityClassLibrary;

namespace QuestionsProject
{
    //[ValueConversion(typeof(Object), typeof(bool))]
    public class ConverterQuestItemWarning : IValueConverter
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

        private object selectValue(Object _value)
        {
            bool error = false;
            ICollection<Answer> array = null;

            if (_value is Quest)
            {
                array = ((Quest)_value).Answers;
            }
            if (_value is QuestItem)
            {
                array = ((QuestItem)_value).Quest.Answers;
            }

            var result = array.FirstOrDefault(p=> p.Correct==true);

            if (result == null) { error = true; }

            return error ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
