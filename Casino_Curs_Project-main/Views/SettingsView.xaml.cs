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
    /// Логика взаимодействия для SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        SettingsViewModel settings = new SettingsViewModel();
        public SettingsView()
        {
            InitializeComponent();
            DataContext = settings;
        }
        private void PasswordBox_OldPasswordChanged(object sender, RoutedEventArgs e)
        {
            settings.OldPassword = oldpassword.Password;
        }

        private void PasswordBox_NewPasswordChanged(object sender, RoutedEventArgs e)
        {
            settings.NewPassword = newpassword.Password;
        }
    }
}
