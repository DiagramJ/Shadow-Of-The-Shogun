public abstract class Job
{
    protected int[] baseStat;
    protected string name;
    protected int id;
    protected string sprite;
    protected int[] availableSkills;
    protected int[] availableBasicAttacks;
    protected int[] availableEquipment;

    public int[] BaseStat
    {
        get { return baseStat; }
    }

    public string Name
    {
        get { return name; }
    }

    public int ID
    {
        get { return ID; }
    }

    public string Sprite
    {
        get { return sprite; }
    }

}

