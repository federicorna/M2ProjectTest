using UnityEngine;



public class M1ProjectTest : MonoBehaviour
{   
    [SerializeField] private Hero a;
    [SerializeField] private Hero b;
    int round = 1;


    //logica attacchi
    public void Attack (Hero attacker, Hero defender)
    {
        //se non c'e' l'attacker finisce la logica simile update
        if (!attacker.IsAlive())
        {
            return; //fine
        }

        Debug.Log($"Attaca {attacker.GetName()} e si difende {defender.GetName()}");



        Stats attStats = Stats.Sum (attacker.GetBaseStats(), attacker.GetWeapon().GetBonusStats());
        Stats defStats = Stats.Sum (defender.GetBaseStats(), defender.GetWeapon().GetBonusStats());



        if (GameFormulas.HasHit (attStats, defStats) == true)
        {
            if (GameFormulas.HasElementAdvantage (attacker.GetWeapon().GetElem(), defender))
            {
                Debug.Log($"WEAKNESS!");
            }
            else if (GameFormulas.HasElementDisadvantage(attacker.GetWeapon().GetElem(), defender))
            {
                Debug.Log($"RESIST!");
            }
            
            int finalDamage = GameFormulas.CalculateDamage (attacker, defender);

            Debug.Log($"{attacker.GetName()} ha inflitto {finalDamage}");

            defender.TakeDamage (finalDamage);

            Debug.Log($"{defender.GetName()} ha {defender.GetHp()}");
        }

        

        if (!defender.IsAlive())
        {
            Debug.Log($"Il vincitore e' {attacker.GetName()}!");
            return;
        }

    }

    

    public void Update()
    {
        //prima cosa creo stats due eroi + armmi
        Stats aStats = Stats.Sum(a.GetBaseStats(), a.GetWeapon().GetBonusStats());
        Stats bStats = Stats.Sum(b.GetBaseStats(), b.GetWeapon().GetBonusStats());

        //turni di chi attacca chi difende
        Hero attacker;
        Hero defender;

        //se uno o l'altro non sono vivi
        if (!a.IsAlive() || !b.IsAlive())
        {
            return; //fine
        }

        Debug.Log($"ROUND: {round}");

        //definizione primo e secondo 
        if (aStats.spd > bStats.spd)
        {
            attacker = a;
            defender = b;
        }
        else
        {
            attacker = b;
            defender = a;
        }

        Attack (attacker, defender);    //attacco primo

        //inverto i ruoli per l'attacco del secondo
        if (attacker == a)
        {
            attacker = b;
            defender = a;
        }
        else
        {
            attacker = a;
            defender = b;
        }

        Attack(attacker, defender);     //attacco secondo

        round++;
    }
}
