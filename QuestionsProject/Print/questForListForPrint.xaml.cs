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

namespace QuestionsProject
{
    /// <summary>
    /// Interaction logic for questForListForPrint.xaml
    /// </summary>
    public partial class questForListForPrint : UserControl
    {
        QuestItem _questitem;

        Dictionary<int, string> AnswerChair;

        public questForListForPrint(QuestItem questitem)
        {
            _questitem = questitem;

            AnswerChair = new Dictionary<int, string>(5);
            AnswerChair.Add(1, "A");
            AnswerChair.Add(2, "B");
            AnswerChair.Add(3, "C");
            AnswerChair.Add(4, "D");
            AnswerChair.Add(0, "Z");

            InitializeComponent();

            prepareElement();
        }

        private void prepareElement() {
            txtNumberQuest.Text = _questitem.Order.ToString();
            txtTextQuest.Text = _questitem.Quest.Text;

            int row = 0;

            foreach (var answer in _questitem.Quest.Answers.OrderBy(o => o.Order))
            {
                gridAnswers.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                var txtLetterAnswer = new TextBlock();

                if (answer.Order != null) { txtLetterAnswer.Text = AnswerChair[(int)answer.Order]; }
                else { txtLetterAnswer.Text = ""; }

                //txtLetterAnswer.SetValue(Grid.ColumnProperty, 0);
                //txtLetterAnswer.SetValue(Grid.RowProperty, row);
                txtLetterAnswer.VerticalAlignment = VerticalAlignment.Center;
                txtLetterAnswer.HorizontalAlignment = HorizontalAlignment.Center;

                //txtLetterAnswer.Margin = new Thickness(0, 0, 0, 7);

                Border _circleLetter = new Border();
                _circleLetter.Width = 30; _circleLetter.Height = 30;
                _circleLetter.CornerRadius = new CornerRadius(50);
                _circleLetter.BorderThickness = new Thickness(1);
                _circleLetter.BorderBrush = Brushes.Bisque;
                _circleLetter.Padding = new Thickness(5);
                _circleLetter.Margin = new Thickness(0, 0, 7, 4);
                _circleLetter.SetValue(Grid.ColumnProperty, 0);
                _circleLetter.SetValue(Grid.RowProperty, row);
                _circleLetter.Child = txtLetterAnswer;

                gridAnswers.Children.Add(_circleLetter);

                var txtTextAnswer = new TextBlock() { Text = answer.Text };
                txtTextAnswer.TextWrapping = TextWrapping.Wrap;
                txtTextAnswer.TextAlignment = TextAlignment.Left;
                txtTextAnswer.VerticalAlignment = VerticalAlignment.Center;
                //txtTextAnswer.Margin = new Thickness(0, 0, 0, 7);
                txtTextAnswer.SetValue(Grid.ColumnProperty, 1);
                txtTextAnswer.SetValue(Grid.RowProperty, row);

                gridAnswers.Children.Add(txtTextAnswer);

                row++;
            }
        }
    }
}
