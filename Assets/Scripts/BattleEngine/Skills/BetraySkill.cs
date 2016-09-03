using UnityEngine;
using System.Collections;

public class BetraySkill : Skill
{
    public BetraySkill()
    {
        mpCost = 10;
        name = "Betray";
        info = new Message("Party member\nwill betray");
        enhancedInfo = null;
        targets = new int[] { 0, 1, 2, 4, 5, 6, 7, 8 };
        targetShape = null;
        enhancedTargetShape = new int[9][];
        for (int i = 0; i < enhancedTargetShape.Length; i++)
            enhancedTargetShape[i] = new int[] { 0, 1, 2, 4, 5, 6, 7, 8 };
    }
    public override void run(Character attacker, int[] targets)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            Character target = (Character)BattleManager.instance.list.get(targets[i]);
            if (target != null)
            {
                target.addLoyalty(-100);
                BattleManager.instance.loyaltyManager.Betray(target);
            }
        }
    }
    public override void runEnhancedAction(Character attacker, int[] targets)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            Character target = (Character)BattleManager.instance.list.get(targets[i]);
            if (target != null)
            {
                target.addLoyalty(-100);
                BattleManager.instance.loyaltyManager.Betray(target);
            }
        }
    }
}

