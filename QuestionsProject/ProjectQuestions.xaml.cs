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
            WrapperInfo.DataContext = new { Text = "Тема не выбрана", Description = "" };


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
                WrapperInfo.DataContext = v;
                //WrapperInfo.DataContext = new { Text = v.Chapter.Text, Description = v.Text };
                listItems.ItemsSource = _questionare.GetChildren(v);

                foreach (var t in _questionare.GetChildren(v)) {
                    Console.WriteLine(t.Quest.Text);
                }

            }
            if (treeView.SelectedItem.GetType().BaseType == typeof(Chapter))
            {
                Chapter ch = (Chapter)treeView.SelectedItem;
                WrapperInfo.DataContext = new { Text = ch.Text, Description = "Все вопросы темы" };
                listItems.ItemsSource = _questionare.GetChildren(ch);
            }

        }

        private void listItems_ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            Console.WriteLine("double click");
        }

        private void editChapter_Click(object sender, RoutedEventArgs e)
        {
            Chapter _chapter = (Chapter)treeViewMenu.SelectedItem;

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
    }
}
