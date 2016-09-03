using System.Collections;

public class BattleStats
{
    private int[] Stats;
    private int maxHp;
    private ArrayList statusEffects;
    private int[] traitCooldown;
    public BattleStats()
    {
        Stats = new int[6];
        traitCooldown = new int [6];
        statusEffects = new ArrayList();
        maxHp = 0;
    }
    public void setStats(int [] stats)
    {
        for (int i = 0; i < 6; i++)
            Stats[i] = stats[i];
        maxHp = Stats[0];
    }
    public void turnStart()
    {
        for (int i = 0; i < traitCooldown.Length; i++)
            if (traitCooldown[i] !=0)
                traitCooldown[i]--;
    }
    public void setCooldown(Character character, Trait trait)
    {
        int amount = trait.cooldown;
        int id = trait.ID;
        int [] share = trait.shareCooldown;
        int[] traits = character.BattleBuild.traits; 
        for (int i = 0; i < traitCooldown.Length; i++)
        {
            if (traits[i] == id)
                TraitCooldown[i] = amount;
        }
        if(share != null)
        {
            for (int i = 0; i < share.Length; i++)
            {
                for (int j = 0; j < traitCooldown.Length; j++)
                {
                    if (traits[j] == share[i])
                        TraitCooldown[j] = amount;
                }
            }
        }
    }
    public void damage(int amount)
    {
        Stats[0] -= amount;
        if (Stats[0] < 0)
            Stats[0] = 0;
        if (Stats[0] > maxHp)
            Stats[0] = maxHp;
    }
    public void addHp(int amount)
    {
        maxHp += amount;
        if (maxHp < 0)
            maxHp = 0;
        if (Stats[0] > maxHp)
            Stats[0] = maxHp;
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
    public bool addStatusEffect(StatusEffect newEffect)
    {
        bool found = false;
        foreach(StatusEffect effects in statusEffects)
        {
            if (effects.ID == newEffect.ID)
                found = effects.reapply(newEffect);
            if (found)
                break;
        }
        if (!found)
            statusEffects.Add(newEffect);
        return found;
    }
    public int HP
    {
        get { return Stats[0]; }
    }
    public int MaxHP
    {
        get { return maxHp; }
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
    public int [] TraitCooldown
    {
        get { return traitCooldown; }
    }
}
