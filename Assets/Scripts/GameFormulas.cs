using UnityEngine;



public static class GameFormulas    //tutte le f.ni static
{
    public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.GetWeakness())
        {
            return true;
        }
        return false;
    }

    public static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.GetResistance())
        {
            return true;
        }
        return false;
    }

    public static float EvaluateElementModifier(ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender))
        {
            return 1.5f;
        }
        if (HasElementDisadvantage(attackElement, defender))
        {
            return 0.5f;
        }
        return 1f;
    }

    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker.aim - defender.eva;
        int dado = Random.Range(0, 100);    //100 e non 99 perche altrimmenti 99 non e' compreso

        if (hitChance > dado)
        {
            Debug.Log("MISS");
            return false;
        }
        else
        {
            return true;
        }
    }

    public static bool IsCrit(int critValue)
    {
        int dado = Random.Range(0, 100);

        if (critValue > dado)
        {
            Debug.Log("CRIT");
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        //che stats ha attacker? GetBaseStats. Che arma usa attacker? GetWeapon. L'arma presa, che stats ha? GetBonusStasts
        Stats attackerStatsTot = Stats.Sum(attacker.GetBaseStats(), attacker.GetWeapon().GetBonusStats());
        Stats defenderStatsTot = Stats.Sum(defender.GetBaseStats(), defender.GetWeapon().GetBonusStats());

        int defence;

        // che tipo di danno? di cosa? fatto da chi?    == danno magico di cosa?
        if (attacker.GetWeapon().GetDmgType() == Weapon.DAMAGE_TYPE.MAGICAL)
        {
            //che cosa? che tipo di difesa? chi?
            defence = defenderStatsTot.res;
        }
        else
        {
            defence = defenderStatsTot.def;
        }

        float baseDamage = attackerStatsTot.atk - defence;

        baseDamage = baseDamage * EvaluateElementModifier(attacker.GetWeapon().GetElem(), defender);

        if (IsCrit(attackerStatsTot.crt))
        {
            baseDamage = baseDamage * 2;
        }
        // else?

        if (baseDamage < 0)
        {
            baseDamage = 0;
            return (int)baseDamage;    //(int) perche la funzione deve tornare un int
        }
        return (int)baseDamage;
    }
}