using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]

public class Weapon
{
    [SerializeField] private string name;
    [SerializeField] DAMAGE_TYPE dmgType;
    [SerializeField] ELEMENT elem;
    [SerializeField] private Stats bonusStats;


    public enum DAMAGE_TYPE
    {
        PHYSICAL, MAGICAL
    }

    public string GetName()
    {
        return name;
    }

    public Stats GetBonusStats()
    {
        return bonusStats;
    }

    public void SetBonusStats(Stats bonusStats)
    {
            
        if (bonusStats.atk < 0)
        {

        }
    }

    


} 

