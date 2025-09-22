using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace Clicker
{
    public class CEnemyTemplate
    {
        [JsonInclude]
        string name;
        [JsonInclude]
        string iconName;

        //Атрибуты здоровья
        [JsonInclude]
        int baseLife;
        [JsonInclude]
        double lifeModifier;

        //Атрибуты золота за победу над противником
        [JsonInclude]
        int baseGold;
        [JsonInclude]
        double goldModifier;

        [JsonInclude]
        double spawnChance; //Шанс на появление

        public CEnemyTemplate(string Name, string IconName, int BaseLife, double LifeModifier, int BaseGold, double GoldModifier, double SpawnChance)
        {
            name = Name;
            iconName = IconName;
            baseLife = BaseLife;
            lifeModifier = LifeModifier;
            baseGold = BaseGold;
            goldModifier = GoldModifier;
            spawnChance = SpawnChance;
        }
        public string Name() { return name; }
        public string IconName() { return iconName; }
        public int BaseLife() { return baseLife; }
        public double LifeModifier() { return lifeModifier; }
        public int BaseGold() { return baseGold; }
        public double GoldModifier() { return goldModifier; }
        public double SpawnChance() { return spawnChance; }
    }
}
