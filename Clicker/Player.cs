using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace Clicker
{
    public class Player
    {
        int lvl;
        BigNumber gold;
        BigNumber damage;
        double damageModifier;
        BigNumber upgradeCost;
        double upgradeModifier;

        public int Lvl
        {
            get { return lvl; }
            set { lvl = value; }
        }
        public BigNumber Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public BigNumber Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public double DamageModifier
        {
            get { return damageModifier; }
            set { damageModifier = value; }
        }
        public BigNumber UpgradeCost
        {
            get { return upgradeCost; }
            set { upgradeCost = value; }
        }
        public double UpgradeModifier
        {
            get { return upgradeModifier; }
            set { upgradeModifier = value; }
        }

        public Player(int Lvl, BigNumber Gold, BigNumber Damage, double DamageModifier)
        {
            lvl = Lvl;
            gold = Gold;
            damage = Damage;
            damageModifier = DamageModifier;
        }
        
        public void AddGold (BigNumber amount)
        {

        }

        public bool TryUpgrade()
        {

        }

        public BigNumber DealDamage()
        {

        }

        private void RecalculateStats()
        {

        }

        private BigNumber CalculateNextUpgradeCost()
        {

        }

        private BigNumber CalculateTotalDamage()
        {

        }

        private bool TrySpendGold(BigNumber amount)
        {

        }

    }
}
