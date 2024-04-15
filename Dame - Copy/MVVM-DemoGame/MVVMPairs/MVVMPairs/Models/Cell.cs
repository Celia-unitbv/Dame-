using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.Models
{
    class Cell : BaseNotification
    {
        private string _cellColor;

        public int X { get; set; }
        public int Y { get; set; }

        public string CellColor
        {
            get { return _cellColor; }
            set
            {
                if (_cellColor != value)
                {
                    _cellColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Piece Piece { get; set; }
        public bool IsInValidMoves { get; set; }
        public bool CanCapture { get; set; }

        public Cell(int x, int y, string cellColor)
        {
            X = x;
            Y = y;
            CellColor = cellColor;
            Piece = null;
            IsInValidMoves = false;
            CanCapture = false;
        }
    }
}
