using Microsoft.Win32;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using IOPath = System.IO.Path;
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
    public partial class MainWindow : Window
    {
        public List<IconItem> IconList { get; set; }

        public CEnemyTemplateList EnemyList { get; set; } = new();

        private string selectedIconPath = null;
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            IconList = new List<IconItem>();
            EnemyList = new CEnemyTemplateList();

            try
            {
                string path = ConfigurationManager.AppSettings["pathToImages"];

                if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    Load(path);
                }
                else
                {
                    var choofdlog = new OpenFolderDialog();
                    if (choofdlog.ShowDialog() == true)
                    {
                        Load(choofdlog.FolderName);

                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["pathToImages"].Value = choofdlog.FolderName;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                }

                IconListBox.ItemsSource = IconList;
                EnemyListBox.ItemsSource = EnemyList.GetEnemies();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске: {ex.Message}\n\n{ex.StackTrace}", "это полный какиш бро");

            }

            IconListBox.ItemsSource = IconList;
            EnemyListBox.ItemsSource = EnemyList.Enemies;
        }

        private void UpdateEnemiesList()
        {
            EnemyListBox.ItemsSource = null;
            EnemyListBox.ItemsSource = EnemyList.Enemies;
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

        private void Dodep(object sender, RoutedEventArgs e)
        {
            dodepik newWindow = new dodepik();

            newWindow.Show();
        }

        private void Button_SaveToJson(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "enemies";
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON files (*.json)|*.json";

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    //CEnemyTemplateList enemyList = new CEnemyTemplateList();
                    EnemyList.saveToJson(dlg.FileName);
                    MessageBox.Show("Список успешно сохранен", "Хлопаем стоя");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Кринжанул");
                }
            }
        }

        private void Button_LoadFromJson(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON files (*.json)|*.json";

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    EnemyList = new CEnemyTemplateList();
                    EnemyList.loadFromJson(dlg.FileName);
                    UpdateEnemiesList();
                    ClearForm();
                    MessageBox.Show("Список успешно загружен", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка");
                }
            }
        }

        private void ClearForm()
        {
            EnemyNameBox.Clear();
            IconNameBox.Clear();
            BaseLifeBox.Text = " ";
            LifeModBox.Text = " ";
            BaseGoldBox.Text = " ";
            GoldModBox.Text = " ";
            SpawnChanceBox.Text = " ";
            scene.Source = null;

            selectedIconPath = null;
        }

        private void Button_AddEnemy(object sender, RoutedEventArgs e)
        {
            AddEnemy();

        }

        private void AddEnemy()
        {
           
            if (string.IsNullOrWhiteSpace(EnemyNameBox.Text))
            {
                MessageBox.Show("Введите имя врага", "Ошибка");
                return;
            }

            try
            {
                string iconName = System.IO.Path.GetFileName(selectedIconPath);

                if (!int.TryParse(BaseLifeBox.Text, out int baseLife) || baseLife < 0)
                {
                    MessageBox.Show("Введите верное значение здоровья (целое число >= 0)", "Ошибка");
                    return;
                }

                if (!double.TryParse(LifeModBox.Text, out double lifeModifier) || lifeModifier < 0)
                {
                    MessageBox.Show("Введите верный модификатор здоровья (число >= 0)", "Ошибка");
                    return;
                }

                if (!int.TryParse(BaseGoldBox.Text, out int baseGold) || baseGold < 0)
                {
                    MessageBox.Show("Введите верное значение золота (целое число >= 0)", "Ошибка");
                    return;
                }

                if (!double.TryParse(GoldModBox.Text, out double goldModifier) || goldModifier < 0)
                {
                    MessageBox.Show("Введите верный модификатор золота (число >= 0)", "Ошибка");
                    return;
                }

                if (!double.TryParse(SpawnChanceBox.Text, out double spawnChance) || spawnChance < 0 || spawnChance > 1)
                {
                    MessageBox.Show("Введите верный шанс появления (от 0 до 1)", "Ошибка");
                    return;
                }


                CEnemyTemplate enemy = new CEnemyTemplate(EnemyNameBox.Text.Trim(),
                    iconName,
                    baseLife,
                    lifeModifier,
                    baseGold,
                    goldModifier,
                    spawnChance);

                EnemyList.addEnemy(enemy);
                UpdateEnemiesList();
                ClearForm();

                MessageBox.Show("Враг успешно добавлен", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void Button_RemoveEnemy(object sender, RoutedEventArgs e)
        {
            if (EnemyListBox.SelectedIndex >= 0 && EnemyListBox.SelectedIndex < EnemyList.GetEnemies().Count)
            {
                EnemyList.deleteEnemyByIndex(EnemyListBox.SelectedIndex);
                UpdateEnemiesList();
                ClearForm();
                MessageBox.Show("Враг дезинтегрирован", "Информация");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите врага для удаления", "Предупреждение");
            }
        }

        private void IconListBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            (EnemyListBox.SelectedItem as CEnemyTemplate)!.IconName = (IconListBox.Items.CurrentItem as IconItem)!.IconPath;
        }

        private void IconListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (IconListBox.SelectedItem != null)
                    if (EnemyListBox.SelectedItem != null)
                    (EnemyListBox.SelectedItem as CEnemyTemplate)!.IconName = (IconListBox.SelectedItem as IconItem)!.IconPath;
                //scene.Source = ()(IconListBox.SelectedItem as IconItem)!.IconPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Я ЩАС УБЬЮ СЕБЯ");
            }
        }

        private void EnemyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //IconListBox.SelectedItem = null;
        }
    }

}