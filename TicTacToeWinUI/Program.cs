using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeWinUI
{
    public static class Program 
    {
        public static void Main()
        {
            UserInterface ticTacToeUI = new UserInterface();
            ticTacToeUI.Run();
        }
    }
}
