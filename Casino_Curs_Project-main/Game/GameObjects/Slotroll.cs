using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Casino_Schmirtz_Royale.Game.GameObjects
{
    public class Slotroll
    {
        private const int topHidden = -140; // следующий элемент(который сверху и спрятан)
        private const int firstPosition = 5; //первая строка элементов
        private const int secondPosition = 150; 
        private const int thirdPosition = 295;  
        private const int bottomHidden = 440; // элемент который прошел(снизу и спрятан)

        private Canvas rollCanvas;

        private SlotrollElement newRoll; //следующий элемент
        private SlotrollElement topRoll;
        private SlotrollElement middleRoll;
        private SlotrollElement bottomRoll;

        public Slotroll(Canvas canv)
        {
            rollCanvas = canv;
        }

        public void Initialize()
        {
            newRoll = new SlotrollElement(RandomSymbol(), topHidden); //инициализация элементов 
            topRoll = new SlotrollElement(RandomSymbol(), firstPosition);
            middleRoll = new SlotrollElement(RandomSymbol(), secondPosition);
            bottomRoll = new SlotrollElement(RandomSymbol(), thirdPosition);

            rollCanvas.Children.Add(newRoll.element);
            rollCanvas.Children.Add(topRoll.element);
            rollCanvas.Children.Add(middleRoll.element);
            rollCanvas.Children.Add(bottomRoll.element);
            
            
        }

        private SlotSymbol RandomSymbol()
        {
            int jackpot = GameManager.rnd.Next(0, 10);
            if(jackpot == 4)
            {
                return SlotSymbol.Money;
            }

            int num = GameManager.rnd.Next(0, 4);
            return (SlotSymbol)num;
        }

        public async Task<SlotSymbol> Spin(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _ = newRoll.MoveTo(firstPosition); // _ - используется, когда функция возвращает значение, но вы не будете его использовать
                _ = topRoll.MoveTo(secondPosition);
                _ = middleRoll.MoveTo(thirdPosition);
                await bottomRoll.MoveTo(bottomHidden);
                var toDelete = bottomRoll;
                bottomRoll = middleRoll;
                middleRoll = topRoll;
                topRoll = newRoll;

                rollCanvas.Children.Remove(toDelete.element);

                newRoll = new SlotrollElement(RandomSymbol(), topHidden);
                rollCanvas.Children.Add(newRoll.element);

               
            }
            return middleRoll.symbol;
        }

        bool spinning = false;
        Task spinTask;

        public void StartSpin()
        {
            spinning = true;
            spinTask = SpinContiniously();
        }

        private async Task SpinContiniously() 
        {
            while (spinning)
            {
                await Spin(1);
            }
        }

        public async Task StopSpin() 
        {
            spinning = false;
            await spinTask;
        }

    }

    public enum SlotSymbol //символы 
    {
        Ace,
        Cherry,
        Chip,
        Heart,
        Money
    }
}
