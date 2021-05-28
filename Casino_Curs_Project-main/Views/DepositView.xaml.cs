using Casino_Schmirtz_Royale.Database;
using Casino_Schmirtz_Royale.Models;
using Casino_Schmirtz_Royale.ViewModels;
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
    /// Логика взаимодействия для DepositView.xaml
    /// </summary>
    public partial class DepositView : UserControl
    {
        DepositViewModel deposit = new DepositViewModel();
        public DepositView()
        {
            InitializeComponent();
            DataContext = deposit;

        }
    }
}
