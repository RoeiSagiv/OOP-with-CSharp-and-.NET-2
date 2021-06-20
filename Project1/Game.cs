namespace BackProgram
{
    internal class Game
    {
        private readonly TicTacToeMatrix r_TicTacToeBoard;
        private readonly Player[] r_Players;

        internal Game(int i_PlayerChoosenSquareMatrixSize, Player[] i_PlayersOfTheGame) 
        {
            r_TicTacToeBoard = new TicTacToeMatrix(i_PlayerChoosenSquareMatrixSize);
            r_Players = i_PlayersOfTheGame;
        }

        internal TicTacToeMatrix TicTacToeBoard
        {
            get
            {
                return r_TicTacToeBoard;
            }
        }

        internal Player[] Players
        {
            get
            {
                return r_Players;
            }
        }
    }
}
