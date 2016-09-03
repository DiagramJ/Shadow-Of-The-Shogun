
public abstract class StatusEffect
{
    protected string name;
    protected int id;
    protected BattleEffect [] effects;
    protected int turnCount;
    public virtual bool reapply(StatusEffect effect)
    {
        turnCount = effect.TurnCount;
        return true;
    }
    public virtual bool endTurn(Character character)
    {
        if (turnCount > 0)
            turnCount--;
        if (turnCount == 0)
        {
            for (int i = 0; i < effects.Length; i++)
                effects[i].falloff(character);
            return true;
        }
        return false;
    }
    public virtual void run(Character character, int type)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i].check(type))
                effects[i].run(character);
        }
    }
    public virtual void run(AttackData attackData, int type)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i].check(type))
                effects[i].run(attackData);
        }
    }
    public virtual void applyEffects(Character character)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].apply(character);
        }
    }
    public string Name
    {
        get { return name; }
    }
    public int TurnCount
    {
        get { return turnCount; }
    }
    public int ID
    {
        get{ return id; }
    }
}
