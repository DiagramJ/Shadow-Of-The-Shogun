public abstract class Equipment
{
    public string name;
    public string description;
    public BattleEffect[] effects;
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
    public virtual void apply(Character character)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].apply(character);
        }
    }
    public virtual void falloff(Character character)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].falloff(character);
        }
    }
}
