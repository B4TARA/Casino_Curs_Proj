using Casino_Schmirtz_Royale.Commands;
using Casino_Schmirtz_Royale.Database;
using Casino_Schmirtz_Royale.Models;
using Casino_Schmirtz_Royale.Services;
using Casino_Schmirtz_Royale.SingletonView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Casino_Schmirtz_Royale.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
        ViewModelBase curViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return curViewModel; }
            set
            {
                curViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }
        public AuthViewModel()
        {
            SingletonAuth.getInstance(this);
            CurrentViewModel = new LoginViewModel();
        }
        public static void Close()
        {
            var window = System.Windows.Application.Current.Windows;
            window[0].Close();
        }
    }
}
