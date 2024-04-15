using MVVMPairs.Models;
using MVVMPairs.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.Services
{
    class Helper
    {
        public static ObservableCollection<ObservableCollection<Cell>> InitGameBoard()
        {
            ObservableCollection<ObservableCollection<Cell>> gameBoard = new ObservableCollection<ObservableCollection<Cell>>();

            for (int row = 0; row < 8; row++)
            {
                ObservableCollection<Cell> rowCells = new ObservableCollection<Cell>();
                for (int col = 0; col < 8; col++)
                {
                    string cellColor = ((row + col) % 2 == 0) ? "White" : "Black"; 
                    rowCells.Add(new Cell(row, col, cellColor));
                }
                gameBoard.Add(rowCells);
            }

            return gameBoard;
        }
        public static ObservableCollection<ObservableCollection<Cell>> InitializeCheckers(ObservableCollection<ObservableCollection<Cell>> gameBoard)
        {
            
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if ((row + col) % 2 != 0)
                    {
                        gameBoard[row][col].Piece = new Piece("Red");
                    }
                }
            }

            for (int row = 5; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if ((row + col) % 2 != 0)
                    {
                        gameBoard[row][col].Piece = new Piece("Blue");
                    }
                }
            }
            return gameBoard;
        }
    }
}
