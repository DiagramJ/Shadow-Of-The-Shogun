using UnityEngine;
using System.Collections;

public class BasicHealSkill : Skill
{
    public BasicHealSkill()
    {
        mpCost = 0;
        name = "Basic Heal";
        info = "Basic Heal 100% accuracy 50 base Healing";


        targets = new int[] { 0, 1, 2, 4, 5, 6, 7, 8};
        targetShape = null;

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
