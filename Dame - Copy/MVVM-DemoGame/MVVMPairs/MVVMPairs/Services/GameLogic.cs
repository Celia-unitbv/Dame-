using MVVMPairs.Models;
using MVVMPairs.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace MVVMPairs.Services
{
    internal class GameLogic:BaseNotification
    {

        public string IsRedTurn;
        public int RedPieces;
        public int BluePieces;
        public GameLogic()
        {
            IsRedTurn = "Red";
            RedPieces = 12;
            BluePieces = 12;
        }

        public int UpdateNumberRed()
        {
            return RedPieces;
        }

        public int UpdateNumberBlue()
        {
            return BluePieces;
        }

        public string UpdateRound()
        {
            return IsRedTurn;
        }
        
        public (List<Cell> validMoves, List<Piece> capturedPieces) CalculateValidMoves(Cell selectedCell, ObservableCollection<ObservableCollection<Cell>> GameBoard)
        {
                List<Cell> validMoves = new List<Cell>();
                List<Piece> capturedPieces = new List<Piece>();
                Piece capturedPiece=null;

                ResetPreviousValidMoves(GameBoard);

                int direction = selectedCell.Piece.Color == "Red" ? 1 : -1;
                int x = selectedCell.X;
                int y = selectedCell.Y;
                //cele verzi

                if (IsCellFree(GameBoard, x + direction, y + 1))
                {
                    GameBoard[x + direction][y + 1].IsInValidMoves = true;
                    validMoves.Add(GameBoard[x + direction][y + 1]);
                }
                if (IsCellFree(GameBoard, x + direction, y - 1))
                {
                    GameBoard[x + direction][y - 1].IsInValidMoves = true;
                    validMoves.Add(GameBoard[x + direction][y - 1]);
                }

                if (selectedCell.Piece.IsKing)
                {
                    int directionKing = direction * (-1);
                    if (IsCellFree(GameBoard, x + directionKing, y + 1))
                    {
                        GameBoard[x + directionKing][y + 1].IsInValidMoves = true;
                        validMoves.Add(GameBoard[x + directionKing][y + 1]);
                    }
                    if (IsCellFree(GameBoard, x + directionKing, y - 1))
                    {
                        GameBoard[x + directionKing][y - 1].IsInValidMoves = true;
                        validMoves.Add(GameBoard[x + directionKing][y - 1]);
                    }
                }
                //cele rosi
                if (IsCellOccupiedByOpponent(GameBoard, x + direction, y + 1, selectedCell.Piece) && IsCellFree(GameBoard, x + 2 * direction, y + 2))
                {
                    GameBoard[x + 2 * direction][y + 2].CanCapture = true;
                    validMoves.Add(GameBoard[x + 2 * direction][y + 2]);
                    capturedPiece=GameBoard[x + direction][y + 1].Piece;
                }
                if (IsCellOccupiedByOpponent(GameBoard, x + direction, y - 1, selectedCell.Piece) && IsCellFree(GameBoard, x + 2 * direction, y - 2))
                {
                    GameBoard[x + 2 * direction][y - 2].CanCapture = true;
                    validMoves.Add(GameBoard[x + 2 * direction][y - 2]);// Am modificat y + 2 în y - 2 pentru diagonala stângă
                    capturedPiece = GameBoard[x + direction][y - 1].Piece;
                }
                if (selectedCell.Piece.IsKing)
                {
                int directionKing = direction * (-1);
                //cele rosi
                if (IsCellOccupiedByOpponent(GameBoard, x + directionKing, y + 1, selectedCell.Piece) && IsCellFree(GameBoard, x + 2 * directionKing, y + 2))
                {
                    GameBoard[x + 2 * directionKing][y + 2].CanCapture = true;
                    validMoves.Add(GameBoard[x + 2 * directionKing][y + 2]);
                    capturedPiece = GameBoard[x + directionKing][y + 1].Piece;
                }
                if (IsCellOccupiedByOpponent(GameBoard, x + directionKing, y - 1, selectedCell.Piece) && IsCellFree(GameBoard, x + 2 * directionKing, y - 2))
                {
                    GameBoard[x + 2 * directionKing][y - 2].CanCapture = true;
                    validMoves.Add(GameBoard[x + 2 * directionKing][y - 2]);// Am modificat y + 2 în y - 2 pentru diagonala stângă
                    capturedPiece = GameBoard[x + directionKing][y - 1].Piece;
                }
            }
            capturedPieces.Add(capturedPiece);
                return (validMoves, capturedPieces);
            
        }

        public void UpdateCellColors(ObservableCollection<ObservableCollection<Cell>> GameBoard)
        {
            // Actualizează culorile celulelor pentru a reflecta schimbările din IsInValidMoves
            foreach (var row in GameBoard)
            {
                foreach (var cell in row)
                {
                    if (cell.IsInValidMoves)
                    { 
                        cell.CellColor = "Green";
                    }
                    else
                    if (cell.CanCapture)
                    {
                        cell.CellColor = "Red";
                    }
                    
                    else
                    {

                        string cellColor = ((cell.X + cell.Y) % 2 == 0) ? "White" : "Black";
                        cell.CellColor = cellColor;
                    }

                }
            }
        }

        public void UpdatePieceColors(ObservableCollection<ObservableCollection<Cell>> GameBoard)
        {
            foreach (var row in GameBoard)
            {
                foreach (var cell in row)
                {
                    if (cell.Piece != null)
                    {
                        if (cell.Piece.Color == "Red" && cell.Piece.IsKing)
                        {
                            // Schimbăm culoarea piesei la un ton de roșu închis pentru a indica că este un rege
                            cell.Piece.Color = "#FF00FF"; // DarkRed
                        }

                        if (cell.Piece.Color == "Blue" && cell.Piece.IsKing)
                        {
                            // Schimbăm culoarea piesei la un ton de roșu închis pentru a indica că este un rege
                            cell.Piece.Color = "#32CD32"; // DarkRed
                        }

                    }
                }
            }
        }

        public void ResetPreviousValidMoves(ObservableCollection<ObservableCollection<Cell>> GameBoard)
        {
            // Resetăm starea IsInValidMoves la false doar pentru celulele care au fost modificate anterior
            foreach (var row in GameBoard)
            {
                foreach (var cell in row)
                {
                    cell.IsInValidMoves = false;
                    cell.CanCapture = false;
                }
            }
        }

        private bool IsCellFree(ObservableCollection<ObservableCollection<Cell>> GameBoard, int x, int y)
        {
            // Verificăm dacă celula este în interiorul tablei
            if (x >= 0 && x < GameBoard.Count && y >= 0 && y < GameBoard[x].Count)
            {
                // Verificăm dacă celula nu conține deja o piesă
                return GameBoard[x][y].Piece == null;
            }
            return false; // Dacă celula nu este în interiorul tablei
        }

        public void ClickCell(Cell targetCell, ObservableCollection<ObservableCollection<Cell>> GameBoard, Piece SelectedPiece, List<Cell> ValidMoves, List<Piece> capturedPieces)
        {
            if (ValidMoves != null)
            {
                if (SelectedPiece != null && ValidMoves.Contains(targetCell))
                {
                    // Elimină piesa de pe poziția sa anterioară
                    foreach (var row in GameBoard)
                    {
                        foreach (var cell in row)
                        {
                            if (cell.Piece == SelectedPiece)
                            {
                                cell.Piece = null;
                                break;
                            }
                            if (cell == targetCell) cell.Piece = SelectedPiece;
                        }

                    }

                    if (targetCell.CanCapture)
                    {
                        // Faceți nulă piesa capturată
                        foreach (var row in GameBoard)
                        {
                            foreach (var cell in row)
                            {
                                if (capturedPieces.Contains(cell.Piece))
                                {
                                    cell.Piece = null;
                                }
                            }
                        }

                        // Goliți lista de piese capturate
                        capturedPieces.Clear();
                    }

                    if ((targetCell.Piece.Color == "Red" && targetCell.X == GameBoard.Count - 1) ||
                (targetCell.Piece.Color == "Blue" && targetCell.X == 0))
                    {
                        targetCell.Piece.IsKing = true; 
                    }
                    if (IsRedTurn == "Red" || isRedKing(SelectedPiece))
                    {
                        IsRedTurn = "Blue";
                    }

                    else IsRedTurn = "Red";

                    SelectedPiece = null;
                    ValidMoves.Clear();

                    ResetPreviousValidMoves(GameBoard);
                    UpdateCellColors(GameBoard);
                    UpdatePieceColors(GameBoard);

                    RedPieces = GameBoard.SelectMany(row => row).Count(cell => cell.Piece?.Color == "Red");
                    BluePieces = GameBoard.SelectMany(row => row).Count(cell => cell.Piece?.Color == "Blue");

                    ICollectionView view = CollectionViewSource.GetDefaultView(GameBoard);
                    view.Refresh();
                    if (IsGameOver())
                    {
                        string winner = RedPieces == 0 ? "Blue" : "Red";
                        MessageBox.Show($"Jocul s-a încheiat! Câștigătorul este jucătorul cu piese de culoare {winner}.");
                        // Aici puteți face alte acțiuni după încheierea jocului, dacă este necesar
                    }
                }
            }
        }






        private bool IsCellOccupiedByOpponent(ObservableCollection<ObservableCollection<Cell>> GameBoard, int x, int y, Piece selectedPiece)
        {
            if (IsCellWithinBounds(GameBoard, x, y) && GameBoard[x][y].Piece != null)
            {
                Piece piece = GameBoard[x][y].Piece;
                // Verificăm dacă piesa este a adversarului și nu este un rege
                if (selectedPiece.IsKing && piece.IsKing)
                    return verifyKing(piece)!=verifyKing(selectedPiece);
                if (selectedPiece.IsKing)
                    return verifyKing(selectedPiece) != piece.Color;
                else if (piece.IsKing)
                    return verifyKing(piece) != selectedPiece.Color;
                return piece.Color != selectedPiece.Color;
            }
            return false;
        }


        public bool isRedKing(Piece piece)
        {
            // Verificăm dacă poziția permite capturarea regeleui
            return piece.IsKing && piece.Color == "#FF00FF";
            
        }

        public bool isBlueKing(Piece piece)
        {
            return piece.IsKing && piece.Color == "#32CD32";

        }

        public string verifyKing(Piece piece)
        {
            if (isRedKing(piece)) return "Red";
            if(isBlueKing(piece)) return "Blue";
            return null;
        }

        private bool IsCellWithinBounds(ObservableCollection<ObservableCollection<Cell>> GameBoard, int x, int y)
        {
            return x >= 0 && x < GameBoard.Count && y >= 0 && y < GameBoard[x].Count;
        }

        public bool IsGameOver()
        {
            return RedPieces == 0 || BluePieces == 0;
        }



    }
}
