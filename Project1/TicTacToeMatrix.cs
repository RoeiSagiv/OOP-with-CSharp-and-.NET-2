using System.Text;
using System.Collections;

namespace BackProgram
{
    public class TicTacToeMatrix
    {
        private readonly int r_TicTacToeMatrixSize;
        private readonly int r_MatrixNumOfRow;
        private readonly int r_MatrixNumOfColumn;
        private char[,] m_TicTacToeMatrix;
        private int m_CountNumberOfOccupiedCells;
        private ArrayList m_MatrixEmptyCells;

        internal TicTacToeMatrix(int i_PlayerChoosenSquareMatrixSize)
        {
            m_TicTacToeMatrix = new char[i_PlayerChoosenSquareMatrixSize, i_PlayerChoosenSquareMatrixSize];
            r_TicTacToeMatrixSize = i_PlayerChoosenSquareMatrixSize * i_PlayerChoosenSquareMatrixSize;
            r_MatrixNumOfColumn = i_PlayerChoosenSquareMatrixSize;
            r_MatrixNumOfRow = i_PlayerChoosenSquareMatrixSize;
            m_CountNumberOfOccupiedCells = 0;
            m_MatrixEmptyCells = InitArrOfEmptyCells();
        }

        internal int TicTacToeMatrixSize
        {
            get
            {
                return r_TicTacToeMatrixSize;
            }
        }

        internal int MatrixNumOfColumn
        {
            get
            {
                return r_MatrixNumOfColumn;
            }
        }

        internal int MatrixNumOfRow
        {
            get
            {
                return r_MatrixNumOfRow;
            }
        }

        internal ArrayList MatrixEmptyCells
        {
            get
            {
                return m_MatrixEmptyCells;
            }
        }

        internal bool CheckIfCellEmpty(int i_PlayerChoosenRow, int i_PlayerChoosenColumn)
        {
            bool isCellEmpty = false;
            char symbolInCell = (char)this.m_TicTacToeMatrix.GetValue(i_PlayerChoosenRow, i_PlayerChoosenColumn);
            if(symbolInCell != 'X' && symbolInCell != 'O')
            {
                isCellEmpty = true;
            }

            return isCellEmpty;
        }

        internal int[] InitArrayOfEmptyCells()
        {
            int[] cellsInMatrix = new int[r_TicTacToeMatrixSize];
            int positionInCellsInMatrix = 0;
            while (positionInCellsInMatrix != r_TicTacToeMatrixSize)
            {
                for (int i = 1; i <= r_MatrixNumOfRow; i++)
                {
                    for (int j = 1; j <= r_MatrixNumOfColumn; j++)
                    {
                        cellsInMatrix[positionInCellsInMatrix] = (i * 10) + j;
                        positionInCellsInMatrix++;
                    }
                }
            }

            return cellsInMatrix;
        }
         
        internal ArrayList InitArrOfEmptyCells()
        {
            ArrayList arrayListEmptyCells = new ArrayList();
            int[] cellsInMatrix = InitArrayOfEmptyCells();
            for (int i = 0; i < cellsInMatrix.Length; i++)
            {
                arrayListEmptyCells.Add(cellsInMatrix[i]);
            }

            return arrayListEmptyCells;
        }

       internal void UpdateArrayListOfEmpteyCells(int i_PlayerChoosenRow, int i_PlayerChoosenColumn)
       {
            int cellToRemove = (i_PlayerChoosenRow * 10) + i_PlayerChoosenColumn;
            m_MatrixEmptyCells.Remove(cellToRemove);
       }
    
        internal bool CheckIfMatrixFull() 
        {
            bool isMatrixFull = false;
            if(m_CountNumberOfOccupiedCells == r_TicTacToeMatrixSize)
            {
                isMatrixFull = true;
            }

            return isMatrixFull;
        }

        internal void EnterNewSymbolToMatrix(Player i_PlayerTurn, int i_PlayerChoosenRow, int i_PlayerChoosenColumn)
        {
            if(CheckIfCellEmpty(i_PlayerChoosenRow - 1, i_PlayerChoosenColumn - 1))
            {
                m_TicTacToeMatrix.SetValue(i_PlayerTurn.PlayerSymbol, i_PlayerChoosenRow - 1, i_PlayerChoosenColumn - 1);
                m_CountNumberOfOccupiedCells++;
                UpdateArrayListOfEmpteyCells(i_PlayerChoosenRow - 1, i_PlayerChoosenColumn - 1);
            }
        }

        internal StringBuilder ShowMatrix()
        {
            int sizeOfTheMetrix = r_MatrixNumOfColumn;
            int numberOfEqualSign = (sizeOfTheMetrix * 4) + 1;
            StringBuilder ticTacToeBoard = new StringBuilder();
            ticTacToeBoard.Append("  ");
            for(int i = 0; i < r_MatrixNumOfColumn; i++)
            {
                ticTacToeBoard.Append((i + 1) + "   ");
            }

            for(int i = 0; i < r_MatrixNumOfRow; i++)
            {
                ticTacToeBoard.Append("\n");
                ticTacToeBoard.Append(i + 1);
                ticTacToeBoard.Append("|");
                for (int j = 0; j < r_MatrixNumOfColumn; j++)
                {
                    if (CheckIfCellEmpty(i, j))
                    {
                        ticTacToeBoard.Append("   " + "|");
                    }
                    else
                    {
                        ticTacToeBoard.Append(" " + m_TicTacToeMatrix[i, j] + " " + "|");
                    }
                }

                ticTacToeBoard.Append("\n");
                ticTacToeBoard.Append(" ");
                for (int k = 0; k < numberOfEqualSign; k++)
                {
                    ticTacToeBoard.Append("=");
                }
            }

            return ticTacToeBoard;
        }

