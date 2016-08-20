using System.Collections;

public class BattleStats
{
    private int[] Stats;
    private int MaxHp;
    private ArrayList statusEffects;
    public BattleStats()
    {
        Stats = new int[6];
        statusEffects = new ArrayList();
        MaxHp = 0;
    }
    public void setStats(int [] stats)
    {
        for (int i = 0; i < 6; i++)
            Stats[i] = stats[i];
        MaxHp = Stats[0];
    }

    public void damage(int amount)
    {
        Stats[0] += amount;
        if (Stats[0] < 0)
            Stats[0] = 0;
        if (Stats[0] > MaxHp)
            Stats[0] = MaxHp;
    }

    public void addAttack(int amount)
    {
        Stats[1] += amount;
        if (Stats[1] < 0)
            Stats[1] = 0;
    }

    public void addDefence(int amount)
    {
        Stats[2] += amount;
        if (Stats[2] < 0)
            Stats[2] = 0;
    }

    public void addMagicAttack(int amount)
    {
        Stats[3] += amount;
        if (Stats[3] < 0)
            Stats[3] = 0;
    }

    public void addMagicDefence(int amount)
    {
        Stats[4] += amount;
        if (Stats[4] < 0)
            Stats[4] = 0;
    }

    public void addSpeed(int amount)
    {
        Stats[5] += amount;
        if (Stats[5] < 0)
            Stats[5] = 0;
    }

    public int HP
    {
        get { return Stats[0]; }
    }

    public int Attack
    {
        get { return Stats[1]; }
    }

    public int Defence
    {
        get { return Stats[2]; }
    }

    public int MagicAttack
    {
        get { return Stats[3]; }
    }

    public int MagicDefence
    {
        get { return Stats[4]; }
    }

    public int Speed
    {
        get { return Stats[5]; }
    }

    public ArrayList StatusEffect
    {
        get { return statusEffects; }
    }
}
