using UnityEngine;
using System.Collections;

public abstract class Skill
{
    protected Action action;
    protected Action enhancedAction;
    public int mpCost;
    public string name;
    public string info;
    public int[] targets;
    public int[][] targetShape;
    public virtual void run(Character attacker, int[] targets)
    {
        action.run(attacker, targets);
    }
    public virtual void runEnhancedAction(Character attacker, int[] targets)
    {
        enhancedAction.run(attacker, targets);
    }
    bool checkMp(int amount)
    {
        return amount >= mpCost;
    }
}
