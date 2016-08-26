using UnityEngine;
using System.Collections;

public class BasicHealSkill : Skill
{
    public BasicHealSkill()
    {
        mpCost = 0;
        name = "Basic Heal";
        info = new Message("Basic heal\n100% accuracy\n<color=#ff0000ff>50</color> base Healing");
        enhancedInfo = null;


        targets = new int[] { 0, 1, 2, 4, 5, 6, 7, 8};
        targetShape = null;
        enhancedTargetShape = new int[9][];

        for (int i = 0; i < enhancedTargetShape.Length; i++)
            enhancedTargetShape[i] = new int[] { 0, 1, 2, 4, 5, 6, 7, 8 };

        BasicHealAction tempAction = new BasicHealAction();
        tempAction.accuracy = 100;
        tempAction.baseDamage = 50;
        tempAction.phisical = true;
        action = tempAction;

        BasicHealAction tempEnhancedAction = new BasicHealAction();
        tempEnhancedAction.accuracy = 100;
        tempEnhancedAction.baseDamage = 100;
        tempEnhancedAction.phisical = true;
        enhancedAction = tempEnhancedAction;
    }
}
