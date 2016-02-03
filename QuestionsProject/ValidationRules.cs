using System;
using System.Windows.Controls;

namespace QuestionsProject
{
    public class CountRule : ValidationRule
    {

        String _text = String.Empty;

        public string Count
        {
            get { return _text; }
            set { _text = value; }
        }


        public override ValidationResult Validate(object value, System.Globalization.CultureInfo ci)
        {
            _text = (string)value;

            if (String.IsNullOrWhiteSpace(_text))
            {
                return new ValidationResult(false,
                  "Строка не может быть пустой!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
