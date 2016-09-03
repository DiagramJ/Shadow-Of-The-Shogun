using UnityEngine;
using System.Collections;

public class BasicRowAttackSkill : Skill
{
    public BasicRowAttackSkill()
    {
        mpCost = 50;
        name = "Basic Attack Row";
        info = new Message("Basic attack row\n100% accuracy\n<color=#ff0000ff>50</color> base damage");
        enhancedInfo = new Message("Basic attack row\n100% accuracy\n<color=#ffff00ff>100</color> base damage");


        targets = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        targetShape = new int[9][];
        targetShape[0] = new int[] { 9, 10, 11 };
        targetShape[1] = new int[] { 9, 10, 11 };
        targetShape[2] = new int[] { 9, 10, 11 };
        targetShape[3] = new int[] { 12, 13, 14 };
        targetShape[4] = new int[] { 12, 13, 14 };
        targetShape[5] = new int[] { 12, 13, 14 };
        targetShape[6] = new int[] { 15, 16, 17 };
        targetShape[7] = new int[] { 15, 16, 17 };
        targetShape[8] = new int[] { 15, 16, 17 };


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
