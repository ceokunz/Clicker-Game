using Clicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Enemy
{
    private string name;
    private BigNumber maxHttpoints;
    private BigNumber currentHttpoints;
    private BigNumber goldReward;
    private bool isDead;
    private IconItem icon;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public BigNumber MaxHttpoints
    {
        get { return maxHttpoints; }
        set { maxHttpoints = value; }
    }

    public BigNumber GoldReward
    {
        get { return goldReward; }
        set { goldReward = value; }
    }

    public BigNumber CurrentHttpoints
    {
        get { return currentHttpoints; }
        set { currentHttpoints = value; }
    }

    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    public IconItem Icon
    {
        get { return icon; }
        set { icon = value; }
    }


    public Enemy(string Name, BigNumber MaxHttpoints, BigNumber GoldReward, BigNumber CurrentHttpoints, bool IsDead, IconItem Icon)
    {
        name = Name;
        maxHttpoints = MaxHttpoints;
        goldReward = GoldReward;
        currentHttpoints = CurrentHttpoints;
        isDead = IsDead;
        icon = Icon;
    }

    public bool TakeDamage(BigNumber dmg, out BigNumber GoldReward)
    {
        
    }

    private void Die()
    {
       
    }
}


