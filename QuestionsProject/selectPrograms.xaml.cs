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
using System.Collections.ObjectModel;

namespace QuestionsProject
{
    /// <summary>
    /// Interaction logic for selectPrograms.xaml
    /// </summary>
    public partial class selectPrograms : UserControl
    {
        Quest _quest;
        ObservableCollection<Program> _allprograms;

        public selectPrograms()
        {
            InitializeComponent();
        }

        public selectPrograms(Quest quest, ObservableCollection<Program> allprograms)
        {
            _quest = quest;
            _allprograms = allprograms;

            InitializeComponent();

            listBoxPrograms.ItemsSource = aviablePrograms();
        }

        private ObservableCollection<Program> currentPrograms() {
            ObservableCollection<Program> _addedPrograms = new ObservableCollection<Program>();

            foreach (var item in _quest.QuestProrams)
            {
                _addedPrograms.Add(item.Program);
            }

            return _addedPrograms;
        }


        private IEnumerable<Program> aviablePrograms() {
            return _allprograms.Except(currentPrograms());
        }


            
    }
}
