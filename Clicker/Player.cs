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

        public Player(int Lvl, BigNumber Gold, BigNumber Damage, double DamageModifier, BigNumber UpgradeCost, double UpgradeModifier)
        {
            lvl = 1;
            gold = Gold;
            damage = Damage;
            damageModifier = DamageModifier;
            upgradeCost = UpgradeCost;
            upgradeModifier = UpgradeModifier;
        }

        public bool GainGold(BigNumber amount)
        {
            gold.Add(amount);
            return true;
        }

        public bool Upgrade()
        {
            if (gold.CompareAbsolute(upgradeCost) >= 0)
            {
                gold.Subtract(upgradeCost);
                lvl++;

                damage.Multiply(damageModifier);
                upgradeCost.Multiply(upgradeModifier);

                return true;
            }
            return false;
        }

        public BigNumber ApplyDamage(Enemy enemy)
        {
            enemy.TakeDamage(damage);
        }

        //private void RecalculateStats()
        //{

        //}

        //private BigNumber CalculateNextUpgradeCost()
        //{

        //}

        //private BigNumber CalculateTotalDamage()
        //{

        //}

        //private bool TrySpendGold(BigNumber amount)
        //{

        //}

    }
}
