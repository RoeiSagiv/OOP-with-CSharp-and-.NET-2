using System;

namespace BackProgram
{
    internal class ComputerLogic
    {
        private const int k_SizeOfComputerPositionSymbol = 2;

        internal int[] ChooseRandomCell(Game i_ReversedTicTacToeGame) 
        {
            Random rnd = new Random();
            int computerRowRandom = 0;
            int computerColumnRandom = 0;
            int computerRandomPosition = rnd.Next(i_ReversedTicTacToeGame.TicTacToeBoard.MatrixEmptyCells.Count);
            int[] computerPositionSymbol = new int[k_SizeOfComputerPositionSymbol];

            int valueOfEmptyCellsMapping = (int)i_ReversedTicTacToeGame.TicTacToeBoard.MatrixEmptyCells[computerRandomPosition];
            computerColumnRandom = valueOfEmptyCellsMapping % 10;
            computerRowRandom = valueOfEmptyCellsMapping / 10;
            computerPositionSymbol[0] = computerRowRandom;
            computerPositionSymbol[1] = computerColumnRandom;
            return computerPositionSymbol;
        }
    }
}
