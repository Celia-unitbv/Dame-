using MVVMPairs.Commands;
using MVVMPairs.Models;
using MVVMPairs.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMPairs.Views
{
    /// <summary>
    /// Interaction logic for GameBoardView.xaml
    /// </summary>
    public partial class GameBoardView : UserControl
    {
        public GameBoardView()
        {
            InitializeComponent();
            DataContext = new GameBoardVM();
        }
        private void SelectPiece(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Cell cell && cell.Piece != null)
            {
                var gameVM = (GameBoardVM)DataContext;

                // Verificăm dacă este rândul culorii corespunzătoare pentru a selecta piesa
                if (gameVM.IsRedTurn == cell.Piece.Color || gameVM.IsRedTurn== gameVM.gameLogicService.verifyKing(cell.Piece))
                {
                    gameVM.SelectedPiece = cell.Piece;
                    (gameVM.ValidMoves, gameVM.capturedPieces) = gameVM.gameLogicService.CalculateValidMoves(cell, gameVM.GameBoard);
                    gameVM.gameLogicService.UpdateCellColors(gameVM.GameBoard);
                }
                
            }
        }

        private void ClickCell(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Cell cell)
            {
                var gameVM = (GameBoardVM)DataContext;
                gameVM.gameLogicService.ClickCell(cell, gameVM.GameBoard, gameVM.SelectedPiece,gameVM.ValidMoves, gameVM.capturedPieces);
                gameVM.IsRedTurn = gameVM.gameLogicService.UpdateRound();
                gameVM.RedPieces = gameVM.gameLogicService.UpdateNumberRed();
                gameVM.BluePieces = gameVM.gameLogicService.UpdateNumberBlue();
            }
        }




    }
}

