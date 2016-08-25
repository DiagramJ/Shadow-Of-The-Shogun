using UnityEngine;
using System.Collections;

public class BasicColumnAttackSkill : Skill
{
    public BasicColumnAttackSkill()
    {
        mpCost = 0;
        name = "Basic Attack";
        info = "Basic attack 100% accuracy 50 base damage";

        targets = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        targetShape = new int[9][];
        targetShape[0] = new int[] { 9, 12, 15 };
        targetShape[1] = new int[] { 10, 13, 16 };
        targetShape[2] = new int[] { 11, 14, 17 };
        targetShape[3] = new int[] { 9, 12, 15 };
        targetShape[4] = new int[] { 10, 13, 16 };
        targetShape[5] = new int[] { 11, 14, 17 };
        targetShape[6] = new int[] { 9, 12, 15 };
        targetShape[7] = new int[] { 10, 13, 16 };
        targetShape[8] = new int[] { 11, 14, 17 };

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
