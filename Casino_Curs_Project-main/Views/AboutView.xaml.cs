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
    /// Логика взаимодействия для AboutView.xaml
    /// </summary>
    public partial class AboutView : UserControl
    {
        AboutViewModel about = new AboutViewModel();
        public AboutView()
        {
            InitializeComponent();
            About.Text = "BATUREL CASINO is a Belarusian legal casino that boldly and confidently declares its intentions to become a leader in the online gambling industry. We strive to be not just successful, but thanks to the professionalism of our team, we want to achieve the cherished goal - TO BECOME THE BEST.";
            inst.Text = " INSTAGRAM \n marieverbitskaya";
            vk.Text = "VK \nmverb29";
            viber.Text = "  VIBER \n  +375299988880";
            DataContext = about;
        }
    }
}
