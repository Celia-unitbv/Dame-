using System.ComponentModel;

namespace MVVMPairs.Models
{
    class Piece : BaseNotification
    {
        private string _color;
        public string Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _isKing;
        public bool IsKing
        {
            get { return _isKing; }
            set
            {
                if (_isKing != value)
                {
                    _isKing = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _isInPlay;
        public bool IsInPlay
        {
            get { return _isInPlay; }
            set
            {
                if (_isInPlay != value)
                {
                    _isInPlay = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Piece(string color)
        {
            Color = color;
            IsKing = false;
            IsInPlay = true;
        }
    }
}
