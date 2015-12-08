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
using FPAControls;

namespace QuestionsProject
{
    /// <summary>
    /// Interaction logic for ProjectQuestions.xaml
    /// </summary>
    public partial class ProjectQuestions : UserControl
    {
        Questionare _questionare = new Questionare();

        public ProjectQuestions()
        {
            InitializeComponent();

            Root.DataContext = _questionare.getChapters();
            WrapperInfo.DataContext = null;
        }

        private void treeViewMenu_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            WrapperInfo.DataContext = treeViewMenu.SelectedItem;
        }

        private void listItems_ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            Console.WriteLine("double click");
        }

        private void editChapter_Click(object sender, RoutedEventArgs e)
        {
            Chapter _chapter = (Chapter)WrapperInfo.DataContext;

            WindowRight panelRight = new WindowRight();
            panelRight.txtWindowTitle.Text = "Редактирование";
            panelRight.Owner = App.Current.MainWindow;

            editChapter edit_object = new editChapter(_chapter);
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true) {
                _chapter.Text = edit_object.txtTitle.Text;
                _chapter.Description = edit_object.txtDescription.Text;
                Root.DataContext = _questionare.getChapters();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Chapter v =(Chapter)treeViewMenu.SelectedItem;
            v.Text = "OOOOOOOOOOOOOOOOOOOO";
        }
    }
}
