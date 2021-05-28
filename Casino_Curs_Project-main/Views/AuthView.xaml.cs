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
using System.Windows.Shapes;

namespace Casino_Schmirtz_Royale.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthView.xaml
    /// </summary>
    public partial class AuthView : Window
    {
        AuthViewModel a = new AuthViewModel();
        public AuthView()
        {
            InitializeComponent();
            DataContext = a;
        }
    }
}
