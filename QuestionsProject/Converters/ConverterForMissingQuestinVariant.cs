using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using QuestionsEntityClassLibrary;
using System.Collections.ObjectModel;

namespace QuestionsProject
{
    [ValueConversion(typeof(Object), typeof(Array))]
    public class ConverterForMissingQuestinVariant : IValueConverter
    {
        ObservableCollection<Quest> array = null;

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

        private ObservableCollection<Quest> selectValue(Object _value)
        {           

            if (_value is Chapter)
            {
                return null;
            }
            if (_value is Variant)
            {
                Variant v = (Variant)_value;
                Chapter Ch = v.Chapter;

                var aviable = from i in v.Chapter.Quests select i;
                var missing = from i in v.QuestItems select i.Quest;
                var diferent = aviable.Except(missing);

                array = new ObservableCollection<Quest>(aviable.Except(missing));

            }

            return array;
        }
    }
}
