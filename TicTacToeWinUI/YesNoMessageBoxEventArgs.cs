using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWinUI
{
    public class YesNoMessageBoxEventArgs : EventArgs
    {
        private readonly bool r_IsPressedYesInMessageBox;
        public YesNoMessageBoxEventArgs(bool i_IsPressedYesInMessageBox)
        {
            r_IsPressedYesInMessageBox = i_IsPressedYesInMessageBox;
        }
        public bool IsPressedYesInMessageBox
        {
            get
            {
                return r_IsPressedYesInMessageBox;
            }
        }
    }
}
