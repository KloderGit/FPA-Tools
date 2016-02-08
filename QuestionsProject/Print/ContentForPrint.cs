using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionsEntityClassLibrary;
using System.Windows.Documents;
using System.Collections;
using System.Windows.Controls;


namespace QuestionsProject.Print
{
    public class ContentForPrint
    {
        Variant _variant;
        String _printType;
        Section _section = new Section();

        public ContentForPrint(Variant variant, String printType)
        {
            _variant = variant;
            _printType = printType;
            prepareHeader();
            preparePrintContent();
        }


        public Section getSection()
        {
            return _section;
        }

        protected void preparePrintContent()
        {
            if (_printType == "quest") {
                _section.Blocks.AddRange(prepareQuests());
            }
            if (_printType == "key" || _printType == "blank")
            {
                _section.Blocks.Add(new BlockUIContainer(prepareKeyBlank()));
            }
        }

        protected WrapPanel prepareKeyBlank() {

            WrapPanel _wrappanel = new WrapPanel();
            _wrappanel.Orientation = Orientation.Vertical;
            //_wrappanel.Margin = new System.Windows.Thickness(0, 200, 0, 0);
            _wrappanel.Height = 933;

            foreach (var _questItem in _variant.QuestItems.OrderBy(p => p.Order))
            {
                _wrappanel.Children.Add(new OneAnswerForResult(_questItem, _printType));
            }

            return _wrappanel;
        }

        protected IEnumerable prepareQuests()
        {
            List<BlockUIContainer> _content = new List<BlockUIContainer>();

            foreach (var _questItem in _variant.QuestItems.OrderBy(p => p.Order))
            {
                _content.Add(new BlockUIContainer(new questForListForPrint(_questItem)));
            }

            return _content;
        }

        protected void prepareHeader() {

            Paragraph paraHeader = new Paragraph();
            Run _header = new Run();
            _header.FontSize = 22;
            _header.Text = _variant.Chapter.Text + Environment.NewLine;
            Bold _bold = new Bold(_header);
            paraHeader.Inlines.Add(_bold);

            Run _headerV = new Run();
            _headerV.FontSize = 16;
            _headerV.Text = "Вариант: " + _variant.Text + "   Дата генерации: " + _variant.Modify.ToString() + Environment.NewLine + "_______________________________________________________________________________________";
            paraHeader.Inlines.Add(_headerV);

            _section.Blocks.Add(paraHeader);
        }


    }
}
