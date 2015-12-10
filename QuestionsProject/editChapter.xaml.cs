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
    /// Interaction logic for edit.xaml
    /// </summary>
    public partial class editChapter : UserControl
    {
        public editChapter()
        {
            InitializeComponent();
        }

        public editChapter(Object _context)
        {
            InitializeComponent();

            if (_context.GetType().BaseType == typeof(Chapter))
            {
                _context = (Chapter)_context;
            }
            if (_context.GetType().BaseType == typeof(Variant))
            {
                _context = (Variant)_context;
            }

            Root.DataContext = _context;

        }

    }
}
