﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using QuestionsEntityClassLibrary;

namespace QuestionsProject
{
    [ValueConversion(typeof(Object), typeof(string))]
    public class DescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
    System.Globalization.CultureInfo culture)
        {
            if (value == null) { return "Вариант не выбран"; }

            return selectValue(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
    System.Globalization.CultureInfo culture)
        {
            return value;
        }

        private string selectValue(Object _value)
        {

            string txt = null;

            if (_value is Chapter)
            {
                txt = "Все вопросы темы";
            }
            if (_value is Variant)
            {
                Variant v = (Variant)_value;
                txt = v.Text;
            }
            return txt;
        }
    }
}