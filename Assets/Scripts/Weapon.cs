using UnityEngine;



[System.Serializable]

public class Weapon
{
    [SerializeField] private string name;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private ELEMENT elem;
    [SerializeField] private Stats bonusStats;


    //enum DAMAGE_TYPE
    public enum DAMAGE_TYPE
    {
        PHYSICAL = 10,
        MAGICAL = 20,
    }


    //costruttori di classe weapon
    public Weapon (string name) //costruttore name
    {
        this.name = name;
    }
    public Weapon(DAMAGE_TYPE dmgType)  //costruttore dmgType
    {
        this.dmgType = dmgType;
    }
    public Weapon(ELEMENT elem) //costruttore elem
    {
        this.elem = elem;
    }
    public Weapon(Stats bonusStats) //costruttore bonusStats
    {
        this.bonusStats = bonusStats;
    }


    //-------------getter-------------
    public string Getname ()
    {
        return name;
    }
    public DAMAGE_TYPE GetDmgType()
    {
        return dmgType;
    }
    public ELEMENT GetElem()
    {
        return elem;
    }
    public Stats GetBonusStats()
    {
        return bonusStats;
    }


    //-------------setter-------------
    public void SetName (string name)
    {
        this.name = name;
    }
    public void SetDmgType (DAMAGE_TYPE dmgType)
    {
        this.dmgType = dmgType;
    }
    public void SetElem (ELEMENT elem)
    {
        this.elem = elem;
    }
    public void SettBonusStats (Stats bonusStats)
    {
        this.bonusStats = bonusStats;
    } 
    
    //setter di damagetype, element e string magari potri non metterli
    //perche li modifico gia da ispector se non ci sono casi eccezionali
    //come impostare che il bonus damage non sia <= 0?

} 

