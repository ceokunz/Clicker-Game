using Microsoft.Win32;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
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
        public List<IconItem> IconList { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            IconList = new List<IconItem>();

            string path = ConfigurationManager.AppSettings["pathToImages"];

            if (path != "")
            {
                if (Directory.Exists(path))
                {
                    Load(ConfigurationManager.AppSettings["pathToImages"]);

                }
            }
            else
            {
                OpenFolderDialog choofdlog = new OpenFolderDialog();

                if ((bool)choofdlog.ShowDialog())
                {
                    Load(choofdlog.FolderName);

                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    // Устанавливаем новое значение для ключа "pathToImages"
                    config.AppSettings.Settings["pathToImages"].Value = choofdlog.FolderName;

                    // Сохраняем изменения и обновляем конфигурацию приложения
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }

            IconListBox.ItemsSource = IconList;
        }

        

        public void Load(string path)
        {
            string filter = "*.png";
            string[] files = Directory.GetFiles(path, filter);
            foreach (string file in files)
            {
                IconList.Add(new IconItem(file));
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //получение координат мыши в координатах объекта Canvas с именем scene 
            Point mousePosition = Mouse.GetPosition(scene);
        }

        private void Dodep(object sender, RoutedEventArgs e)
        {
            dodepik newWindow = new dodepik();

            newWindow.Show();
        }
    }

}