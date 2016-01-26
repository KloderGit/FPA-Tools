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
    /// Interaction logic for PrintWariant.xaml
    /// </summary>
    public partial class PrintWariant : UserControl
    {
        Variant _variant;

        public PrintWariant(Variant variant)
        {
            InitializeComponent();

            _variant = variant;
        }
    }
}
