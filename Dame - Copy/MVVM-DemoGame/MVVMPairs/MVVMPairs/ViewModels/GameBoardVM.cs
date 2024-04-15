using MVVMPairs.Commands;
using MVVMPairs.Models;
using MVVMPairs.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVMPairs.ViewModels
{
    class GameBoardVM : BaseNotification
    {
        public ObservableCollection<ObservableCollection<Cell>> GameBoard { get; set; }
        public Piece SelectedPiece { get; set; }
        public List<Cell> ValidMoves { get; set; }
        public readonly GameLogic gameLogicService;
        public List<Piece> capturedPieces { get; set; }

        private string _isRedTurn;
        public string IsRedTurn
        {
            get { return _isRedTurn; }
            set
            {
                if (_isRedTurn != value)
                {
                    _isRedTurn = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _redPieces;
        public int RedPieces
        {
            get { return _redPieces; }
            set
            {
                if (_redPieces != value)
                {
                    _redPieces = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _bluePieces;
        public int BluePieces
        {
            get { return _bluePieces; }
            set
            {
                if (_bluePieces != value)
                {
                    _bluePieces = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public GameBoardVM()
        {
            GameBoard = Helper.InitGameBoard();
            GameBoard = Helper.InitializeCheckers(GameBoard);
            gameLogicService = new GameLogic();
            IsRedTurn = "Red";
            RedPieces = 12;
            BluePieces = 12;
        }


    }
}
