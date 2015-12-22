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
    /// Interaction logic for editAnswer.xaml
    /// </summary>
    public partial class editAnswer : UserControl
    {
        public string Title
        {
            get { return txtText.Text; }
            set { txtText.Text = value; }
        }
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public editAnswer()
        {
            InitializeComponent();
        }

        public editAnswer(Answer _answer) {
            InitializeComponent();
            RootAnswer.DataContext = _answer;
        }
    }
}
