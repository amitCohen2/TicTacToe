using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeGameLogic;
using TicTacToeWinUI.Properties;
using Microsoft.VisualBasic.ApplicationServices;


namespace TicTacToeWinUI
{
    public partial class FormGame : Form
    {
        private const int k_PictureBoxSize = 50;
        private const int k_Padding = 2;
        private const int k_WidthExtention = 20;
        private const int k_HeightExtention = 100;
        private const int k_HeightMargin = 60;
        private const int k_WidthMargin = 5;
        private const int k_AlignToLeftLabelsWidth = 4;
        private const int k_SleepAfterPlayerMove = 150;
        private FormSettings m_FormGameSettings;
        private PictureBox[,] m_PictureBoxBoard;
        private EventGameDetailsArguments m_EventGameDetailsArguments;
        private Board m_Board;
        private Game m_Game;


        private bool m_IsUserTurn = true;
        private bool m_IsClickProcessing = false;
        private bool m_IsUserClickValid = false;
        private bool m_IsGameOver = false;

        public EventHandler GameDetailsInit;

        public EventHandler YesNoMessageBoxClicked;
        public FormGame()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            m_FormGameSettings = new FormSettings();
            m_FormGameSettings.ShowDialog();

            if (m_FormGameSettings.DialogResult == DialogResult.OK)
            {
                string iconPath = Path.Combine(UIResources.ResourcesFolderPath, UIResources.Icon);
                this.Icon = new Icon(iconPath);
                initFormBoardGame();
                initGameDetails();
            }
        }


        private void initGameDetails()
        {
            m_EventGameDetailsArguments = new EventGameDetailsArguments(
            m_FormGameSettings.Player1Name,
            m_FormGameSettings.Player2Name,
            m_FormGameSettings.BoardCols * m_FormGameSettings.BoardRows,
            m_FormGameSettings.Player2Type);

            labelPlayer1.Text = "Player 1: " + m_FormGameSettings.Player1Name;
            labelPlayer2.Text = "Player 2: " + m_FormGameSettings.Player2Name;
            labelPlayer1.Location = new Point(0, labelPlayer1.Top);
            labelScore1.Location = new Point(0, labelPlayer1.Bottom + k_WidthMargin);
            labelPlayer2.Location = new Point(ClientSize.Width - labelPlayer2.Width - labelPlayer2.Text.Length, labelPlayer2.Top);
            labelScorePlayer1.Location = new Point(labelScore1.Width + 1, labelScorePlayer1.Bottom + k_WidthMargin);
            labelScorePlayer2.Location = new Point(ClientSize.Width - labelPlayer1.Width - labelPlayer1.Text.Length, labelPlayer2.Bottom + k_WidthMargin);
            labelScore2.Location = new Point(ClientSize.Width - labelPlayer2.Width - labelPlayer2.Text.Length, labelPlayer2.Bottom + k_WidthMargin);
        }

        public void SetNewSession(int i_Player1Sccore, int i_Player2Sccore, string i_CurrentPlayer)
        {
            m_EventGameDetailsArguments.SetPlayers(i_CurrentPlayer);
            initPlayersLabels(i_Player1Sccore, i_Player2Sccore);
        }

        private void initPlayersLabels(int i_Player1Points, int i_Player2Points)
        {
            if (m_EventGameDetailsArguments.Player2Name == m_FormGameSettings.Computer)
            {
                labelPlayer2.Text = string.Format("{0}: {1}", Enum.GetName(typeof(ePlayerType), ePlayerType.Computer), i_Player2Points);
            }
            else if (m_EventGameDetailsArguments.Player2Name == m_FormGameSettings.ComputerHard)
            {
                labelPlayer2.Text = string.Format("{0}: {1}", Enum.GetName(typeof(ePlayerType), ePlayerType.ComputerHard), i_Player2Points);

            }
            else
            {
                labelPlayer2.Text = string.Format("{0}: {1}", m_EventGameDetailsArguments.Player2Name, i_Player2Points);
            }

            labelPlayer1.Text = string.Format("{0}: {1}", m_EventGameDetailsArguments.Player1Name, i_Player1Points);
        }

        private void initFormBoardGame()
        {
            m_Game = new Game();
            m_PictureBoxBoard = new PictureBox[m_FormGameSettings.BoardRows, m_FormGameSettings.BoardCols];
            int formWidth = (2 * k_WidthMargin) + (k_PictureBoxSize * m_FormGameSettings.BoardCols) + k_WidthExtention;
            int formHeight = (2 * k_HeightMargin) + (k_PictureBoxSize * m_FormGameSettings.BoardRows) + k_HeightExtention;
            m_Board = new Board(m_FormGameSettings.BoardRows);
            m_IsGameOver = false;
            this.ClientSize = new Size(formWidth, formHeight);

            for (int i = 0; i < m_FormGameSettings.BoardRows; i++)
            {
                for (int j = 0; j < m_FormGameSettings.BoardCols; j++)
                {
                    m_PictureBoxBoard[i, j] = new PictureBox();
                    initPictureBox(m_PictureBoxBoard[i, j], i, j);
                    Controls.Add(m_PictureBoxBoard[i, j]);
                    m_PictureBoxBoard[i, j].Click += pictureBox_ClickHndler;
                }
            }
        }

