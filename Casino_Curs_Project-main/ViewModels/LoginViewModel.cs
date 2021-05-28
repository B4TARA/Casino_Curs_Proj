using Casino_Schmirtz_Royale.Commands;
using Casino_Schmirtz_Royale.Database;
using Casino_Schmirtz_Royale.Models;
using Casino_Schmirtz_Royale.Properties;
using Casino_Schmirtz_Royale.Services;
using Casino_Schmirtz_Royale.SingletonView;
//using Casino_Schmirtz_Royale.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Casino_Schmirtz_Royale.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string login { get; set; }
        public string password { get; set; }
        public Command authCommand;
        public ICommand AuthCommand
        {
            get
            {
                return authCommand ??
                 (authCommand = new Command(obj =>
                 {
                     try
                     {
                         if (string.IsNullOrEmpty(login) || login.StartsWith(" ")) throw new Exception("Логин не может быть пустым или начинаться с пробела.");
                         if (string.IsNullOrEmpty(password) || password.StartsWith(" ")) throw new Exception("Пароль не может быть пустым или начинаться с пробела.");
                         using (CasinoDbContext db = new CasinoDbContext())
                         {
                             User authUser = null;
                             password = SecurePassService.Hash(password);
                             authUser = db.Users.Where(a => a.Login == login && a.Password == password).FirstOrDefault();
                             if (authUser != null)
                             {
                                 Settings.Default.Id = authUser.Id;
                                 if (authUser.Is_admin == false)
                                 {
                                     if (authUser.IsBlocked == false)
                                     {
                                         MainWindow main = new MainWindow();
                                         main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                                         main.Show();
                                         AuthViewModel.Close();
                                     }
                                     else
                                     {
                                         MessageBox.Show("Вы были заблокированы.");
                                     }
                                 }
                                 else
                                 {
                                     //MainAdminView mainAdmin = new MainAdminView();
                                     // mainAdmin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                                     //mainAdmin.Show();
                                     //AuthViewModel.Close();
                                 }
                             }
                             else
                             {
                                 MessageBox.Show("Check your login or password.");
                             }
                         }
                     }
                     catch (Exception e)
                     {
                         MessageBox.Show($"Ошибка: {e.Message}");
                     }
                 }));
            }
        }
        public Command openRegCommand;
        public ICommand OpenRegCommand
        {
            get
            {
                return openRegCommand ??
                 (openRegCommand = new Command(obj =>
                 {
                     SingletonAuth.getInstance(null).StartViewModel.CurrentViewModel = new RegViewModel();
                 }));
            }
        }
        public void Close()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }
    }
}
