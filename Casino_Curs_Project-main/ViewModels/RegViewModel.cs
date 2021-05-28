using Casino_Schmirtz_Royale.Commands;
using Casino_Schmirtz_Royale.Database;
using Casino_Schmirtz_Royale.Models;
using Casino_Schmirtz_Royale.Services;
using Casino_Schmirtz_Royale.SingletonView;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Casino_Schmirtz_Royale.ViewModels
{
    public class RegViewModel : ViewModelBase
    {
        public string login { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        private string errorMes;
        public string ErrorMessage
        {
            get { return errorMes; }
            set
            {
                this.errorMes = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public Command backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ??
                 (backCommand = new Command(obj =>
                 {
                     SingletonAuth.getInstance(null).StartViewModel.CurrentViewModel = new LoginViewModel();
                 }));
            }
        }

        public Command regCommand;
        public ICommand RegCommand
        {
            get
            {
                return regCommand ??
                 (regCommand = new Command(obj =>
                 {
                     using (CasinoDbContext db = new CasinoDbContext())
                     {
                         if (login == null || login == "" || login.StartsWith(" ") ||
                             password == null || password == "" || password.StartsWith(" ") ||
                             firstname == null || firstname == "" || firstname.StartsWith(" ") ||
                             lastname == null || lastname == "" || lastname.StartsWith(" ") ||
                             mail == null || mail == "" || mail.StartsWith(" "))
                         {
                             MessageBox.Show("Данные не могут быть пустыми или начинаться с пробела!");
                         }
                         else if( !Regex.IsMatch(login, "^([A-Za-z0-9]){5,20}$") ||
                                  !Regex.IsMatch(password, "^([A-Za-z0-9]){8,20}$") ||
                                  !Regex.IsMatch(firstname, "^[A-Za-z0-9]){5,20}$") ||
                                  !Regex.IsMatch(lastname, "^[A-Za-z0-9]){5,20}$") ||
                                  !Regex.IsMatch(mail, "^[A-Za-z0-9]{5,15}@[a-z]{3,6}\\.[a-z]{3}$")
                                 )
                         {
                             MessageBox.Show("Данные содержат недопустимые знаки!");
                         }
                         else
                         {
                             User user = new User();
                             user.Login = login;
                             user.Password = SecurePassService.Hash(password);
                             user.FirstName = firstname;
                             user.LastName = lastname;
                             user.Is_admin = false;
                             user.Email = mail;
                             user.IsBlocked = false;



                             if (db.Users.Any(a => a.Login == login || a.Email == mail))
                             {
                                 MessageBox.Show("Пользователь с такими данными уже существует!");
                             }

                             else
                             {
                                 db.Users.Add(user);
                                 db.SaveChanges();

                                 SingletonAuth.getInstance(null).StartViewModel.CurrentViewModel = new LoginViewModel();
                             }
                         }
                     }
                 }));
            }
        }
    }
}
