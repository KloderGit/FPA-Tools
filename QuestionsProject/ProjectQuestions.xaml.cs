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
        QuestionsEntityClassLibrary.QustionareOnline _questionare;

        public ProjectQuestions()
        {
            InitializeComponent();
            _questionare = new QustionareOnline();
            Root.DataContext = _questionare.getChapter();
            //WrapperInfo.DataContext = null;
        }

        private void treeViewMenu_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Console.WriteLine(WrapperInfo.DataContext);
            //WrapperInfo.DataContext = treeViewMenu.SelectedItem;
        }

        private void listItems_ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            Console.WriteLine("double click");
        }

//      Работа с Chapter 
#region ---------------------   Chapter  ----------------------------------

        private void editChapter_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            Chapter _chapter = (Chapter)bt.DataContext;

            WindowRight panelRight = new WindowRight();
            panelRight.txtWindowTitle.Text = "Редактирование Темы";
            panelRight.Owner = App.Current.MainWindow;

            editChapter edit_object = new editChapter(_chapter);
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true)
            {
                _chapter.Text = edit_object.txtTitle.Text;
                _chapter.Description = edit_object.txtDescription.Text;

                if (_questionare.editChapter(_chapter)) { Console.WriteLine("Сохранено успешно!");  }
            }
        }

        private void removeChapter_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            Chapter _chapter = (Chapter)bt.DataContext;

            if (MessageBox.Show("Вы уверены, что хотите удалить Тему? Вместе с темой удалятся все созданные для нее варианты.", "Подтвердите удаление!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _questionare.removeChapter(_chapter);
               // Root.DataContext = _questionare.getChapters();
            }

        }

        private void addChapter_Click(object sender, RoutedEventArgs e)
        {

            WindowRight panelRight = new WindowRight();
            panelRight.txtWindowTitle.Text = "Добавление Темы";
            panelRight.Owner = App.Current.MainWindow;

            editChapter edit_object = new editChapter();
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true)
            {
                Chapter _item = new Chapter();
                _item.Text = edit_object.txtTitle.Text;
                _item.Description = edit_object.txtDescription.Text;
                _item.Created = DateTime.Now;
                _item.Modify = DateTime.Now;

                if (_questionare.addChapter(_item))
                {
                    Console.WriteLine("Успешно добавлено!");
                    //Root.DataContext = _questionare.getChapter();
                }
            }
        }

        #endregion
        //      End Chapter 


//      Работа с Vfriant
#region ---------------------   Variant  ----------------------------------

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
                _variant.Text = edit_object.txtTitle.Text;
                _variant.Description = edit_object.txtDescription.Text;

                if (_questionare.editVariant(_variant)) { Console.WriteLine("Сохранено успешно!"); }
            }
        }

        private void removeVariant_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            Variant _variant = (Variant)bt.DataContext;

            if (MessageBox.Show("Вы уверены, что хотите удалить Вариант?", "Подтвердите удаление!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _questionare.removeVariant(_variant);
            }
        }

        private void addVariant_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            Chapter _chapter = (Chapter)bt.DataContext;

            WindowRight panelRight = new WindowRight();
            panelRight.txtWindowTitle.Text = "Добавление Варианта";
            panelRight.Owner = App.Current.MainWindow;

            editChapter edit_object = new editChapter();
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true)
            {
                Variant _item = new Variant();
                _item.Text = edit_object.txtTitle.Text;
                _item.Description = edit_object.txtDescription.Text;
                _item.Chapter = _chapter;
                _item.Chapter_Id = _chapter.Id;

                if (_questionare.addVariant(_item))
                {
                    Console.WriteLine("Вариант добавлен!");
                    Root.DataContext = _questionare.getChapter();
                }
            }

        }

#endregion
//      End Variant

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Chapter cc = (Chapter)WrapperInfo.DataContext;
            Console.WriteLine(cc.Text);

           // Chapter ccc = (Chapter)stBigChapter.DataContext;
            //Console.WriteLine(ccc.Text);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }









//  namespace
    }
}
