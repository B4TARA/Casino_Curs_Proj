using Casino_Schmirtz_Royale.Game.GameObjects;
using Casino_Schmirtz_Royale.Views;
using Casino_Schmirtz_Royale.Commands;
using Casino_Schmirtz_Royale.Database;
using Casino_Schmirtz_Royale.Models;
using Casino_Schmirtz_Royale.Services;
using Casino_Schmirtz_Royale.SingletonView;
using Casino_Schmirtz_Royale.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.Entity;

namespace Casino_Schmirtz_Royale.Game
{
    

    public static class GameManager
    {
        private static SlotView w;

        private static Canvas leftCanv;
        private static Canvas middleCanv;
        private static Canvas rightCanv;

        private static Slotroll leftRoll;
        private static Slotroll middleRoll;
        private static Slotroll rightRoll;

        private static int Balance = 1000;

        public static Random rnd = new Random();

        public static void Initialize(SlotView w)
        {
            GameManager.w = w;
            leftCanv = w.lCanv;
            middleCanv = w.mCanv;
            rightCanv = w.rCanv;

            
            leftRoll = new Slotroll(leftCanv);
            middleRoll = new Slotroll(middleCanv);
            rightRoll = new Slotroll(rightCanv);

            leftRoll.Initialize();
            middleRoll.Initialize();
            rightRoll.Initialize();
        }
        
        // совершение спина // 
        public static async Task DoSpin()
        {
            w.winDisplayLbl.Content = "";
            ChangeBalance(-5);   
            Random rnd = new Random();
            middleRoll.StartSpin();
            rightRoll.StartSpin();
            SlotSymbol leftSymbol = await leftRoll.Spin(rnd.Next(1, 8));
            await middleRoll.StopSpin();
            SlotSymbol middleSymbol = await middleRoll.Spin(rnd.Next(1, 5));
            await rightRoll.StopSpin();
            SlotSymbol rightSymbol = await rightRoll.Spin(rnd.Next(1, 4));

           // Console.WriteLine($"{leftSymbol.ToString()} {middleSymbol.ToString()} {rightSymbol.ToString()}");

            int win = GetWin(leftSymbol, middleSymbol, rightSymbol);
            ChangeBalance(win);

            //Добавляем нову запись "Спин"
            CasinoDbContext db = new CasinoDbContext();

            SpinHistory spin = new SpinHistory();

            spin.User = db.Users.FirstOrDefault(a => a.Id == Settings.Default.Id);
            spin.Date = DateTime.Now;
            spin.Result = win-5;

            db.Spin.Add(spin);

            db.SaveChanges();
            /////////////////////////////
            
            if (win != 0)
            DisplayWin(win);

            if(win == 10)
            {

            }
        }

        public static void ChangeBalance(int change)
        {
            CasinoDbContext db = new CasinoDbContext();
            User user = db.Users.Where(a => a.Id == Settings.Default.Id).FirstOrDefault();
            user.Balance += change;
            
            db.Entry(user).State = EntityState.Modified;

            db.SaveChanges();

            w.balanceLbl.Content = user.Balance;
        }

        public static int GetWin(SlotSymbol symbol1, SlotSymbol symbol2, SlotSymbol symbol3)
        {
            //Check for jackpot
            if(symbol1 == symbol2 && symbol1 == symbol3 && symbol1 == SlotSymbol.Money)
                return 100;

            if(symbol1 == symbol2 && symbol1 == symbol3)
                return 10;
            else if(symbol1 == symbol2 || symbol2 == symbol3 || symbol1 == symbol3)
                return 2;
            else
                return 0;
        }

        public static void DisplayWin(int win)
        {
            w.winDisplayLbl.Content = "Win: " + win;
        }
    }
}
