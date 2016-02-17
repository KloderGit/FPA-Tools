using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestionsEntityClassLibrary;

namespace QuestionsProject
{
    /// <summary>
    /// Interaction logic for edit.xaml
    /// </summary>
    public partial class editVariant : UserControl
    {
        List<TextBox> controlsForValidate = new List<TextBox>();

        public string Title
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }

        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public string CountQuestInVariant
        {
            get { return txtCount.Text; }
            set { txtCount.Text = value; }
        }


        public editVariant()
        {
            InitializeComponent();
            controlsForValidate.Add(txtTitle);
            controlsForValidate.Add(txtCount);

            txtTitle.Focus();
        }

        public editVariant(Variant _variant)
        {
            InitializeComponent();
            controlsForValidate.Add(txtTitle);
            controlsForValidate.Add(txtCount);
            Root.DataContext = _variant;
        }


        //private bool validationText(TextBox _textBox) {
        //    bool _result = new bool();

        //    _result = true;

        //    if (string.IsNullOrWhiteSpace(_textBox.Text)) {
        //        _result = false;
        //        _textBox.BorderBrush = Brushes.DarkRed;
        //    }

        //    _textBox.BorderBrush = Brushes.Cyan;
        //    return _result;
        //}

        //private bool validationInt(TextBox _textBox)
        //{
        //    bool _result = new bool();

        //    _result = true;
        //    int _number;

        //    if (string.IsNullOrWhiteSpace(_textBox.Text) || !Int32.TryParse(_textBox.Text, out _number))
        //    {
        //        _result = false;
        //    }

        //    return _result;
        //}

        private void txtTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            //validationText((TextBox)sender);
        }

        public List<TextBox> forVAlidate
        {
            get { return controlsForValidate; }
        }
    }
}
