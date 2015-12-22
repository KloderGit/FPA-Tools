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
        }

        public editQuests(Quest _quest, QustionareOnline questionare)
        {
            _questionare = questionare;

            InitializeComponent();

            RootQuest.DataContext = _quest;

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
                _quest.Answers.Add(_answer);
            }
        }

        private void removeAnswer_Click(object sender, RoutedEventArgs e)
        {
            Quest _quest = (Quest)RootQuest.DataContext;

            Answer _answer =(Answer)listAnswers.SelectedItem;

            _quest.Answers.Remove(_answer);
        }

        private void listAnswers_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            Answer _answer = (Answer)(((ListBoxItem)sender).DataContext);

            WindowRight panelRight = new WindowRight(); panelRight.txtWindowTitle.Text = "Редактирование Ответа"; panelRight.Owner = App.Current.MainWindow;

            editAnswer edit_object = new editAnswer(_answer);
            panelRight.forContent.Children.Add(edit_object);

            if (panelRight.ShowDialog() == true)
            {
                Console.WriteLine("Ответ изменен?");
            }
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

            panelPrograms.Visibility = Visibility.Collapsed;
        }

        private void removeProgram_ButtonClick(object sender, RoutedEventArgs e)
        {
            Quest _quest = (Quest)RootQuest.DataContext;
            var itemQuestProgram = (QuestProram)((Button)sender).DataContext;

            _questionare.removeProgram(itemQuestProgram);

            listPrograms.ItemsSource = null; listPrograms.ItemsSource = aviablePrograms();
        }
    }
}
