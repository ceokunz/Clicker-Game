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
        string name;
        string iconName;

        //Атрибуты здоровья
        int baseLife;
        double lifeModifier;

        //Атрибуты золота за победу над противником
        int baseGold;
        double goldModifier;

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

        //свойства---------------------------------------------------------
        
        [JsonInclude]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        [JsonInclude]

        public string IconName
        {
            get { return iconName; }
            set { iconName = value; }
        }
        [JsonInclude]
        public int BaseLife
        {
            get { return baseLife; }
            set { baseLife = value; }
        }
        [JsonInclude]
        public double LifeModifier
        {
            get { return lifeModifier; }
            set { lifeModifier = value; }
        }
        [JsonInclude]
        public int BaseGold
        {
            get { return baseGold; }
            set { baseGold = value; }
        }
        [JsonInclude]
        public double GoldModifier
        {
            get { return goldModifier; }    
            set { goldModifier = value; }
        }
        [JsonInclude]
        public double SpawnChance
        {
            get { return spawnChance; }
            set { spawnChance = value; }

        }
    }
}
