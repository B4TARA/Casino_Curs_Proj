using Casino_Schmirtz_Royale.Commands;
using Casino_Schmirtz_Royale.Database;
using Casino_Schmirtz_Royale.Properties;
using Casino_Schmirtz_Royale.SingletonView;
using Casino_Schmirtz_Royale.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Casino_Schmirtz_Royale.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public List<CultureInfo> Langs { get; set; }
        private CultureInfo selectedLanguage;
        private CultureInfo currentLang { get; set; }
        public CultureInfo SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                selectedLanguage = value;
                OnPropertyChanged("SelectedLanguage");
            }
        }

        private Command languageChanged;
        public ICommand LanguageChanged
        {
            get
            {
                return languageChanged ??
                  (languageChanged = new Command(obj =>
                  {
                      if (selectedLanguage == null)
                      {
                          selectedLanguage = App.Language.Name;
                      }
                      else
                      {
                          App.Language.Name = selectedLanguage;
                          currentLang = selectedLanguage;
                          Casino_Schmirtz_Royale.Properties.Settings.Default.DefaultLanguage = currentLang;
                          Casino_Schmirtz_Royale.Properties.Settings.Default.Save();
                      }
                  }));
            }
        }
        private Command confirmChange;
        public ICommand ConfirmChange
        {
            get
            {
                return confirmChange ??
                  (confirmChange = new Command(obj =>
                  {
                      try
                      {
                          if (selectedLanguage == null)
                          {
                              selectedLanguage = App.Language.Name;
                          }
                          else
                          {
                              App.Language.Name = selectedLanguage;
                              currentLang = selectedLanguage;
                              Casino_Schmirtz_Royale.Properties.Settings.Default.DefaultLanguage = currentLang;
                              Casino_Schmirtz_Royale.Properties.Settings.Default.Save();
                          }
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }

        public string index { get; set; }
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }
        public MainViewModel()
        {
            Langs = new List<CultureInfo>();
            foreach (var i in App.Language.Languages)
            {
                if (i != null)
                {
                    Langs.Add(i);
                }
            }
            if (selectedLanguage != null)
            {
                App.Language.Name = selectedLanguage;

            }
            else
            {
                selectedLanguage = Properties.Settings.Default.DefaultLanguage;
            }
            Singleton.getInstance(this);
            CurrentViewModel = new HomeViewModel();
        }

        public Command outCommand;
        public ICommand OutCommand
        {
            get
            {
                return outCommand ??
                 (outCommand = new Command(obj =>
                 {
                     Application.Current.Shutdown();
                     System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0]);

                 }));
            }
        }

        public Command changeCommand;
        public ICommand ChangeCommand
        {
            get
            {
                return changeCommand ??
                 (changeCommand = new Command(obj =>
                 {
                     switch (index)
                     {
                         case "Slot machine":
                             Singleton.getInstance(null).MainViewModel.CurrentViewModel = new SlotViewModel();
                             break;
                         case "Home":
                             Singleton.getInstance(null).MainViewModel.CurrentViewModel = new HomeViewModel();
                             break;
                         case "Settings":
                             Singleton.getInstance(null).MainViewModel.CurrentViewModel = new SettingsViewModel();
                             break;
                         case "About":
                             Singleton.getInstance(null).MainViewModel.CurrentViewModel = new AboutViewModel();
                             break;
                     }
                 }));
            }
        }

        public static void Close()
        {
            var window = System.Windows.Application.Current.Windows;
            window[0].Close();
        }
    }
}
