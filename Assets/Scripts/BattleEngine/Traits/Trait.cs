using UnityEngine;
using System.Collections;

public abstract class Trait
{
    public const int TargetSelf = 0;
    public const int TargetParty = 1;
    public const int TargetEnemyParty = 2;

    public string name;
    public Message info;
    public int cooldown;
    public int[] shareCooldown;
    protected int id;
    protected Action action;
    protected int type;
    public virtual void run(Character character)
    {
        action.run(character, getTargets(character));
    }
    public int ID
    {
        get { return id; }
    }
    public int [] getTargets(Character character)
    {
        int[] target = { character.position };
        if (type == TargetParty)
            target = new int[] { 0, 1, 2, 4, 5, 6, 7, 8 };
        if (type == TargetEnemyParty)
            target = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        return target;
    }
}
