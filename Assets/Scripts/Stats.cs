


[System.Serializable]
public struct Stats
{
    public int atk, def, res, spd, crt, aim, eva; //variabili

    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva) //costruttore prende lo struct o classe
    {
        this.atk = atk; //this prende public int vartiabile = variabile passata
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }

    //f.ne somma statistiche
    public static Stats Sum (Stats stats1, Stats stats2)    //f.ne stats che prende 2 stats
    {
        Stats SommaStats = new Stats    //nuova stats che prende le somme
        (
            stats1.atk + stats2.atk,
            stats1.def + stats2.def,
            stats1.res + stats2.res,
            stats1.spd + stats2.spd,
            stats1.crt + stats2.crt,
            stats1.aim + stats2.aim,
            stats1.eva + stats2.eva
        );
        return SommaStats;  //ritorno quello che mi chiede la f.ne, un dato stats SommaStats

    }

}