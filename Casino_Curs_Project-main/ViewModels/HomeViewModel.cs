using Casino_Schmirtz_Royale.Commands;
using Casino_Schmirtz_Royale.Database;
using Casino_Schmirtz_Royale.Models;
using Casino_Schmirtz_Royale.Properties;
using Casino_Schmirtz_Royale.Services;
using Casino_Schmirtz_Royale.SingletonView;
using Casino_Schmirtz_Royale.Game;
using Casino_Schmirtz_Royale.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity;

namespace Casino_Schmirtz_Royale.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        CasinoDbContext db = new CasinoDbContext();
        public string Welcome
        {
            get => "Welcome back, " + db.Users.Where(a => a.Id == Settings.Default.Id).FirstOrDefault().Login + "!";
            set
            {

            }
        }

        public string Login
        {
            get => "Login: " + db.Users.Where(a => a.Id == Settings.Default.Id).FirstOrDefault().Login;
            set
            {

            }
        }

        public string Mail
        {
            get => "E-mail: " + db.Users.Where(a => a.Id == Settings.Default.Id).FirstOrDefault().Email;
            set
            {

            }
        }

        public string First
        {
            get => "First name: " + db.Users.Where(a => a.Id == Settings.Default.Id).FirstOrDefault().FirstName;
            set
            {

            }
        }

        public string Second
        {
            get => "Second name: " + db.Users.Where(a => a.Id == Settings.Default.Id).FirstOrDefault().LastName;
            set
            {

            }
        }

        public string Balance
        {
            get => "Your balance: " + db.Users.Where(a => a.Id == Settings.Default.Id).FirstOrDefault().Balance;
            set
            {

            }
        }

        public Command deposit;
        public ICommand Deposit
        {
            get
            {
                return deposit ??
                 (deposit = new Command(obj =>
                 {
                     Singleton.getInstance(null).MainViewModel.CurrentViewModel = new DepositViewModel();
                 }));
            }
        }

        public ObservableCollection<SpinHistory> spinHistory;
        public ObservableCollection<TopUpHistory> topupHistory;

        public HomeViewModel()
        {
            int SpinCounter = 1;
            int TopUpCounter = 1;
            var users = db.Users.Include(c => c.Spins).Include(c => c.TopUps).ToList();
            foreach (User user in users)
            {
                foreach(SpinHistory spin in user.Spins)
                {
                    spin.Id = SpinCounter;
                    SpinCounter++;
                }

                foreach(TopUpHistory topup in user.TopUps)
                {
                    topup.Id = TopUpCounter;
                    TopUpCounter++;
                }
            }

            spinHistory = new ObservableCollection<SpinHistory>(users[Settings.Default.Id-1].Spins);
            topupHistory = new ObservableCollection<TopUpHistory>(users[Settings.Default.Id - 1].TopUps); 
        }
   

    }
}
