using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGameLogic
{
    public class Player
    {
        // < ------------------ PROPERTIES ------------------ >
        internal eCell m_PlayerShape { get; set; }
        internal string m_Name;
        internal int m_Points;
        internal ePlayerType playerType { get; set; }
        public int Points { get { return m_Points; } set { m_Points = value; } }
        public string Name { get { return m_Name; } set { m_Name = value; } }
        // C'tor
        public Player(
            eCell i_PlayerShape,
            string i_Name, 
            ePlayerType i_PlayerType)
        {
            m_Name = i_Name;
            m_PlayerShape = i_PlayerShape;
            playerType = i_PlayerType;
        }

    }
}
