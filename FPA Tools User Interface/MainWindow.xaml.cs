using System.Windows;
using FPA_Tools_User_Interface.Project.Questions;
using CodesControl;

namespace FPA_Tools_User_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Questions QuestionsProject;

        CodesProjectUIWrapper CodesProject;

        public MainWindow()
        {
            InitializeComponent();

            QuestionsProject = new Questions();

            TabQuestionareRoot.Children.Add(QuestionsProject.getProject());

            CodesProject = new CodesProjectUIWrapper();

            TabCodeProjectRoot.Children.Add(CodesProject);
        }

    }
    
}
