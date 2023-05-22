using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentations.ViewModel
{
    public class Book : ViewModelBase
    {



        public ICommand AddBookMove { get; }

        public Book() { }
    }
}
