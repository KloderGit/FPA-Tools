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

namespace QuestionsProject
{
    /// <summary>
    /// Interaction logic for editQuest.xaml
    /// </summary>
    public partial class editQuest : UserControl
    {
        public editQuest()
        {
            InitializeComponent();

            PanelAnswers.Children.Add(new answerControl());
        }
    }
}
