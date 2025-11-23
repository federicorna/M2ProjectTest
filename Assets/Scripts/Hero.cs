using UnityEngine;



[System.Serializable]

public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon weapon;

    //-------------costruttori-------------
    public Hero (string name)
    {
        this.name = name;
    }
    public Hero (int hp)
    {
        this.hp = hp;
    }
    public Hero (Stats baseStats)
    {
        this.baseStats = baseStats;
    }
    public Hero (ELEMENT resistance, ELEMENT weakness)
    {
        this.resistance = resistance;
        this.weakness = weakness;
    }
    public Hero (Weapon weapon)
    {
        this.weapon = weapon;
    }


    //-------------getter-------------
    public string GetName()
    {
        return name;
    }
    public int GetHp()
    {
        return hp;
    }
    public Stats GetBaseStats()
    {
        return baseStats;
    }
    public ELEMENT GetResistance()
    {
        return resistance;
    }
    public ELEMENT GetWeakness()
    {
        return weakness;
    }
    public Weapon GetWeapon()
    {
        return weapon;
    }

    //-------------setter-------------
    public void SetName (string name)
    {
        this.name = name;
    }
    public void SetHp (int hp)
    {
        this.hp = hp;
    }
    public void SetBaseStats (Stats baseStats)
    {
        this.baseStats = baseStats;
    }
    public void SetResistance (ELEMENT resistance)
    {
        this.resistance = resistance;
    }
    public void SetWeaknes (ELEMENT weakness)
    {
        this.weakness = weakness;
    }
    public void SetWeapon (Weapon weapon)
    {
        this.weapon = weapon;
    }


    //f.ni AddHp, TakeDamage, IsAlive

    public void AddHp (int amount)
    {
        SetHp(hp + amount);  
    }

    public void TakeDamage (int damage)
    {
        AddHp(- damage);
    }

    public bool IsAlive()
    {
        if (hp > 0)
        {
            return true;
        }
        return false;
    }
}