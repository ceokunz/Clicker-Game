using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Clicker
{
    public class CIconList
    {
        private List<CIcon> icons = new List<CIcon>();
        private int border = 10; //отступ между иконками 
        private int x = 0;
        private int y = 0;
        private int x_sh = 0; //смещение
        private int y_sh = 0;
        private int imageWidth;
        private int imageHeight;
        private int canvasW;
        private int canvasH;
        public CIconList(int icon_width, int icon_height, int canvas_width, int canvas_height)
        {
            imageWidth = icon_width;
            imageHeight = icon_height;
            canvasW = canvas_width;
            canvasH = canvas_height;
        }

        public void Load(string path)
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + path;
            string filter = "*.png";

            if (!Directory.Exists(folder))
                return;

            string[] files = Directory.GetFiles(folder, filter);

            icons.Clear();
            x = border;
            y = border;

            foreach (string file in files)
            {
                CIcon icon = new CIcon(imageWidth, imageHeight, file);
                icon.SetPosition(new Point(x, y));
                icons.Add(icon);

                x += imageWidth + border;
                if (x + imageWidth > canvasW - border) //перенос на новую строку при достижении края
                {
                    x = border;
                    y += imageHeight + border;
                }
            }
        }
        public int GetDeltaY() => imageHeight + border;

        public void Scroll(double delta) 
        {
            y_sh += (int)delta;
            foreach (var icon in icons)
            {
                Point newPos = new Point(icon.X(), icon.Y() + delta);
                icon.SetPosition(newPos);
            }
        }

        public List<CIcon> GetIcons() => icons;

        public CIcon FindByName(string name)
        {
            return icons.Find(icon => icon.Name().Equals(name));
        }

        public CIcon IsMouseOver(Point mousePosition)
        {
            foreach (var icon in icons)
            {
                if (icon.IsMouseOver(mousePosition))
                    return icon;
            }
            return null;

        }
    }    
}
