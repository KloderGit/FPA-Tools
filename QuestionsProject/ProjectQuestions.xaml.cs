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
using FPAComponents;

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
            WrapperInfo.DataContext = new { Text = "Тема не выбрана", Description = "" };

            SidePanelRight side = new SidePanelRight();

            //AccordionMenu.DataContext = _questionare.getChapters();
        }

        private void lstVariants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Variant _item = (Variant)((ListBox)sender).SelectedItem;
            
            WrapperInfo.DataContext = _item;
        }

        private void treeViewMenu_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView treeView = (TreeView)sender;

            if (treeView.SelectedItem.GetType().BaseType == typeof(Variant)) {

                Variant v = (Variant)treeView.SelectedItem;
                WrapperInfo.DataContext = new { Text = v.Chapter.Text, Description = v.Text };
                listItems.ItemsSource = v.QuestItems;
            }
            if (treeView.SelectedItem.GetType().BaseType == typeof(Chapter))
            {
                Chapter ch = (Chapter)treeView.SelectedItem;
                WrapperInfo.DataContext = new { Text = ch.Text, Description = "Все вопросы темы" };
                listItems.ItemsSource = _questionare.getChapterQuests(ch);
            }

        }
    }
}