        internal string CheckIfSequence()
        {
            string sequence = "false";
            if(CheckIfDiagonallSequence() == "X" || CheckIfVarticalSequence() == "X" || ChecKIfBalancedSequence() == "X")
            {
                sequence = "X";
            }
            else if(CheckIfDiagonallSequence() == "O" || CheckIfVarticalSequence() == "O" || ChecKIfBalancedSequence() == "O")
            {
                sequence = "O";
            }

            return sequence;
        }

        private string CheckIfDiagonallSequence()
        {
            string diagonalSequence = "false";
            if(CheckIfMainDiagonallSequence() == "X" || CheckIfSecondaryDiagonallSequence() == "X")
            {
                diagonalSequence = "X";
            }
            else if(CheckIfMainDiagonallSequence() == "O" || CheckIfSecondaryDiagonallSequence() == "O")
            {
                diagonalSequence = "O";
            }
        
            return diagonalSequence;
        }   

        private string CheckIfMainDiagonallSequence()
        {
            string mainDiagonalSequnece = "false";
            int matrixSquareSize = r_MatrixNumOfColumn;
            int countX = 0;
            int countO = 0;
            for(int i = 0; i < r_MatrixNumOfRow; i++)
            {
                for(int j = 0; j < r_MatrixNumOfColumn; j++)
                {
                    char symbolInCell = (char)this.m_TicTacToeMatrix.GetValue(i, j);
                    if(symbolInCell == 'X' && i == j)
                    {
                        countX++;
                    }
                    else if(symbolInCell == 'O' && i == j)
                    {
                        countO++;
                    }
                }
            }

            if(countX == matrixSquareSize)
            {
                mainDiagonalSequnece = "X";
            }
            else if(countO == matrixSquareSize)
            {
                mainDiagonalSequnece = "O";
            }

            return mainDiagonalSequnece;
        }

        private string CheckIfSecondaryDiagonallSequence()
        {
            string secondaryDiagonallSequence = "false";
            int matrixSquareSize = r_MatrixNumOfColumn;
            int countX = 0;
            int countO = 0;
            for(int i = 0; i < r_MatrixNumOfRow; i++)
            {
                for(int j = 0; j < r_MatrixNumOfColumn; j++)
                {
                    char symbolInCell = (char)this.m_TicTacToeMatrix.GetValue(i, j);
                    if(symbolInCell == 'X' && (i + j) == (matrixSquareSize - 1))
                    {
                        countX++;
                    }
                    else if(symbolInCell == 'O' && (i + j) == (matrixSquareSize - 1))
                    {
                        countO++;
                    }
                }
            }

            if(countX == matrixSquareSize)
            {
                secondaryDiagonallSequence = "X";
            }
            else if(countO == matrixSquareSize)
            {
                secondaryDiagonallSequence = "O";
            }

            return secondaryDiagonallSequence;
        }

         private string ChecKIfBalancedSequence()
         {
            string balancedSequence = "false";
            int matrixSquareSize = r_MatrixNumOfColumn;
            int countX = 0;
            int countO = 0;
            for(int i = 0; i < r_MatrixNumOfRow; i++)
            {
                countX = 0;
                countO = 0;
                for(int j = 0; j < r_MatrixNumOfColumn; j++)
                {
                    char symbolInCell = (char)this.m_TicTacToeMatrix.GetValue(i, j);
                    if (symbolInCell == 'X')
                    {
                        countX++;
                    }
                    else if(symbolInCell == 'O')
                    {
                        countO++;
                    }
                }

                if(countX == matrixSquareSize)
                {
                    balancedSequence = "X";
                    break;
                }
                else if(countO == matrixSquareSize)
                {
                    balancedSequence = "O";
                    break;
                }
            }

                return balancedSequence;
         }

        private string CheckIfVarticalSequence()
        {
            string varticalSequence = "false";
            int matrixSquareSize = r_MatrixNumOfColumn;
            int countX = 0;
            int countO = 0;
            for(int i = 0; i < r_MatrixNumOfRow; i++)
            {
                countX = 0;
                countO = 0;
                for(int j = 0; j < r_MatrixNumOfColumn; j++)
                {
                    char symbolInCell = (char)this.m_TicTacToeMatrix.GetValue(j, i);
                    if(symbolInCell == 'X')
                    {
                        countX++;
                    }
                    else if(symbolInCell == 'O')
                    {
                        countO++;
                    }
                }

                if(countX == matrixSquareSize)
                {
                    varticalSequence = "X";
                    break;
                }
                else if(countO == matrixSquareSize)
                {
                    varticalSequence = "O";
                    break;
                }
            }

            return varticalSequence;
        }

        internal void ClearTicTacToeBoard()
        {
            m_CountNumberOfOccupiedCells = 0;
            for(int i = 0; i < r_MatrixNumOfRow; i++)
            {
                for(int j = 0; j < r_MatrixNumOfColumn; j++)
                {
                    m_TicTacToeMatrix.SetValue(' ', i, j);
                }
            }
        }
    }
}