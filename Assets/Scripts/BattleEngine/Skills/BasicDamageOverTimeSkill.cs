using UnityEngine;
using System.Collections;

public class BasicDamageOverTimeSkill : Skill
{
    public BasicDamageOverTimeSkill()
    {
        mpCost = 50;
        name = "Basic Damage Over Time";
        info = new Message("Basic DOT\n100% accuracy\n<color=#ff0000ff>10</color> per tick\n5 turns");
        enhancedInfo = null;

        targets = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        targetShape = null;
        enhancedTargetShape = new int[9][];
        for (int i = 0; i < enhancedTargetShape.Length; i++)
        {
            enhancedTargetShape[i] = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        }

        ApplyStatusEffectAction tempAction = new ApplyStatusEffectAction(StatusEffectList.DamageOverTime);
        action = tempAction;

        ApplyStatusEffectAction tempEnhancedAction = new ApplyStatusEffectAction(StatusEffectList.DamageOverTime);
        enhancedAction = tempEnhancedAction;
    }
}
