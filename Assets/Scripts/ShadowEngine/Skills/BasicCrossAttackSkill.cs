using UnityEngine;
using System.Collections;

public class BasicCrossAttackSkill : Skill
{
    public BasicCrossAttackSkill()
    {
        mpCost = 0;
        name = "Basic Attack Cross";
        info = new Message("Basic attack cross\n100% accuracy\n<color=#ff0000ff>50</color> base damage");
        enhancedInfo = null;

        targets = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        targetShape = new int[9][];
        targetShape[0] = new int[] { 9, 13, 17 };
        targetShape[1] = new int[] { 10, 12, 14 };
        targetShape[2] = new int[] { 11, 13, 15 };
        targetShape[3] = new int[] { 12, 16, 10 };
        targetShape[4] = new int[] { 13, 9, 15, 11, 17 };
        targetShape[5] = new int[] { 14, 16, 10 };
        targetShape[6] = new int[] { 15, 13, 11 };
        targetShape[7] = new int[] { 16, 12, 14 };
        targetShape[8] = new int[] { 17, 13, 9 };

        BasicAttackAction tempAction = new BasicAttackAction();
        tempAction.accuracy = 100;
        tempAction.baseDamage = 50;
        tempAction.phisical = true;
        action = tempAction;

        BasicAttackAction tempEnhancedAction = new BasicAttackAction();
        tempEnhancedAction.accuracy = 100;
        tempEnhancedAction.baseDamage = 100;
        tempEnhancedAction.phisical = true;
        enhancedAction = tempEnhancedAction;
    }
}
