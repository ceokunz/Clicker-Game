using Clicker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Program1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFromFile = File.ReadAllText("enemies.json");
            List<CEnemyTemplate> enemies = new List<CEnemyTemplate>();

            // Парсинг JSON
            JsonDocument doc = JsonDocument.Parse(jsonFromFile);
            //Добавление новой записи в список класса из json
            foreach (JsonElement element in doc.RootElement.EnumerateArray())
            {
                string name = element.GetProperty("name").GetString();
                string iconName = element.GetProperty("iconName ").GetString();
                int baseLife = element.GetProperty("baseLife").GetInt32();
                double lifeModifier = element.GetProperty("lifeModifier").GetDouble();
                int baseGold = element.GetProperty("baseGold").GetInt32();
                double goldModifier = element.GetProperty("goldModifier").GetDouble();
                double spawnChance = element.GetProperty("spawnChance").GetDouble();

                // Создание нового экземпляра класса CEnemyTemplate с помощью конструктора
                CEnemyTemplate enemy = new CEnemyTemplate(name, iconName, baseLife, lifeModifier, baseGold, goldModifier, spawnChance);
                enemies.Add(enemy);
            }
            foreach (CEnemyTemplate enemy in enemies)
            {
                Console.WriteLine($"Name: {enemy.Name()} {enemy.IconName()}, Base: { enemy.BaseLife()} {enemy.BaseGold()}, Modifier: {enemy.LifeModifier()} {enemy.GoldModifier()}, SpawnChance: {enemy.SpawnChance()}");
            }
            Load("/Images");
        }

        public static void Load(string path)
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + path;
            string[] files = Directory.GetFiles(folder, "*.png");

            Console.WriteLine($"Найдено {files.Length} PNG файлов:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }

        }
    }
}

