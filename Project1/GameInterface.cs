using System;
using System.Threading;
using BackProgram;

namespace FrontProgram
{
    internal class GameInterface
    {
        private static int MinSizeOfSquareTicTacToeMatrix = 3;
        private static int MaxSizeOfSquareTicTacToeMatrix = 9;
        private static string QuitSymbol = "Q";
        private static int m_TicTacToeSquareSize = 0;

        public static void WelcomeToTheGame()
        {
            Console.WriteLine("Welcome to the best game - reversed TicTacToe!!!");
            Console.WriteLine("First, you will be ask to enter your name.");
            Console.WriteLine("Second, you will be ask to choose the size of the board.");
            Console.WriteLine("Third, you will be ask to choose whether to play in player vs player mode or player vs computer mode. ");
            Console.WriteLine("The progress of the game:");
            Console.WriteLine("1. Each player will get a unique symball - X or O");
            Console.WriteLine("2. Each turn the player will choose a cell to put his symball in the board");
            Console.WriteLine("3. The player that will make a sequence, his the loser!! and the other player is the winner!!");
            Console.WriteLine("Lets start - enjoy the game!");
        }

        public static String[] GetNameOfThePlayersFromUsers()
        {
            string[] TicTacToePlayersFromUsers = new string[2];
            string NameOfFirstPlayerFromUser;
            Console.WriteLine("Please enter first player name:");
            NameOfFirstPlayerFromUser = Console.ReadLine();
            CheckIfToQuitGame(NameOfFirstPlayerFromUser);
            TicTacToePlayersFromUsers[0] = NameOfFirstPlayerFromUser;
            string HelloPlayer = string.Format("Hello, {0}!{1}", NameOfFirstPlayerFromUser, Environment.NewLine);
            Console.WriteLine(HelloPlayer);

            if(CheckIfWeHaveAnoterPlayer()) 
            {
                string NameOfSecondPlayerFromUser;
                Console.WriteLine("Please enter second player name:");
                NameOfSecondPlayerFromUser = Console.ReadLine();
                CheckIfToQuitGame(NameOfSecondPlayerFromUser);
                TicTacToePlayersFromUsers[1] = NameOfSecondPlayerFromUser;
                HelloPlayer = string.Format("Hello, {0}!{1}", NameOfSecondPlayerFromUser, Environment.NewLine);
                Console.WriteLine(HelloPlayer);
            }
            else 
            {
                // string -1 means the player is computer and this is name in the array
                TicTacToePlayersFromUsers[1] = "-1";
                Console.WriteLine("You will play in player vs computer mode,Good Luck!");
            }

            return TicTacToePlayersFromUsers;
        }

        internal static int GetSizeTicTacToeMatrix() 
        {
            int SizeOfSqureTicTacToeBoardOptionInput = 0;
            int SizeOfSqureTicTacToeBoard = 0;
            string SizeOfSqureTicTacToeBoardFromUser = string.Empty;
            Console.WriteLine("Please enter the size of the borad which you want to play in:");
            Console.WriteLine("Notice!!!");
            string ValidBoundedSizeMatrix = string.Format("The Size of the board can't be less than {0} and be can't above {1}{2}", MinSizeOfSquareTicTacToeMatrix, MaxSizeOfSquareTicTacToeMatrix, Environment.NewLine);
            Console.WriteLine(ValidBoundedSizeMatrix);
            SizeOfSqureTicTacToeBoardFromUser = Console.ReadLine();
            bool goodInput = int.TryParse(SizeOfSqureTicTacToeBoardFromUser, out SizeOfSqureTicTacToeBoardOptionInput);
            CheckIfToQuitGame(SizeOfSqureTicTacToeBoardFromUser);
            while(!goodInput || (SizeOfSqureTicTacToeBoardOptionInput < MinSizeOfSquareTicTacToeMatrix || SizeOfSqureTicTacToeBoardOptionInput > MaxSizeOfSquareTicTacToeMatrix))
            {
                string InvalidInputSizeOfBoard = string.Format("Notice! your input {0} is invalid!{1}Please Enter a new number as mentioned:", SizeOfSqureTicTacToeBoardOptionInput, Environment.NewLine);
                Console.WriteLine(InvalidInputSizeOfBoard);
                SizeOfSqureTicTacToeBoardFromUser = Console.ReadLine();
                CheckIfToQuitGame(SizeOfSqureTicTacToeBoardFromUser);
                goodInput = int.TryParse(SizeOfSqureTicTacToeBoardFromUser, out SizeOfSqureTicTacToeBoardOptionInput);
            }

            m_TicTacToeSquareSize = SizeOfSqureTicTacToeBoardOptionInput;
            SizeOfSqureTicTacToeBoard = SizeOfSqureTicTacToeBoardOptionInput;
            return SizeOfSqureTicTacToeBoard;
        }

