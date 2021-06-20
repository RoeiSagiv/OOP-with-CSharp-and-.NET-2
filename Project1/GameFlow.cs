using System;
using FrontProgram;
using BackProgram;

namespace MidProgram
{
    public class GameFlow
    {
        private const int k_NumberOfPlayers = 2;
        private static Game m_ReversedTicTacToeGame;
        private static Player[] m_PlayersOfTheGame;
        private static ComputerLogic m_CompLogic;

        private static Player[] InitPlayers()
        {
            Player[] ticTacToePlayers = new Player[k_NumberOfPlayers];
            string[] ticTacToePlayersNames = new string[k_NumberOfPlayers];
            ticTacToePlayersNames = GameInterface.GetNameOfThePlayersFromUsers();
            Player firstPlayer = new Player(ticTacToePlayersNames[0]);
            ticTacToePlayers[0] = firstPlayer;
            if(ticTacToePlayersNames[1] != "-1")
            {
                Player secondPlayer = new Player(ticTacToePlayersNames[1]);
                secondPlayer.PlayerSymbol = 'O';
                ticTacToePlayers[1] = secondPlayer;
            }
            else
            {
                Player computerPlayer = new Player();
                ticTacToePlayers[1] = computerPlayer;
            }

            return ticTacToePlayers;
        }

        internal static void InitGame()
        {
            GameInterface.WelcomeToTheGame();
            m_PlayersOfTheGame = InitPlayers();
            int sizeOfSquareBoard = GameInterface.GetSizeTicTacToeMatrix();
            m_ReversedTicTacToeGame = new Game(sizeOfSquareBoard, m_PlayersOfTheGame);
            RunGame();
        }

        private static void RunGame()
        {
            GameInterface.ClearAndPrintBoardGame(m_ReversedTicTacToeGame.TicTacToeBoard.ShowMatrix().ToString());
            PlayTurn();   
        }

        private static void EndGame()
        {
            if(m_ReversedTicTacToeGame.TicTacToeBoard.CheckIfSequence() == "X")
            {
                m_PlayersOfTheGame[1].ScoreOfPlayer++;
                GameInterface.PrintWinnerLooserStatus(m_PlayersOfTheGame[1], m_PlayersOfTheGame[0]);
                PlayAnotherGame();
            }
            else if(m_ReversedTicTacToeGame.TicTacToeBoard.CheckIfSequence() == "O")
            {
                m_PlayersOfTheGame[0].ScoreOfPlayer++;
                GameInterface.PrintWinnerLooserStatus(m_PlayersOfTheGame[0], m_PlayersOfTheGame[1]);
                PlayAnotherGame();
            }
            else if(m_ReversedTicTacToeGame.TicTacToeBoard.CheckIfMatrixFull())
            {
                GameInterface.PrintTieStatus(m_PlayersOfTheGame[0], m_PlayersOfTheGame[1]);
                PlayAnotherGame();
            }
        }

        private static void PlayAnotherGame()
        {
            bool playAnotherGame = GameInterface.CheckIfToPlayAgain();
            if(playAnotherGame)
            {
                m_ReversedTicTacToeGame.TicTacToeBoard.ClearTicTacToeBoard();
                RunGame();
            }
            else
            {
                GameInterface.CheckIfToQuitGame("Q");
            }
        }

        private static void PlayTurn()
        {
            bool isCellOccupied = false;
            int[] positionSymbol;
            int playerChoosenRow = 0;
            int playerChoosenColumn = 0;
            Player playerPlayingNow = m_PlayersOfTheGame[0];
            while (!m_ReversedTicTacToeGame.TicTacToeBoard.CheckIfMatrixFull() && (!(m_ReversedTicTacToeGame.TicTacToeBoard.CheckIfSequence() == "X") && !(m_ReversedTicTacToeGame.TicTacToeBoard.CheckIfSequence() == "O")))
            {
                if(playerPlayingNow.NameOfPlayer == "Computer")
                {
                    m_CompLogic = new ComputerLogic(); 
                    positionSymbol = m_CompLogic.ChooseRandomCell(m_ReversedTicTacToeGame);
                }
                else
                {
                    positionSymbol = GameInterface.GetCellToPutPlayerSymbol();
                }

                playerChoosenRow = positionSymbol[0];
                playerChoosenColumn = positionSymbol[1];
                isCellOccupied = m_ReversedTicTacToeGame.TicTacToeBoard.CheckIfCellEmpty(playerChoosenRow - 1, playerChoosenColumn - 1);
                if(!isCellOccupied && playerPlayingNow.NameOfPlayer != "Computer")
                {
                    GameInterface.CellOccupied();
                     continue;
                }
                else if(!isCellOccupied && playerPlayingNow.NameOfPlayer == "Computer")
                {
                    continue;
                }

                m_ReversedTicTacToeGame.TicTacToeBoard.EnterNewSymbolToMatrix(playerPlayingNow, playerChoosenRow, playerChoosenColumn);
                GameInterface.ClearAndPrintBoardGame(m_ReversedTicTacToeGame.TicTacToeBoard.ShowMatrix().ToString());
                playerPlayingNow = ChangeTurn(playerPlayingNow);
            }

            EndGame();
        }

         private static Player ChangeTurn(Player i_PlayerPlayingNow)
         {
            Player playerPlayingNow = i_PlayerPlayingNow;
            if(playerPlayingNow.NameOfPlayer == m_PlayersOfTheGame[0].NameOfPlayer)
            {
                playerPlayingNow = m_PlayersOfTheGame[1];
            }
            else
            {
                playerPlayingNow = m_PlayersOfTheGame[0];
            }

            return playerPlayingNow;
         }
    }
}