        private void pictureBox_ClickHndler(object sender, EventArgs e)
        {
            if (m_IsUserTurn && !m_IsClickProcessing)
            {
                m_IsClickProcessing = true;
                int o_BestRow;
                int o_Bestcol;

                PictureBox pictureBoxClicked = sender as PictureBox;
                if (pictureBoxClicked != null)
                {
                    m_IsUserClickValid = pictureBox_Click(sender, e);
                    if (m_IsUserClickValid && !m_IsGameOver)
                    {
                        m_IsUserTurn = false;
                        DisablePictureBoxes();
                        System.Threading.Thread.Sleep(k_SleepAfterPlayerMove);                       
                        if (m_FormGameSettings.Player2Type == ePlayerType.ComputerHard)
                        {
                            m_Game.FindBestCell(m_Board.m_GameMatrix, m_Board.GetMatsize(), eCell.P2, out o_BestRow, out o_Bestcol);
                            pictureBox_Click(m_PictureBoxBoard[o_BestRow, o_Bestcol], EventArgs.Empty);
                        }
                        else if (m_FormGameSettings.Player2Type == ePlayerType.Computer)
                        {
                            int randRow = 0;
                            int randCol = 0;
                            m_Game.FindRandCell(m_Board.m_GameMatrix, m_Board.GetMatsize(), eCell.P2, ref randRow, ref randCol);
                            pictureBox_Click(m_PictureBoxBoard[randRow, randCol], EventArgs.Empty);
                        }
                        EnablePictureBoxes();
                        m_IsUserTurn = true;
                    }
                }
                m_IsClickProcessing = false;
            }

        }

        private void DisablePictureBoxes()
        {
            foreach (PictureBox pictureBox in m_PictureBoxBoard)
            {
                pictureBox.Enabled = false;
            }
        }

