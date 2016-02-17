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
using FPAControls;
using QuestionsEntityClassLibrary;
using System.Data.Entity;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace QuestionsProject
{
    /// <summary>
    /// Interaction logic for editQuests.xaml
    /// </summary>
    public partial class editQuests : UserControl
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

        QuestionsEntityClassLibrary.QustionareOnline _questionare;


        public editQuests(QustionareOnline questionare)
        {
            _questionare = questionare;
            InitializeComponent();
            txtTitle.Focus();
            listAnswers.Items.SortDescriptions.Add( new System.ComponentModel.SortDescription("Order", System.ComponentModel.ListSortDirection.Ascending));
        }

        public editQuests(Quest _quest, QustionareOnline questionare)
        {
            _questionare = questionare;

            InitializeComponent();

            RootQuest.DataContext = _quest;

            listAnswers.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Order", System.ComponentModel.ListSortDirection.Ascending));

            //using (_db = new QuestionsContext()) {
            //    _db.Database.Log = Console.Write;
            //    _db.Programs.Load();

            //    listBox.ItemsSource = _db.Programs.Local;
            //}

            listPrograms.ItemsSource = aviablePrograms();
        }

        public editQuests(QuestItem _questitem, QustionareOnline questionare)
        {
            _questionare = questionare;

            InitializeComponent();

            listAnswers.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Order", System.ComponentModel.ListSortDirection.Ascending));

            RootQuest.DataContext = _questitem.Quest;
        }


        private void addAnswer_Click(object sender, RoutedEventArgs e)
        {
            Quest _quest = (Quest)RootQuest.DataContext;

            Answer _answer = new Answer();
            _answer.Created = DateTime.Now;
            _answer.Modify = DateTime.Now;
            _answer.Correct = false;

            WindowRight panelRight = new WindowRight();
            panelRight.txtWindowTitle.Text = "Добавление Ответа";
            panelRight.Owner = App.Current.MainWindow;

            editAnswer edit_object = new editAnswer(_answer);
            panelRight.forContent.Children.Add(edit_object);               

            if (panelRight.ShowDialog() == true)
            {
                if (!String.IsNullOrWhiteSpace(_answer.Text))
                {
                    _quest.Answers.Add(_answer);
                    orderAnswer();
                }
                else
                {
                    MessageBox.Show("Ответ не добавлен, т.к. поле Ответа не заполнено", "Внимание...", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void removeAnswer_Click(object sender, RoutedEventArgs e)
        {
            Quest _quest = (Quest)RootQuest.DataContext;

            Answer _answer =(Answer)listAnswers.SelectedItem;

            _quest.Answers.Remove(_answer);

            orderAnswer();
        }

        private void listAnswers_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            Answer _answerORiginal = (Answer)(((ListBoxItem)sender).DataContext);
            Answer _answer = new Answer();

            _answer.Text = _answerORiginal.Text;
            _answer.Description = _answerORiginal.Description;
            _answer.Correct = _answerORiginal.Correct;


            WindowRight panelRight = new WindowRight(); panelRight.txtWindowTitle.Text = "Редактирование Ответа"; panelRight.Owner = App.Current.MainWindow;

            editAnswer edit_object = new editAnswer(_answer);
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true)
            {
                if (!String.IsNullOrWhiteSpace(_answer.Text))
                {
                    _answerORiginal.Text = _answer.Text;
                    _answerORiginal.Description = _answer.Description;
                    _answerORiginal.Correct = _answer.Correct;
                    Console.WriteLine("Ответ изменен?");
                }
                else
                {
                    MessageBox.Show("Ответ не изменен, т.к. поле Ответа не заполнено", "Внимание...", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private void orderAnswer()
        {
            Quest _quest = (Quest)RootQuest.DataContext;

            int itemCount = 1;

            foreach (var item in _quest.Answers)
            {
                item.Order = itemCount;
                itemCount++;
            }

            ICollectionView _customerView = CollectionViewSource.GetDefaultView(listAnswers.ItemsSource);
            _customerView.SortDescriptions.Clear();
            _customerView.SortDescriptions.Add(new SortDescription("Order", ListSortDirection.Ascending));
        }

        private void mixAnswer()
        {
            Quest _quest = (Quest)RootQuest.DataContext;

            var array = _quest.Answers.ToArray();

            var rand = new Random();
            for (var i = 0; i < array.Length; i++)
            {
                var rnd = rand.Next(i, array.Length);

                var item1 = array[i];
                var item2 = array[rnd];

                var order1 = item1.Order;
                var order2 = item2.Order;

                item2.Order = order1;
                item1.Order = order2;

            }

            ICollectionView _customerView = CollectionViewSource.GetDefaultView(listAnswers.ItemsSource);
            _customerView.SortDescriptions.Clear();
            _customerView.SortDescriptions.Add(new SortDescription("Order", ListSortDirection.Ascending));
        }

        private void selectPrograms_Click(object sender, RoutedEventArgs e)
        {
            panelPrograms.Visibility = Visibility.Visible;
        }


        private ObservableCollection<Program> currentPrograms()
        {
            Quest _quest = (Quest)RootQuest.DataContext;
            ObservableCollection<Program> _addedPrograms = new ObservableCollection<Program>();

            foreach (var item in _quest.QuestProrams)
            {
                _addedPrograms.Add(item.Program);
            }

            return _addedPrograms;
        }

        private IEnumerable<Program> aviablePrograms()
        {
            var _programs = _questionare.getPrograms();
            return _programs.Except(currentPrograms());
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            panelPrograms.Visibility = Visibility.Collapsed;
        }

        private void listProgram_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Program _program = (Program)(((ListBoxItem)sender).DataContext);
            addProgramtoQuest(_program);
        }

        private void listProgram_ButtonClick(object sender, RoutedEventArgs e)
        {
            Program _program = (Program)(((Button)sender).DataContext);
            addProgramtoQuest(_program);
        }

        private void addProgramtoQuest(Program _program) {
            Quest _quest = (Quest)RootQuest.DataContext;

            QuestProram questprogramItem = new QuestProram();

            questprogramItem.Program = _program;
            questprogramItem.Program_Id = _program.Id;

            _quest.QuestProrams.Add(questprogramItem);

            listPrograms.ItemsSource = null; listPrograms.ItemsSource = aviablePrograms();

        }

        private void removeProgram_ButtonClick(object sender, RoutedEventArgs e)
        {
            Quest _quest = (Quest)RootQuest.DataContext;
            var itemQuestProgram = (QuestProram)((Button)sender).DataContext;

            _questionare.removeProgram(itemQuestProgram);

            listPrograms.ItemsSource = null; listPrograms.ItemsSource = aviablePrograms();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mixAnswer();
        }
    }
}