        private static bool CheckIfWeHaveAnoterPlayer()
        {
            bool haveSecondPlayer = false;
            string againstPlayerOrComputer = string.Empty;
            string againstAnotherPlayerMsg = "Do you want to play against another player? enter YES or NO";
            Console.WriteLine(againstAnotherPlayerMsg);
            string againstComputerMsg = "Notice! if you enter NO you will play against the computer";
            Console.WriteLine(againstComputerMsg);
            againstPlayerOrComputer = Console.ReadLine();
            while(!"YES".Equals(againstPlayerOrComputer, StringComparison.CurrentCultureIgnoreCase) && !"NO".Equals(againstPlayerOrComputer, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Try Again! please enter only YES or NO");
                Console.WriteLine(againstAnotherPlayerMsg);
                Console.WriteLine(againstComputerMsg);
                againstPlayerOrComputer = Console.ReadLine();
            }

            if("YES".Equals(againstPlayerOrComputer, StringComparison.CurrentCultureIgnoreCase))
            {
                haveSecondPlayer = true;
            }

            return haveSecondPlayer;
        }

        public static int[] GetCellToPutPlayerSymbol()
        {
            int SizeOfRows = m_TicTacToeSquareSize;
            int SizeOfColumn = m_TicTacToeSquareSize;
            int[] CellPosition = new int[2];
            int RowNumber = 0;
            int ColumnNumber = 0;
            string RowNumberFromUser = string.Empty;
            string ColumnNumberFromUser = string.Empty;
            string EnterCellPositionMsg = "Its your turn! Please enter the cell position";
            Console.WriteLine(EnterCellPositionMsg);
            string NoticeCellPositionMsg = "Notice! you need to enter two numbers";
            Console.WriteLine(NoticeCellPositionMsg);
            string RowNumberMsg = "Enter the row number:";
            Console.WriteLine(RowNumberMsg);
            RowNumberFromUser = Console.ReadLine();
            CheckIfToQuitGame(RowNumberFromUser);
            bool rowGoodInput = int.TryParse(RowNumberFromUser, out RowNumber);
            while(!rowGoodInput || (RowNumber < 1 || RowNumber > SizeOfRows))
            {
                Console.WriteLine("Try Again!");
                Console.WriteLine(EnterCellPositionMsg);
                Console.WriteLine(NoticeCellPositionMsg);
                Console.WriteLine(RowNumberMsg);
                RowNumberFromUser = Console.ReadLine();
                CheckIfToQuitGame(RowNumberFromUser);
                rowGoodInput = int.TryParse(RowNumberFromUser, out RowNumber);
            }

            string ColumnNumberMsg = "Enter the column number:";
            Console.WriteLine(ColumnNumberMsg);
            ColumnNumberFromUser = Console.ReadLine();
            CheckIfToQuitGame(ColumnNumberFromUser);
            bool columnGoodInput = int.TryParse(ColumnNumberFromUser, out ColumnNumber);
            while(!columnGoodInput || (ColumnNumber < 1 || ColumnNumber > SizeOfColumn))
            {
                Console.WriteLine("Try Again!");
                Console.WriteLine(EnterCellPositionMsg);
                Console.WriteLine(NoticeCellPositionMsg);
                Console.WriteLine(ColumnNumberMsg);
                ColumnNumberFromUser = Console.ReadLine();
                CheckIfToQuitGame(ColumnNumberFromUser);
                columnGoodInput = int.TryParse(ColumnNumberFromUser, out ColumnNumber);
            }

            CellPosition[0] = RowNumber;
            CellPosition[1] = ColumnNumber;

            return CellPosition;
        }

        internal static void CheckIfToQuitGame(string i_FromUser)
        {
            if (i_FromUser.Equals(QuitSymbol))
            {
                ClearTheConsole();
                Console.WriteLine("We understand you want to quit the game.");
                Console.WriteLine("Thank you! we hope to see you again playing the game reversed TicTacToe");
                Thread.Sleep(4000);
                Environment.Exit(0);
            }
        }

        internal static void PrintWinnerLooserStatus(Player i_WinnerPlayer, Player i_LooserPlayer) 
        {
            Console.WriteLine(string.Format("The Winner of the game is: {0}{1}", i_WinnerPlayer.NameOfPlayer, Environment.NewLine));
            Console.WriteLine(string.Format("The score of {0}: {1}{2}", i_WinnerPlayer.NameOfPlayer, i_WinnerPlayer.ScoreOfPlayer, Environment.NewLine));
            Console.WriteLine(string.Format("The Looser of the game is: {0}{1}", i_LooserPlayer.NameOfPlayer, Environment.NewLine));
            Console.WriteLine(string.Format("The score of {0}: {1}{2}", i_LooserPlayer.NameOfPlayer, i_LooserPlayer.ScoreOfPlayer, Environment.NewLine));
        }

        internal static void PrintTieStatus(Player i_FirstPlayer, Player i_SecondPlayer)
        { 
            Console.WriteLine(string.Format("The score of {0}: {1}{2}", i_FirstPlayer.NameOfPlayer, i_FirstPlayer.ScoreOfPlayer, Environment.NewLine));
            Console.WriteLine(string.Format("The score of {0}: {1}{2}", i_SecondPlayer.NameOfPlayer, i_SecondPlayer.ScoreOfPlayer, Environment.NewLine));
            Console.WriteLine(string.Format("There is no winner... IT'S A TIE!! {0}", Environment.NewLine));
        }
       
        internal static bool CheckIfToPlayAgain() 
        {
            bool ToPlayAgain = false; 
            string PlayingAgainMsg = "Do you want to play again? enter YES or NO";
            Console.WriteLine(PlayingAgainMsg);
            string EndGameMsg = "Notice! if you enter NO you will exit the game";
            Console.WriteLine(EndGameMsg);
            string PlayAgain = Console.ReadLine();
            CheckIfToQuitGame(PlayAgain);
            while (!"YES".Equals(PlayAgain, StringComparison.CurrentCultureIgnoreCase) && !"NO".Equals(PlayAgain, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Try Again! please enter only YES or NO");
                Console.WriteLine(PlayingAgainMsg);
                Console.WriteLine(EndGameMsg);
                PlayAgain = Console.ReadLine();
                CheckIfToQuitGame(PlayAgain);
            }

            if("YES".Equals(PlayAgain, StringComparison.CurrentCultureIgnoreCase))
            {
                ToPlayAgain = true;
            }

            return ToPlayAgain;
        }

        internal static void ClearTheConsole()
        {             
            Ex02.ConsoleUtils.Screen.Clear();
        }

        internal static void ClearAndPrintBoardGame(string i_BoardGame)
        {
            ClearTheConsole();
            Console.WriteLine(i_BoardGame);
        }

        internal static void CellOccupied()
        {
            Console.WriteLine("Try Again! this cell is occupied");
        }
    }     
}
