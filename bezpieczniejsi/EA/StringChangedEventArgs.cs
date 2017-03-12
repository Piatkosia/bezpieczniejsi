using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace bezpieczniejsi
{
    public class StringChangedEventArgs : EventArgs
    {
        private string _oldVal;

        public string OldValue
        {
            get { return _oldVal; }
            set { _oldVal = value; }
        }

        private string _newVal;

        public string NewValue
        {
            get { return _newVal; }
            set { _newVal = value; }
        }



    }
}
