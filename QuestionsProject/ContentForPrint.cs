using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionsEntityClassLibrary;
using System.Windows.Documents;
using System.Collections;

namespace QuestionsProject
{
    public class ContentForPrint
    {
        Variant _variant;

        List<BlockUIContainer> _content = new List<BlockUIContainer>();

        public ContentForPrint(Variant variant) {
            _variant = variant;
            prepareContent();
        }

        private void prepareContent()
        {
            foreach (var _questItem in _variant.QuestItems.OrderBy(p => p.Order))
            {
                _content.Add(new BlockUIContainer(new questForListForPrint(_questItem)));
            }
        }

        public IEnumerable getContent() {
            return _content;
        }  
    }
}
