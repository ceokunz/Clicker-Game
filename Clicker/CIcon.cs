using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Clicker
{
    public class CIcon
    {
        private string name; //поля класса, по полям по полям
        private int iconWidth;
        private int iconHeight;
        private Point position;
        private Rectangle icon;
        private string iconPath;

        public CIcon(int iconWidth, int iconHeight, string imagePath)
        {
            this.iconWidth = iconWidth;
            this.iconHeight = iconHeight;
            this.position = new Point(0, 0);
            this.name = System.IO.Path.GetFileNameWithoutExtension(imagePath);

        }
        
        public string Name() => name; //методы вроде можно свойством написать, но мяу мяу
        public double X() => position.X; //яяя ем котяяяят МУАХАХХАХАХАХХ (комм волеры)
        public double Y() => position.Y;
        public int IconWidth() => iconWidth;
        public int IconHeight() => iconHeight;
        public Rectangle GetIcon() => icon;
        public string IconPath() => iconPath;

        public void SetPosition(Point newPosition)
        {
            position = newPosition;
            icon.RenderTransform = new TranslateTransform(position.X, position.Y);
        }

        public bool IsMouseOver(Point mousePosition) //есть ли у нас мышь и попали ли мы
        {
            return mousePosition.X >= position.X && mousePosition.X <= position.X + iconWidth &&
                   mousePosition.Y >= position.Y && mousePosition.Y <= position.Y + iconHeight;
        }

        public Rectangle CloneIcon() //клонирование иконки (для повторного использования)
        {
            Rectangle clone = new Rectangle();
            clone.Width = icon.Width;
            clone.Height = icon.Height;
            clone.Fill = icon.Fill;
            clone.Stroke = icon.Stroke;
            clone.StrokeThickness = icon.StrokeThickness;
            return clone;

        }
    }
}