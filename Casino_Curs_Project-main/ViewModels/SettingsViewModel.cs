using Casino_Schmirtz_Royale.Commands;
using Casino_Schmirtz_Royale.Database;
using Casino_Schmirtz_Royale.Models;
using Casino_Schmirtz_Royale.Properties;
using Casino_Schmirtz_Royale.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Casino_Schmirtz_Royale.ViewModels
{
    class SettingsViewModel : ViewModelBase
    {
        CasinoDbContext db = new CasinoDbContext();
        public string OldLogin { get; set; }
        public string NewLogin { get; set; }

        public string OldMail { get; set; }
        public string NewMail { get; set; }

        public string OldName { get; set; }
        public string NewName { get; set; }

        public string OldSurname { get; set; }
        public string NewSurname { get; set; }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public Command changeLogin;
        public ICommand ChangeLogin
        {
            get
            {
                return changeLogin ??
                 (changeLogin = new Command(obj =>
                 {
                     if (db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id).Login == OldLogin)
                     {
                         if (OldLogin == NewLogin)
                         {
                             MessageBox.Show($"Вы ввели одинаковые значения!");
                         }
                         else if (NewLogin == null || NewLogin == "" || NewLogin.StartsWith(" "))
                         {
                             MessageBox.Show("Данные не могут быть пустыми или начинаться с пробела!");
                         }
                         else if (!Regex.IsMatch(NewLogin, "^([A-Za-z0-9]){5,20}$"))
                         {
                             MessageBox.Show("Данные содержат недопустимые знаки!");
                         }
                         else
                         {
                             User user = db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id);
                             user.Login = NewLogin;

                             db.Entry(user).State = EntityState.Modified;

                             db.SaveChanges();

                             MessageBox.Show($"Вы успешно поменяли логин!");
                         }
                     }
                     else
                     {
                         MessageBox.Show($"Ошибка: Вы ввели неверный старый логин.");
                     }
                 }));
            }
        }

        public Command changeMail;
        public ICommand ChangeMail
        {
            get
            {
                return changeMail ??
                 (changeMail = new Command(obj =>
                 {
                     if (db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id).Email == OldMail)
                     {
                         if (OldMail == NewMail)
                         {
                             MessageBox.Show($"Вы ввели одинаковые значения!");
                         }
                         else if (NewMail == null || NewMail == "" || NewMail.StartsWith(" "))
                         {
                             MessageBox.Show("Данные не могут быть пустыми или начинаться с пробела!");
                         }
                         else if (!Regex.IsMatch(NewMail, "^[A-Za-z0-9]{5,15}@[a-z]{3,6}\\.[a-z]{3}$"))
                         {
                             MessageBox.Show("Данные содержат недопустимые знаки!");
                         }
                         else
                         {
                             User user = db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id);
                             user.Email = NewMail;

                             db.Entry(user).State = EntityState.Modified;

                             db.SaveChanges();

                             MessageBox.Show($"Вы успешно поменяли e-mail!");
                         }
                     }
                     else
                     {
                         MessageBox.Show($"Ошибка: Вы ввели неверный старый e-mail.");
                     }
                 }));
            }
        }

        public Command changeName;
        public ICommand ChangeName
        {
            get
            {
                return changeName ??
                 (changeName = new Command(obj =>
                 {
                     if (db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id).FirstName == OldName)
                     {
                         if (OldName == NewName)
                         {
                             MessageBox.Show($"Вы ввели одинаковые значения!");
                         }
                         else if (NewName == null || NewName == "" || NewName.StartsWith(" "))
                         {
                             MessageBox.Show("Данные не могут быть пустыми или начинаться с пробела!");
                         }
                         else if (!Regex.IsMatch(NewName, "^([A-Za-z0-9]){5,20}$"))
                         {
                             MessageBox.Show("Данные содержат недопустимые знаки!");
                         }
                         else
                         {
                             User user = db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id);
                             user.FirstName = NewName;

                             db.Entry(user).State = EntityState.Modified;

                             db.SaveChanges();

                             MessageBox.Show($"Вы успешно поменяли имя!");
                         }
                     }
                     else
                     {
                         MessageBox.Show($"Ошибка: Вы ввели неверное старое имя.");
                     }
                 }));
            }
        }

        public Command changeSurname;
        public ICommand ChangeSurname
        {
            get
            {
                return changeSurname ??
                 (changeSurname = new Command(obj =>
                 {
                     if (db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id).LastName == OldSurname)
                     {
                         if (OldSurname == NewSurname)
                         {
                             MessageBox.Show($"Вы ввели одинаковые значения!");
                         }
                         else if (NewSurname == null || NewSurname == "" || NewSurname.StartsWith(" "))
                         {
                             MessageBox.Show("Данные не могут быть пустыми или начинаться с пробела!");
                         }
                         else if (!Regex.IsMatch(NewSurname, "^([A-Za-z0-9]){5,20}$"))
                         {
                             MessageBox.Show("Данные содержат недопустимые знаки!");
                         }
                         else
                         {
                             User user = db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id);
                             user.LastName = NewSurname;

                             db.Entry(user).State = EntityState.Modified;

                             db.SaveChanges();

                             MessageBox.Show($"Вы успешно поменяли фамилию!");
                         }
                     }
                     else
                     {
                         MessageBox.Show($"Ошибка: Вы ввели неверну старую фамилию.");
                     }
                 }));
            }
        }

        public Command changePassword;
        public ICommand ChangePassword
        {
            get
            {
                return changePassword ??
                 (changePassword = new Command(obj =>
                 {
                     if(db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id).Password == SecurePassService.Hash(OldPassword))
                     {
                         if (OldPassword == NewPassword)
                         {
                             MessageBox.Show($"Вы ввели одинаковые значения!");
                         }
                         else if (NewPassword == null || NewPassword == "" || NewPassword.StartsWith(" "))
                         {
                             MessageBox.Show("Данные не могут быть пустыми или начинаться с пробела!");
                         }
                         else if (!Regex.IsMatch(NewPassword, "^([A-Za-z0-9]){5,20}$"))
                         {
                             MessageBox.Show("Данные содержат недопустимые знаки!");
                         }
                         else
                         {
                             User user = db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id);
                             user.Password = SecurePassService.Hash(NewPassword);

                             db.Entry(user).State = EntityState.Modified;

                             db.SaveChanges();

                             MessageBox.Show($"Вы успешно поменяли пароль!");
                         }
                     }
                     else
                     {
                         MessageBox.Show($"Ошибка: Вы ввели неверный старый пароль.");
                     }
                 }));
            }
        }


    }
}
