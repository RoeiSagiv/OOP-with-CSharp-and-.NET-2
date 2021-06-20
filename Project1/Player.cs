namespace BackProgram
{
    internal class Player
    {
        private readonly string r_NameOfPlayer;
        private int m_ScoreOfPlayer;
        private char m_PlayerSymbol;

        internal Player(string i_NameOfPlayer)
        {
            r_NameOfPlayer = i_NameOfPlayer;
            m_ScoreOfPlayer = 0;
            m_PlayerSymbol = 'X';
        }

        /// .Ctor without params means that this player is computer.
        internal Player() 
        {
            r_NameOfPlayer = "Computer";
            m_ScoreOfPlayer = 0;
            m_PlayerSymbol = 'O';
        }
        
        internal string NameOfPlayer
        {
            get
            {
                return r_NameOfPlayer;
            }
        }

        internal int ScoreOfPlayer
        {
            get
            {
                return m_ScoreOfPlayer;
            }

            set
            {
                m_ScoreOfPlayer = value;
            }
        }

        internal char PlayerSymbol
        {
            get
            {
                return m_PlayerSymbol;
            }

            set
            {
                m_PlayerSymbol = value;
            }
        }
    }
}
