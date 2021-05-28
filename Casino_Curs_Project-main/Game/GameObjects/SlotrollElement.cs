using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Casino_Schmirtz_Royale.Game.GameObjects
{
    public class SlotrollElement
    {
        public Rectangle element;
        public SlotSymbol symbol;

        private int pos;

        public SlotrollElement(SlotSymbol slotSymbol, int position) //рандомный символ и позиция относительно верхней границы
        {
            element = new Rectangle();
            element.Height = 120;      // РАЗМЕРЫ ИКОНОК
            element.Width = 120;
            string imgName;
            Uri imgUri;
            switch (slotSymbol)
            {
                case SlotSymbol.Ace:
                    imgName = "ace.png";
                    break;
                case SlotSymbol.Cherry:
                    imgName = "cherry.png";
                    break;
                case SlotSymbol.Chip:
                    imgName = "chip.png";
                    break;
                case SlotSymbol.Heart:
                    imgName = "heart.png";
                    break;
                case SlotSymbol.Money:
                    imgName = "money.png";
                    break;
                default:
                    throw new Exception("file not found or something like that");
            }
            imgUri = new Uri(@"pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name + ";component/"+ "Assets/RollImages/"+imgName, UriKind.Absolute);

            element.Fill = new ImageBrush(new BitmapImage(imgUri)); //вставка
            Canvas.SetLeft(element, 80);
            Canvas.SetTop(element, position);

            this.symbol = slotSymbol;
            this.pos = position;
        }

        public async Task MoveTo(int position) //перемещение ленты 
        {
            while(pos != position) 
            {
                if(position -pos < 20) // если не в нужной позиции 
                {
                    Canvas.SetTop(element, position); //если в нужной позиции то устанавливаем сюда элемент
                    pos = position;
                    return;
                }
                Canvas.SetTop(element, pos + 20);  //перемещаем
                pos+=20;
                await Task.Delay(5);
            }
        }
    }
}
