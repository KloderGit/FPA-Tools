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

namespace QuestionsProject
{
    /// <summary>
    /// Interaction logic for OneAnswerForResult.xaml
    /// </summary>
    public partial class OneAnswerForResult : UserControl
    {
        Dictionary<int, string> AnswerChair;

        public OneAnswerForResult(QuestionsEntityClassLibrary.QuestItem _questItem)
        {
            AnswerChair = new Dictionary<int, string>(5);
            AnswerChair.Add(1, "A");
            AnswerChair.Add(2, "B");
            AnswerChair.Add(3, "C");
            AnswerChair.Add(4, "D");
            AnswerChair.Add(0, "Z");

            InitializeComponent();

            txtNumber.Text = _questItem.Order.ToString();

            txtLetter.Text = AnswerChair[(int)((_questItem.Quest.Answers.FirstOrDefault(a => a.Correct == true)).Order)];
        }
    }
}
