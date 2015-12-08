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
        Questionare _questionare;

        public ProjectQuestions()
        {
            InitializeComponent();

            //Root.DataContext = _questionare.getChapters();
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
            Button bt = (Button)sender;
            Chapter _chapter = (Chapter)bt.DataContext;

            WindowRight panelRight = new WindowRight();
            panelRight.txtWindowTitle.Text = "Редактирование Темы";
            panelRight.Owner = App.Current.MainWindow;

            editChapter edit_object = new editChapter(_chapter);
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true) {

                var backup = new { Text = _chapter.Text, Desc = _chapter.Description };

                _chapter.Text = edit_object.txtTitle.Text;
                _chapter.Description = edit_object.txtDescription.Text;

                if (_questionare.saveChapter(_chapter)) { Console.WriteLine("Сохранено успешно!"); WrapperInfo.DataContext = null; WrapperInfo.DataContext = treeViewMenu.SelectedItem; }
                else { _chapter.Text = backup.Text; _chapter.Description = backup.Desc; Window wn = new Window(); wn.ShowDialog(); }

            }
        }

        private void removeChapter_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            Chapter _chapter = (Chapter)bt.DataContext;

            if (MessageBox.Show("Вы уверены, что хотите удалить Тему? Вместе с темой удалятся все созданные для нее варианты.", "Подтвердите удаление!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Chapter cc = (Chapter)WrapperInfo.DataContext;
            Console.WriteLine(cc.Text);

           // Chapter ccc = (Chapter)stBigChapter.DataContext;
            //Console.WriteLine(ccc.Text);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            _questionare = new Questionare();
            Root.DataContext = _questionare.getChapters();
            //treeViewMenu.Items.Add(new TreeViewItem { Header = "Interesting" });
        }

        private void editVariant(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            Variant _variant = (Variant)bt.DataContext;

            WindowRight panelRight = new WindowRight();
            panelRight.txtWindowTitle.Text = "Редактирование Варианта";
            panelRight.Owner = App.Current.MainWindow;

            editChapter edit_object = new editChapter(_variant);
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true)
            {

                var backup = new { Text = _variant.Text, Desc = _variant.Description };

                _variant.Text = edit_object.txtTitle.Text;
                _variant.Description = edit_object.txtDescription.Text;

                if (_questionare.saveVariant(_variant)) {
                    Console.WriteLine("Сохранено успешно!");
                    WrapperInfo.DataContext = null; WrapperInfo.DataContext = treeViewMenu.SelectedItem;
                }
                else {
                    _variant.Text = backup.Text;
                    _variant.Description = backup.Desc;
                }

            }
        }

        private void removeVariant_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            Variant _chapter = (Variant)bt.DataContext;

            if (MessageBox.Show("Вы уверены, что хотите удалить Вариант?", "Подтвердите удаление!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

            }
        }

        private void addVariant_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            Variant _chapter = (Variant)bt.DataContext;

            if (MessageBox.Show("Вы уверены, что хотите ДОБАВИТЬ Вариант?", "Подтвердите удаление!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

            }
        }
    }
}
