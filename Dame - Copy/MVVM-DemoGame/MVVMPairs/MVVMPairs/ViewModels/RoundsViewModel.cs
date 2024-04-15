using MVVMPairs.Models;
using MVVMPairs.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.ViewModels
{
    class RoundsViewModel : BaseNotification
    {
        private readonly GameLogic _gameLogic;

        public RoundsViewModel(GameLogic gameLogic)
        {
            _gameLogic = gameLogic;
            
        }
        
    }
}
