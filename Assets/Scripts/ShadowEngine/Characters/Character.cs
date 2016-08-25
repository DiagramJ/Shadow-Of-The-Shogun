public class Character
{
    public int position;

    private int loyalty;
    private CoreStats coreStats;
    private BattleStats battleStats;
    private BattleBuild build;
    private Job job;
    private string name;
    private int level;
    private int effortBank;
    private bool enemy;

    public Character(string characterName, Job characterJob)
    {
        job = characterJob;
        name = characterName;
        level = 1;
        effortBank = 1;
        coreStats = new CoreStats();
        battleStats = new BattleStats();
        build = new BattleBuild();
        coreStats.setBaseStats(job.BaseStat);
        coreStats.calculateStats(level);
        battleStats.setStats(coreStats.getStats);
        enemy = false;
        loyalty = 100;
    }
    public void levelUp()
    {
        if (level == 100)
            return;
        level++;
        effortBank++;
        if (level % 2 == 0)
            effortBank++;
        if (level % 5 == 0)
            effortBank += 4;
        if (level % 10 == 0)
            effortBank += 2;
        coreStats.calculateStats(level);
        battleStats.setStats(coreStats.getStats);
    }
    public bool addEffort(int [] newEffortStats)
    {
        int totalEffort = 0;
        for (int i = 0; i < 6; i++)
        {
            totalEffort += newEffortStats[i];
        }
        if (totalEffort > effortBank)
            return false;
        int overEffort = coreStats.addEffortStats(newEffortStats);
        effortBank -= totalEffort;
        effortBank += overEffort;
        coreStats.calculateStats(level);
        battleStats.setStats(coreStats.getStats);
        return true;
    }
    public void clearEffort()
    {
        effortBank += coreStats.clearEffortStats();
    }
    public void addLoyalty(int amount)
    {
        loyalty += amount;
        if (loyalty < 0)
            loyalty = 0;
        if (loyalty > 100)
            loyalty = 100;
    }

    public int EffortBank
    {
        get { return effortBank; }
    }

    public int Level
    {
        get { return level; }
    }
    public int Loyalty
    {
        get { return loyalty; }
    }
    public string Name
    {
        set { name = Name; }
        get { return name; }
    }

    public Job Job
    {
        get { return job; }
    }

    public CoreStats CoreStats
    {
        get { return coreStats; }
    }

    public BattleStats BattleStats
    {
        get { return battleStats; }
    }

    public BattleBuild BattleBuild
    {
        get { return build; }
    }

    public bool Enemy
    {
        get { return enemy; }
    }

    public void isAnEnemy()
    {
        enemy = true;
    }
    public void switchSides()
    {
        enemy = !enemy;
    }
}
