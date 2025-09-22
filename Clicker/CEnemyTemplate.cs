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

        public string getName() { return name; }
        public string getIconName() { return iconName; }
        public int getBaseLife() { return baseLife; }
        public double getLifeModifier() { return lifeModifier; }
        public int getBaseGold() { return baseGold; }
        public double getGoldModifier() { return goldModifier; }  
        public double getSpawnChance() { return spawnChance; }

        

    }
}
