using MVVMPairs.Services;
using MVVMPairs.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Rounds.xaml
    /// </summary>
    public partial class Rounds : UserControl
    {
        public Rounds()
        {
            InitializeComponent();
            DataContext = new RoundsViewModel(new GameLogic());
        }
    }
}
