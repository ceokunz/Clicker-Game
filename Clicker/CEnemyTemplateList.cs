using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Clicker
{
    public class CEnemyTemplateList
    {

        public List<CEnemyTemplate> enemies
        { get; private set; } = new();
        public CEnemyTemplateList()
        {
            enemies = new List<CEnemyTemplate>();
        }

        public void addEnemy(CEnemyTemplate enemy)
        {
            enemies.Add(enemy);
        }
        public CEnemyTemplate getEnemyByName(string Name)
        {
            foreach (CEnemyTemplate enemy in enemies)
            {
                if (enemy.Name == Name)
                {
                    return enemy;
                }
            }
            return null;
        }
        public CEnemyTemplate getEnemyByIndex(int Id)
        {
            if (Id >= 0 && Id < enemies.Count)
            {
                return enemies[Id];
            }
            return null;
        }
        public void deleteEnemyByName(string Name)
        {
            enemies.RemoveAll(enemy => enemy.Name == Name);
        }
        public void deleteEnemyByIndex(int Id)
        {
            if (Id >= 0 && Id < enemies.Count)
            {
                enemies.RemoveAt(Id);
            }
        }

        public List<string> getListOfEnemyNames()
        {
            List<string> names = new List<string>();

            foreach (CEnemyTemplate enemy in enemies)
            {
                names.Add(enemy.Name);
            }
            return names;
        }

        public List<CEnemyTemplate> GetEnemies() { return enemies; }

        public void saveToJson(string path)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true // Важно: включаем сериализацию полей
                };
                string json = JsonSerializer.Serialize(enemies, options);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении в JSON: {ex.Message}");
            }
        }

        public void loadFromJson(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    var options = new JsonSerializerOptions
                    {
                        IncludeFields = true // Важно: включаем десериализацию полей
                    };
                    enemies = JsonSerializer.Deserialize<List<CEnemyTemplate>>(json, options) ?? new List<CEnemyTemplate>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке из JSON: {ex.Message}");
                enemies = new List<CEnemyTemplate>();
            }
        }

    }
}
