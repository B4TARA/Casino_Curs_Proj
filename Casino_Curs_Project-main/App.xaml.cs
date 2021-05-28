using Casino_Schmirtz_Royale.ViewModels;
using Casino_Schmirtz_Royale.Database;
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
using Casino_Schmirtz_Royale.Localization;
namespace Casino_Schmirtz_Royale
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CasinoDbContext db = new CasinoDbContext();
        private static Language language;
        public static Language Language
        {
            get => language ?? (language = new Language());
        }
        public App()
        {
            InitializeComponent();
            App.Language.Name = Casino_Schmirtz_Royale.Properties.Settings.Default.DefaultLanguage;
        }
    }
}
