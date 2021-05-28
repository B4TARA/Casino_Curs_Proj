using Casino_Schmirtz_Royale.Database;
using Casino_Schmirtz_Royale.Models;
using Casino_Schmirtz_Royale.ViewModels;
using Casino_Schmirtz_Royale.Game;
using Casino_Schmirtz_Royale.CustomUIElements;
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

namespace Casino_Schmirtz_Royale.Views
{
    /// <summary>
    /// Логика взаимодействия для SlotView.xaml
    /// </summary>
    public partial class SlotView : UserControl
    {
        public SlotViewModel slotV = new SlotViewModel();
        public SlotView()
        {
            InitializeComponent();
            GameManager.Initialize(this);
            Handler.Initialize(this);
            DataContext = slotV;
        }
    }
}
