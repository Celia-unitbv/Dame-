using MVVMPairs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPairs.ViewModels
{
    class GameSettingsVM
    {
        private bool _allowMultipleJump;

        public ICommand NewGameCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand StatisticsCommand { get; }

        public bool AllowMultipleJump
        {
            get => _allowMultipleJump;
            set
            {
                if (_allowMultipleJump != value)
                {
                    _allowMultipleJump = value;
                    // Aici poți face orice alte acțiuni legate de schimbarea stării ToggleButton-ului
                }
            }
        }

        public GameSettingsVM()
        {
            NewGameCommand = new RelayCommand<object>(param => NewGame());
            SaveCommand = new RelayCommand<object>(param => Save());
            OpenCommand = new RelayCommand<object>(param => Open());
            StatisticsCommand = new RelayCommand<object>(param => ShowStatistics());
        }

        private void NewGame()
        {
            // Implementarea logicii pentru un joc nou
        }

        private void Save()
        {
            // Implementarea logicii pentru salvarea configurației jocului
        }

        private void Open()
        {
            // Implementarea logicii pentru deschiderea unei configurații salvate anterior
        }

        private void ShowStatistics()
        {
            // Implementarea logicii pentru afișarea statisticilor
        }
    }
}
