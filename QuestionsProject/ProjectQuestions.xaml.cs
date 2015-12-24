﻿using System;
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
using System.ComponentModel;
using System.Collections;
using System.Windows.Media.Animation;

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
            if (treeViewMenu.SelectedItem is Chapter) { hideRightPanel(); }
            if (treeViewMenu.SelectedItem is Variant) { showRightPanel(); }

            //Console.WriteLine(WrapperInfo.DataContext);
            //WrapperInfo.DataContext = treeViewMenu.SelectedItem;
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
                _chapter.Text = edit_object.Title;
                _chapter.Description = edit_object.Description;

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
                _variant.Text = edit_object.Title;
                _variant.Description = edit_object.Description;

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
                    //Root.DataContext = null;
                   // Root.DataContext = _questionare.getChapter();
                }
            }

        }

#endregion
//      End Variant



        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ((CollectionViewSource)this.Resources["ItemsForTreeViewMenu"]).View.Refresh();

        }


//      Работа с Quest
#region ---------------------   Quest  ----------------------------------

        private void listItems_ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem lstItem = (ListBoxItem)sender;
            Quest _quest = null;

            if (lstItem.DataContext is Quest)
            {
                _quest = (Quest)lstItem.DataContext;
            }
            if (lstItem.DataContext is QuestItem)
            {
                _quest = ((QuestItem)lstItem.DataContext).Quest;
            }

            WindowRight panelRight = new WindowRight();
            panelRight.txtWindowTitle.Text = "Редактирование Вопроса";
            panelRight.Owner = App.Current.MainWindow;


            Quest _tempQuest = new Quest();
            _tempQuest.Text = _quest.Text;
            _tempQuest.Description = _quest.Description;
            _tempQuest.Chapter = _quest.Chapter;
            _tempQuest.Chapter_Id = _quest.Chapter_Id;
            _tempQuest.Created = _quest.Created;
            _tempQuest.Editor = _quest.Editor;
            _tempQuest.Modify = _quest.Modify;
            _tempQuest.QuestProrams = _quest.QuestProrams;

            _tempQuest.Answers = new System.Collections.ObjectModel.ObservableCollection<Answer>();

            foreach (var oc in _quest.Answers) {
                _tempQuest.Answers.Add(oc);
            }

            editQuests edit_object = new editQuests(_tempQuest, _questionare);
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true)
            {
                _quest.Text = _tempQuest.Text;
                _quest.Description = _tempQuest.Description;

                var minus_answers = _quest.Answers.Except(_tempQuest.Answers);
                var plus_answers = _tempQuest.Answers.Except(_quest.Answers);

                if (plus_answers.Count() != 0) {
                    foreach (var an in plus_answers) {
                        _quest.Answers.Add(an);
                    }
                }

                if (minus_answers.Count() != 0) {
                    if (_questionare.removeAnswers(minus_answers)) { Console.WriteLine("Ответы удалены"); }
                }             

                if (_questionare.editQuest(_quest)) { Console.WriteLine("Вопрос сохранен!"); }
            }
        }


        private void addQuest_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            Chapter _chapter = (Chapter)bt.DataContext;

            Quest _quest = new Quest();
            _quest.Chapter = _chapter;
            _quest.Chapter_Id = _chapter.Id;

            WindowRight panelRight = new WindowRight();
            panelRight.txtWindowTitle.Text = "Добавление Вопроса";
            panelRight.Owner = App.Current.MainWindow;

            editQuests edit_object = new editQuests(_quest, _questionare);
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true)
            {
                if (_questionare.addQuest(_quest)) {
                    Console.WriteLine("Вопрос для Темы сохранен!");
                    var ctx = WrapperInfo.DataContext; WrapperInfo.DataContext = null; WrapperInfo.DataContext = ctx;
                }
            }
        }

        private void removeQuest_Click(object sender, RoutedEventArgs e)
        {
            Chapter _chapter = (Chapter)((Button)sender).DataContext;

            List<Quest> _quests = new List<Quest>();
            foreach (var it in listItems.SelectedItems)
            {
                _quests.Add((Quest)it);
                //Console.WriteLine(((Quest)it).Text);
                //Console.WriteLine(it.GetType());

            }


            if (_questionare.removeQuests(_quests)) {
                //_questionare.Reload(_chapter);
                //Console.WriteLine(_chapter.Quests);
            }


        }

        private void showRightPanel()
        {
            //ShadowPanel.Visibility = Visibility.Visible;
            Storyboard sb = Resources["sbShowRightMenu"] as Storyboard;
            sb.Begin(PaneladdQuestItem);
        }

        private void hideRightPanel()
        {
            //ShadowPanel.Visibility = Visibility.Hidden;
            Storyboard sb = Resources["sbHideRightMenu"] as Storyboard;
            sb.Begin(PaneladdQuestItem);
        }

        private void addQuestIntoVariant_Click(object sender, RoutedEventArgs e)
        {
            Variant _variant = (Variant)(((Button)sender).DataContext);
            Chapter _chapter = _variant.Chapter;

            Quest _quest = new Quest();
            _quest.Chapter = _chapter;
            _quest.Chapter_Id = _chapter.Id;

            WindowRight panelRight = new WindowRight();
            panelRight.txtWindowTitle.Text = "Добавление Вопроса";
            panelRight.Owner = App.Current.MainWindow;

            editQuests edit_object = new editQuests(_quest, _questionare);
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true)
            {
                if (_questionare.addQuest(_quest))
                {
                    QuestItem _questItem = new QuestItem();
                    _questItem.Quest = _quest;
                    _questItem.Quest_Id = _quest.Id;

                    _questItem.Modify = DateTime.Now;
                    _questItem.Created = DateTime.Now;

                    _variant.QuestItems.Add(_questItem);

                    if (_questionare.editVariant(_variant)) { Console.WriteLine("Вопрос для Варианта добавлен!"); var ctx = WrapperInfo.DataContext; WrapperInfo.DataContext = null; WrapperInfo.DataContext = ctx; }
                }
            }
        }

        private void addRandomQuest(object sender, RoutedEventArgs e)
        {          
            Variant _variant = (Variant)((Button)sender).DataContext;
            
            int maximum_in_variant = 5;   //  Максимум
            var current_in_variant = (from i in _variant.QuestItems select i.Quest).ToList();  //  Существуют
            var selected_in_panel = listBoxQuests.SelectedItems.Cast<Quest>().ToList();         //  Выделены
            var missing_in_variant = listBoxQuests.ItemsSource.Cast<Quest>().ToList();          //  Отсутствуют
            int count_to_add = 0;

            if (selected_in_panel.Count > 0)
            {
                if (maximum_in_variant - current_in_variant.Count < selected_in_panel.Count)
                {
                    if (maximum_in_variant - current_in_variant.Count > 0)
                    {
                        count_to_add = maximum_in_variant - current_in_variant.Count;
                        addQuestItems_in_variants(count_to_add, selected_in_panel, _variant);
                    }
                    else
                    {
                        Console.WriteLine("Вариант заполнен!");
                    }
                }
                else
                {
                    count_to_add = selected_in_panel.Count;
                    addQuestItems_in_variants(count_to_add, selected_in_panel, _variant);
                }
            }
            else {
                if (maximum_in_variant - current_in_variant.Count < missing_in_variant.Count)
                {
                    if (maximum_in_variant - current_in_variant.Count > 0)
                    {
                        count_to_add = maximum_in_variant - current_in_variant.Count;
                        addQuestItems_in_variants(count_to_add, missing_in_variant, _variant);
                    }
                    else
                    {
                        Console.WriteLine("Вариант заполнен!");
                    }
                }
                else
                {
                    count_to_add = missing_in_variant.Count;
                    addQuestItems_in_variants(count_to_add, missing_in_variant, _variant);
                }
            }
        }

        private void addQuestItems_in_variants(int count, List<Quest> _list, Variant _variant) {
            Random rand = new Random(DateTime.Now.Millisecond);
            int ui = 0;
            while (_list.Count > 0)
            {
                int c = _list.Count;
                int rnd = rand.Next(0, c);
                var Selected = _list.ElementAt(rnd);

                QuestItem _questItem = new QuestItem();
                _questItem.Created = DateTime.Now;
                _questItem.Modify = DateTime.Now;
                _questItem.Quest = Selected;
                _questItem.Quest_Id = Selected.Id;

                _variant.QuestItems.Add(_questItem);
                _list.Remove(Selected);
                ui++;
                if (ui == count) { break; }
            }
            //var wc = listBoxQuests.DataContext; listBoxQuests.DataContext = null; listBoxQuests.DataContext = wc;
            _questionare.editVariant(_variant);
        }

        private void showPaneladdQuestItem(object sender, RoutedEventArgs e)
        {
            if (PaneladdQuestItem.Visibility == Visibility.Visible) { PaneladdQuestItem.Visibility = Visibility.Collapsed; }
            if (PaneladdQuestItem.Visibility == Visibility.Collapsed) { PaneladdQuestItem.Visibility = Visibility.Visible; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(listBoxQuests.DataContext.GetType());
            
        }

        private void removeQuestItems_Click(object sender, RoutedEventArgs e)
        {
            Variant _variant = (Variant)((Button)sender).DataContext;

            List<QuestItem> selected_items = listItems.SelectedItems.Cast<QuestItem>().ToList();

            if (MessageBox.Show("Вы уверены, что хотите удалить выделенное?", "Подтвердите удаление!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (_questionare.removeQuestsItems(selected_items)) {
                    MessageBox.Show("Успешно удалены", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        private void hidePanel(object sender, RoutedEventArgs e)
        {
            hideRightPanel();

        }



        #endregion
        //      End Quest





        //  namespace
    }
}
