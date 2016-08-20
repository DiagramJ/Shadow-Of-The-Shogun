using System;

// HP
// Attack
// Defence
// Magic Attack
// Magic Defence
// Speed
public class CoreStats
{
    private int[] individualStats;
    private int[] effortStats;
    private int[] baseStats;
    private int[] Stats;

    public CoreStats()
    {
        individualStats = new int[6];
        effortStats = new int[6];
        baseStats = new int[6];
        Stats = new int[6];
        randomizeCoreStats();
    }

    public void randomizeCoreStats()
    {
        for (int i = 0; i < 6; i++)
        {
            individualStats[i] = GameManager.instance.random.Next(0, 32);
        }
    }

    public int clearEffortStats()
    {
        int totalStats = 0;
        for (int i = 0; i < 6; i++)
        {
            totalStats += effortStats[i];
            effortStats[i] = 0;
        }
        return totalStats;
    }

    public int addEffortStats(int[] addStats)
    {
        int overEffort = 0;
        for (int i = 0; i < 6; i++)
        {
            effortStats[i] += addStats[i];
            if (effortStats[i] > 100)
            {
                overEffort += effortStats[i] - 100;
                effortStats[i] = 100;
            }
        }
        return overEffort;
    }

    public void setBaseStats(int[] newBaseStats)
    {
        for (int i = 0; i < 6; i++)
        {
            baseStats[i] += newBaseStats[i];
            if (baseStats[i] > 255)
                baseStats[i] = 255;
        }
    }

    public void calculateStats(int level)
    {
        for (int i = 0; i < 6; i++)
        {
            Stats[i] = calculateStat(level, i);
        }
    }

    private int calculateStat(int level, int index)
    {
        double adjustedEffortStat = effortStats[index] * 0.63;
        double Stat = 2 * baseStats[index];
        Stat += individualStats[index];
        Stat += adjustedEffortStat;
        Stat *= level;
        Stat /= 100.0;
        if (index == 0)
        {
            Stat += level;
            Stat += 10;
            return (int)Stat;
        }
        else
        {
            Stat += 5;
            return (int)Stat;
        }
    }

    public int getHP
    {
        get { return Stats[0]; }
    }

    public int getAttack
    {
        get { return Stats[1]; }
    }

    public int getDefence
    {
        get { return Stats[2]; }
    }

    public int getMagicAttack
    {
        get { return Stats[3]; }
    }

    public int getMagicDefence
    {
        get{ return Stats[4]; }
    }

    public int getSpeed
    {
        get { return Stats[5]; }
    }

    public int [] Effort
    {
        get { return effortStats; }
    }
    public int[] getStats
    {
        get { return Stats; }
    }
}

