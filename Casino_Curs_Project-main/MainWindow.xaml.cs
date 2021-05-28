using Casino_Schmirtz_Royale.Database;
using Casino_Schmirtz_Royale.Models;
using Casino_Schmirtz_Royale.Properties;
using Casino_Schmirtz_Royale.Services;
using Casino_Schmirtz_Royale.ViewModels;
using Casino_Schmirtz_Royale.Views;
using Casino_Schmirtz_Royale.CustomUIElements;
using Casino_Schmirtz_Royale.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

namespace Casino_Schmirtz_Royale
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel a = new MainViewModel();
        public static int Code { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = a;
        }

        private void searchRadio_Checked(object sender, RoutedEventArgs e)
        {
            a.index = ((RadioButton)sender).Content.ToString();
        }

    }
}