        private void EnablePictureBoxes()
        {
            foreach (PictureBox pictureBox in m_PictureBoxBoard)
            {
                pictureBox.Enabled = true;
            }
        }
        private void PlaySound(string soundName)
        {
            string soundFilePath = Path.Combine(UIResources.ResourcesFolderPath, soundName);

            if (File.Exists(soundFilePath))
            {
                using (SoundPlayer player = new SoundPlayer(soundFilePath))
                {
                    player.Play();
                }
            }
            else
            {
                // Handle the case where the sound file is not found
                MessageBox.Show("Sound file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool pictureBox_Click(object sender, EventArgs e)
        {
            PlaySound(UIResources.ButtonClickSound);

            PictureBox picturBoxClicked = sender as PictureBox;
            bool enablePictureBox = false;
            string cellImage = string.Empty;
            eCell cellType = eCell.Empty;

            if (picturBoxClicked != null && picturBoxClicked.Image == null)
            {
                switchPlayerIndex(out cellType);

                int clickedRow = -1, clickedCol = -1, numRows = (int)Math.Sqrt(m_PictureBoxBoard.Length);
                int numCols = numRows;
                for (int row = 0; row < numRows; row++)
                {
                    for (int col = 0; col < numCols; col++)
                    {
                        if (m_PictureBoxBoard[row, col] == picturBoxClicked)
                        {
                            clickedRow = row;
                            clickedCol = col;
                            break;
                        }
                    }
                    if (clickedRow != -1) // Break outer loop if the picture box is found
                    {
                        break;
                    }
                }

                updatePictureBox(picturBoxClicked, cellType, m_Board, clickedRow, clickedCol);
                m_IsUserClickValid = true;
            }
            else
            {
                m_IsUserClickValid = false;
            }

            return m_IsUserClickValid;
        }

        public void ContinuePlayingMessageBox(Game i_GameLogic)
        {
            DialogResult userChoice = new DialogResult();
            StringBuilder message = new StringBuilder();
            YesNoMessageBoxEventArgs yesNoMessageBoxEventArgs = null;
            bool wantToPlayAnotherSession = false;

            if (i_GameLogic.FinishReason == eFinishGameType.Tie)
            {
                message.Append("Tie!");
            }
            else if (i_GameLogic.FinishReason == eFinishGameType.Win)
            {
                message.Append(string.Format("{0} Won!", i_GameLogic.PrevPlayer.Name));
            }

            message.Append(Environment.NewLine);
            message.Append("Another Round?");
            userChoice = MessageBox.Show(message.ToString(), "Tic Tac Toe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            wantToPlayAnotherSession = userChoice == DialogResult.Yes;
            yesNoMessageBoxEventArgs = new YesNoMessageBoxEventArgs(wantToPlayAnotherSession);
            onYesNoMessageBoxClicked(yesNoMessageBoxEventArgs);
        }

        private void onYesNoMessageBoxClicked(YesNoMessageBoxEventArgs i_YesNoMessageBoxEventArgs)
        {
            YesNoMessageBoxClicked?.Invoke(this, i_YesNoMessageBoxEventArgs);
        }

        private void switchPlayerIndex(out eCell o_CellType)
        {
            if (m_EventGameDetailsArguments.CurrentIndexPlayer == 0)
            {
                o_CellType = eCell.P1;
                m_EventGameDetailsArguments.CurrentIndexPlayer++;

                swapLabelFonts(labelPlayer1, labelPlayer2);
                swapLabelFonts(labelScore1, labelScore2);
                swapLabelFonts(labelScorePlayer1, labelScorePlayer2);

            }
            else
            {
                o_CellType = eCell.P2;
                m_EventGameDetailsArguments.CurrentIndexPlayer--;
                swapLabelFonts(labelPlayer2, labelPlayer1);
                swapLabelFonts(labelScore2, labelScore1);
                swapLabelFonts(labelScorePlayer2, labelScorePlayer1);
            }
        }
        private void swapLabelFonts(Label i_Label1, Label i_Label2)
        {
            FontStyle tempFont = i_Label1.Font.Style;
            i_Label1.Font = new Font(i_Label1.Font, i_Label2.Font.Style);
            i_Label2.Font = new Font(i_Label2.Font, tempFont);
        }
        public void SwitchPlayers()
        {
            string playerNameSaver = m_EventGameDetailsArguments.CurrentPlayer;

            m_EventGameDetailsArguments.CurrentPlayer = m_EventGameDetailsArguments.PreviousPlayer;
            m_EventGameDetailsArguments.PreviousPlayer = playerNameSaver;
            m_EventGameDetailsArguments.CurrentPlayerSign = m_EventGameDetailsArguments.CurrentPlayerSign == eCell.P1 ? eCell.P2 : eCell.P1;
        }

        public void updatePictureBox(PictureBox i_PictureBox, eCell i_CellType, Board i_board, int clickedRow, int clickedCol)
        {

            string pictureBoxSignPath = i_CellType == eCell.P1 ? UIResources.XSign : UIResources.OSign;
            string fullFilePath = Path.Combine(UIResources.ResourcesFolderPath, pictureBoxSignPath);
            i_PictureBox.Image = Image.FromFile(fullFilePath);
            i_PictureBox.Name = Enum.GetName(typeof(eCell), i_CellType);
            i_board.SetCell(clickedRow, clickedCol, i_CellType);
            if (m_Game.CheckIfPlayerWin(clickedRow, clickedCol, i_CellType, i_board))
            {
                m_IsGameOver = true;
                string winnerMessage;
                if (i_CellType == eCell.P1)
                {
                    if (m_FormGameSettings.Player2Type == ePlayerType.Computer || m_FormGameSettings.Player2Type == ePlayerType.ComputerHard)
                    {
                        PlaySound(UIResources.LoseSound);
                    }
                    else
                    {
                        PlaySound(UIResources.WinSound);
                    }
                    labelScorePlayer2.Text = (int.Parse(labelScorePlayer2.Text) + 1).ToString();
                    winnerMessage = "Player 2 wins!";
                }
                else
                {
                    PlaySound(UIResources.WinSound);
                    labelScorePlayer1.Text = (int.Parse(labelScorePlayer1.Text) + 1).ToString();
                    winnerMessage = "Player 1 wins!";
                }
                MessageBox.Show(winnerMessage, "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                anotherGame();
            }
            else if (m_Game.CheckTie(i_board))
            {
                m_IsGameOver = true;
                PlaySound(UIResources.TieSound);
                string winnerMessage = "it's a Tie!";
                MessageBox.Show(winnerMessage, "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelScorePlayer1.Text = (int.Parse(labelScorePlayer1.Text) + 1).ToString();
                labelScorePlayer2.Text = (int.Parse(labelScorePlayer2.Text) + 1).ToString();
                anotherGame();
            }
        }

        private void anotherGame()
        {
           // m_EventGameDetailsArguments.CurrentIndexPlayer = 1;
            DialogResult userChoice = new DialogResult();
           
            userChoice = MessageBox.Show(" do you want another game?", "Game over!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (userChoice == DialogResult.Yes)
            {
                clearPictureBoxes();
                m_Board.InitGameMatrix();
                m_IsGameOver = false;
            }
            else
            {
                m_IsGameOver = true;
                MessageBox.Show("Goodbye!", "Exiting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            
            m_IsUserClickValid = false;
        }

        private void clearPictureBoxes()
        {
            for (int row = 0; row < m_FormGameSettings.BoardRows; row++)
            {
                for (int col = 0; col < m_FormGameSettings.BoardCols; col++)
                {
                    m_PictureBoxBoard[row, col].Image = null;
                }
            }
        }

        private void initPictureBox(PictureBox i_PictureBox, int i_Rows, int i_Cols)
        {
            i_PictureBox.Size = new Size(k_PictureBoxSize, k_PictureBoxSize);
            i_PictureBox.Padding = new Padding(k_Padding, k_Padding, k_Padding, k_Padding);
            i_PictureBox.Location = new Point(k_WidthMargin + (k_PictureBoxSize * i_Cols), k_HeightMargin + (k_PictureBoxSize * i_Rows));
            i_PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            i_PictureBox.BorderStyle = BorderStyle.Fixed3D;
        }
    }
}
