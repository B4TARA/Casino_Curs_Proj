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
using Casino_Schmirtz_Royale.Properties;

namespace Casino_Schmirtz_Royale.ViewModels
{
    class DepositViewModel : ViewModelBase
    {
        public string Deposit { get; set; }

        public string Number1 { get; set; }

        public string Number2 { get; set; }

        public string Number3 { get; set; }

        public string Number4 { get; set; }

        public string Date1 { get; set; }

        public string Date2 { get; set; }

        public string Cvv { get; set; }

        public string Holder { get; set; }

        public Command backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??
                 (backCommand = new Command(obj =>
                 {
                     Singleton.getInstance(null).MainViewModel.CurrentViewModel = new HomeViewModel();
                 }));
            }
        }

        public Command topUp;
        public ICommand TopUp
        {
            get
            {
                return topUp ??
                 (topUp = new Command(obj =>
                 {
                     try
                     {

                         if (Convert.ToInt32(Deposit) > 1000 || Convert.ToInt32(Deposit) < 0) throw new Exception("Депозит не входит в допустимый диапазон.");
                         if (Convert.ToInt32(Number1) > 9999 || Convert.ToInt32(Number1) < 1000) throw new Exception("Неверно введен номер карты (первая четверка).");
                         if (Convert.ToInt32(Number2) > 9999 || Convert.ToInt32(Number2) < 1000) throw new Exception("Неверно введен номер карты (вторая четверка).");
                         if (Convert.ToInt32(Number3) > 9999 || Convert.ToInt32(Number3) < 1000) throw new Exception("Неверно введен номер карты (третья четверка).");
                         if (Convert.ToInt32(Number4) > 9999 || Convert.ToInt32(Number4) < 1000) throw new Exception("Неверно введен номер карты (четвертая четверка).");
                         if (DateTime.Now.Date.Year > Convert.ToInt32("20" + Date2)) throw new Exception("Срок действия карты закончился.");
                         if (DateTime.Now.Date.Year == Convert.ToInt32("20" + Date2))
                         {
                             if(DateTime.Now.Date.Month >= Convert.ToInt32(Date1)) throw new Exception("Срок действия карты закончился.");
                         }
                         if (Convert.ToInt32(Date1) > 12 || Convert.ToInt32(Date1) <= 0) throw new Exception("Неверно введен срок действия карты (месяц).");
                         if (Convert.ToInt32(Date2) > 25 || Convert.ToInt32(Date2) < 21) throw new Exception("Неверно введен срок действия карты (год).");
                         if (Convert.ToInt32(Cvv) < 100 || Convert.ToInt32(Cvv) > 999) throw new Exception("Неверно введен CVV код.");
                         if (Holder.Length>20 || Holder.Length < 3 || Holder.Contains(" ")==false) throw new Exception("Неверно введено имя и фамилия");

                         CasinoDbContext db = new CasinoDbContext();

                         bool havecard = false;

                         User user = db.Users.Where(a => a.Id == Settings.Default.Id).FirstOrDefault();
                         user.Balance += Convert.ToInt32(Deposit);

                         db.Entry(user).State = EntityState.Modified;

                         TopUpHistory topup = new TopUpHistory();
                         topup.User = db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id);
                         topup.Date = DateTime.Now;
                         topup.Value = Convert.ToInt32(Deposit);

                         db.TopUp.Add(topup);

                         var users = db.Users.Include(c => c.Cards).ToList();
                         foreach (User userr in users)
                         {
                             if (userr.Id == Settings.Default.Id)
                             {
                                 foreach (Card cardd in userr.Cards)
                                 {
                                     if (cardd.Number == Number1 + " " + Number2 + " " + Number3 + " " + Number4)
                                     {
                                         havecard = true;
                                     }
                                 }
                             }
                         }
                         
                         if(!havecard)
                         {
                             Card card = new Card();
                             card.User = db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id);
                             card.Cvv = Convert.ToInt32(Cvv);
                             card.Number = Number1 + " " + Number2 + " " + Number3 + " " + Number4;
                             card.Owner = Holder.ToUpper();

                             db.Cards.Add(card);
                         }

                         db.SaveChanges();

                         Singleton.getInstance(null).MainViewModel.CurrentViewModel = new HomeViewModel();
                     }
                     catch (Exception e)
                     {
                         MessageBox.Show($"Ошибка: {e.Message}");
                     }
                 }));
            }
        }
    }
}
