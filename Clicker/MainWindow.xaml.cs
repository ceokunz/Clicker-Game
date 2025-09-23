using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Clicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Load(string path)
        {

            string folder =
            System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + path;
            //фильтр расширения изображения 
            string filter = "*.png";
            //получение массива строк содержащих пути до изображений 
            string[] files = Directory.GetFiles(folder, filter);
            foreach (string file in files)
            {
                //в file содержится путь до изображения с расширением .png 
            }
        }

        //public void CreateIcon(int iconWidth, int iconHeight, string imagePath)
        //{
        //    position = new Point(0, 0);

        //    name = System.IO.Path.GetFileNameWithoutExtension(imagePath);

        //    icon = new Rectangle();
        //    //установка цвета линии обводки и цвета заливки при помощи коллекции кистей 
        //    icon.Stroke = Brushes.Black;
        //    ImageBrush ib = new ImageBrush();
        //    //позиция изображения будет указана как координаты левого верхнего угла 
        //    //изображение будет растянуто по размерам прямоугольника, описанного вокруг фигуры 
        //    ib.AlignmentX = AlignmentX.Left;
        //    ib.AlignmentY = AlignmentY.Top;

        //    //загрузка изображения и назначение кисти 
        //    ib.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Absolute));

        //    icon.RenderTransform = new TranslateTransform(position.X, position.Y);

        //    icon.Fill = ib;
        //    //параметры выравнивания 
        //    icon.HorizontalAlignment = HorizontalAlignment.Left;
        //    icon.VerticalAlignment = VerticalAlignment.Center;
        //    //размеры прямоугольника 
        //    icon.Height = iconHeight;
        //    icon.Width = iconWidth;
        //}

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //получение координат мыши в координатах объекта Canvas с именем scene 
            Point mousePosition = Mouse.GetPosition(scene);
        }

    }

}