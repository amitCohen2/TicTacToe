using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicTacToeGameLogic;

namespace TicTacToeWinUI
{
    public class UserInterface
    {
        private readonly Game r_TicTacToeGameLogic;
        private readonly FormGame r_FormGame;
        public UserInterface()
        {
            r_FormGame = new FormGame();
            r_TicTacToeGameLogic = new Game();
        }
        public void Run()
        {
           listenToWinUIEvents();
           listenToGameLogicEvents();
           r_FormGame.ShowDialog();
        }
        
        private void listenToGameLogicEvents()
        {
            r_TicTacToeGameLogic.GameFinished += gameFinishedListener;
            r_TicTacToeGameLogic.GameStarted += gameStartedListener;
            r_TicTacToeGameLogic.SwitchedPlayers += ticTacToeGameLogic_SwitchedPlayers;
        }
        
        private void gameFinishedListener(object sender)
        {
            Game gameLogic = sender as Game;
            r_FormGame.ContinuePlayingMessageBox(gameLogic);
        }
        
        private void listenToWinUIEvents()
        {
            r_FormGame.GameDetailsInit += formGame_GameDetailsUpdated;
            r_FormGame.YesNoMessageBoxClicked += formGame_YesNoMessageBoxClicked;
        }
        private void ticTacToeGameLogic_SwitchedPlayers()
        {
            r_FormGame.SwitchPlayers();
        }
         
         private void gameStartedListener(Game i_Game)
         {
             r_FormGame.SetNewSession(i_Game.Player1.Points, i_Game.Player2.Points, i_Game.CurrentPlayer.Name);
         }

         private void formGame_YesNoMessageBoxClicked(object sender, EventArgs e)
         {
             YesNoMessageBoxEventArgs yesNoMessageBoxEventArgs = e as YesNoMessageBoxEventArgs;

             if (yesNoMessageBoxEventArgs.IsPressedYesInMessageBox)
             {
                r_TicTacToeGameLogic.InitializeSession();
             }
             else
             {
                 r_FormGame.Close();
             }
         }

         private void formGame_GameDetailsUpdated(object sender, EventArgs e)
         {
            EventGameDetailsArguments gameDetails = e as EventGameDetailsArguments;

            r_TicTacToeGameLogic.InitGame(gameDetails.Player1Name, gameDetails.Player2Name, gameDetails.BoardSize, gameDetails.Player2Type);
         }

    }
}
