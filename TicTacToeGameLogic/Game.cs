using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGameLogic
{
    public class Game
    {
        internal Board m_Board { get; set; }
        internal Player m_Player1;
        internal Player m_Player2;
        internal eFinishGameType m_FinishGameType { get; set; }
        private int m_MatrixSize;
        private Player[] m_PlayersArr;
        private short m_CurrPlayerIndex;
        private short m_PrevPlayerIndex;

        public event Action<Game> GameStarted;
        public event Action<Game> GameFinished;
        public event Action SwitchedPlayers;
        public Game()
        {
            m_Board = null;
            m_Player1 = null;
            m_Player2 = null;
            m_MatrixSize = 0;
            m_PlayersArr = null;
            m_FinishGameType = eFinishGameType.Win;
        }

        // < ------------------ INIT METHODS ------------------ >
        public void InitGameLogicBoard(Board i_Board)
        {
            m_Board = i_Board;
        }

        public void InitGame(
            string i_Player1Name, 
            string i_Player2Name, 
            int i_BoardSize, 
            ePlayerType i_Player2Type)
        {
            m_Board = new Board(m_MatrixSize);
            m_Player1 = new Player(eCell.P1, i_Player1Name, ePlayerType.Human);
            m_Player2 = new Player(eCell.P2, i_Player2Name, i_Player2Type);
            initPlayersArr();
            onGameStarted();
        }
        public void InitializeSession()
        {
            m_Board.initCellsMatrix();
            m_PlayersArr[0] = m_Player1;
            m_PlayersArr[1] = m_Player2;
            onGameStarted();
        }

        private void initPlayersArr()
        {
            m_PlayersArr = new Player[2] { m_Player1, m_Player2 };
        }

        // < ------------------ EVENT ACTION METHODS ------------------ >
        private void onGameStarted()
        {
            GameStarted?.Invoke(this);
        }

        private void onGameFinished()
        {
            GameFinished?.Invoke(this);
        }
        private void onSwitchedPlayers()
        {
            SwitchedPlayers?.Invoke();
        }

        // < ------------------ CHECK METHODS ------------------ >
        public bool CheckTie(Board i_board)
        {
            bool isFullFlag = false;
            if (i_board.IsBoardFull())
            {
                isFullFlag = true;
            }
            return isFullFlag;
        }

        public bool CheckIfPlayerWin(int i_Row, int i_Col, eCell playerShape,Board i_board)
        {
            
            bool result = false;
            result = i_board.CheckRowWin(i_Row, playerShape) || i_board.CheckColWin(i_Col, playerShape) || i_board.CheckDiagonalWin(playerShape);
            if(result) { onGameFinished(); }
            return result;
        }

        // < ------------------ LOGIC METHODS ------------------ >
        public void SwitchPlayer()
        {
            m_PrevPlayerIndex = m_CurrPlayerIndex;

            if (m_CurrPlayerIndex == 0)
            {
                m_CurrPlayerIndex++;
            }
            else
            {
                m_CurrPlayerIndex--;
            }
            onSwitchedPlayers();
        }

        public void FindBestCell(
            eCell[,] i_Mat,
            int i_Size,
            eCell i_PlayerShape,
            out int o_BestRow,
            out int o_Bestcol)
        {
            int minRow = 0, minCol = 0, minCount = i_Size * i_Size, count = 0;
            for (int i = 0; i < i_Size; i++)
            {
                count = 0;
                for (int j = 0; j < i_Size; j++)
                {
                    count = 0;
                    if (i_Mat[i, j] == eCell.Empty)
                    {
                        count += CountInRow(i_Mat, i_Size, i_PlayerShape, i);
                        count += CountInCol(i_Mat, i_Size, i_PlayerShape, j);
                        if (i == j)
                        {
                            count += CountInDiagonal(i_Mat, i_Size, i_PlayerShape);
                        }
                        if (j == i_Size - i - 1)
                        {
                            count += CountInDiagonal(i_Mat, i_Size, i_PlayerShape);
                        }
                        if (count < minCount)
                        {
                            minCount = count;
                            minRow = i;
                            minCol = j;
                        }
                    }
                }
            }
            o_BestRow = minRow;
            o_Bestcol = minCol;
        }

        public void FindRandCell(
           eCell[,] i_Mat,
           int i_Size,
           eCell i_PlayerShape,
           ref int ir_BestRow,
           ref int ir_Bestcol)
        {
            Random random = new Random();
            int min = 0, max = i_Size ;
            bool foundCell = false;
            int randRow;
            int randCol;
            while(!foundCell) 
            {
                randRow = random.Next(min, max);
                randCol = random.Next(min, max);
                if (i_Mat[randRow, randCol] == eCell.Empty)
                {
                    ir_BestRow = randRow;
                    ir_Bestcol = randCol;
                    foundCell = true;
                }
            }          
        }

        public int CountInDiagonal(eCell[,] i_Mat, int i_Size, eCell i_Shape)
        {
            int count = 0;
            for (int i = 0; i < i_Size; i++)
            {
                if (i_Mat[i, i] == i_Shape)
                {
                    count++;
                }
            }

            for (int i = 0; i < i_Size; i++)
            {
                if (i_Mat[(i_Size - 1) - i, i] == i_Shape)
                {
                    count++;
                }
            }
            return count;
        }

        public int CountInRow(eCell[,] i_Mat, int i_Size, eCell i_Shape, int i_Row)
        {
            int count = 0;
            for (int i = 0; i < i_Size; i++)
            {
                if (i_Mat[i_Row, i] == i_Shape)
                {
                    count++;
                }
            }
            return count;
        }

        public int CountInCol(eCell[,] i_Mat, int i_Size, eCell i_Shape, int i_Col)
        {
            int count = 0;
            for (int i = 0; i < i_Size; i++)
            {
                if (i_Mat[i, i_Col] == i_Shape)
                {
                    count++;
                }
            }
            return count;
        }

        public Player Player1
        {
            get
            {
                return m_Player1;
            }

            set
            {
                m_Player1 = value;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }

            set
            {
                m_Player2 = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_PlayersArr[m_CurrPlayerIndex];
            }
        }

        public short CurrentIndexPlayer
        {
            get
            {
                return m_CurrPlayerIndex;
            }
        }
        public short PreviousIndexPlayer
        {
            get
            {
                return m_PrevPlayerIndex;
            }
        }
        public Player PrevPlayer
        {
            get
            {
                return m_PlayersArr[m_PrevPlayerIndex];
            }
        }

        public eFinishGameType FinishReason
        {
            get
            {
                return m_FinishGameType;
            }

            set
            {
                m_FinishGameType = value;
            }
        }



    }
}
