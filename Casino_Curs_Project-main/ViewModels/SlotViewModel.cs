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

namespace Casino_Schmirtz_Royale.ViewModels
{
    public class SlotViewModel : ViewModelBase
    {
        CasinoDbContext db = new CasinoDbContext();

        private bool respinBtnEnabled = true;
        public bool RespinBtnEnabled
        {
            get => respinBtnEnabled;
            set
            {
                respinBtnEnabled = value;
                OnPropertyChanged();
            }
        }

        public int CurrentBalance
        {
            get => db.Users.Where(a => a.Id == Settings.Default.Id).FirstOrDefault().Balance;
            set
            {

            }
        }

        public SlotViewModel()
        {

        }


        public Command spinCommand;
        public ICommand SpinCommand
        {
            get
            {
                return spinCommand ??
                  (spinCommand = new Command(async obj =>
                  {
                      if (db.Users.Where(a => a.Id == Settings.Default.Id).FirstOrDefault().Balance < 5)
                      {
                          MessageBox.Show("Недостаточно денег.");
                      }
                      else
                      {
                          RespinBtnEnabled = false;
                          await GameManager.DoSpin();
                          RespinBtnEnabled = true;
                      }
                  }));
            }
        }
    }
}
