using UnityEngine;
using System.Collections;

public class RecruitSkill : Skill
{
    public RecruitSkill()
    {
        mpCost = 10;
        name = "Recruit";
        info = new Message("Recruit an enemy");
        enhancedInfo = null;
        targets = new int[] {9, 10, 11, 12, 13, 14, 15, 16, 17 };
        targetShape = null;
        enhancedTargetShape = new int[9][];
        for (int i = 0; i < enhancedTargetShape.Length; i++)
            enhancedTargetShape[i] = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
    }
    public override void run(Character attacker, int[] targets)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            Character target = (Character)BattleManager.instance.list.get(targets[i]);
            if (target != null)
            {
                target.addLoyalty(100);
                BattleManager.instance.loyaltyManager.Recruit(target);
            }
        }
    }
    public override void runEnhancedAction(Character attacker, int[] targets)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            Character target = (Character)BattleManager.instance.list.get(targets[i]);
            if(target != null)
            {
                target.addLoyalty(100);
                BattleManager.instance.loyaltyManager.Recruit(target);
            }
        }
    }
}
