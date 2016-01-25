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
        }

        public editVariant(Variant _variant)
        {
            InitializeComponent();
            Root.DataContext = _variant;
        }

    }
}
