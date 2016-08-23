using UnityEngine;
using System.Collections;

public class BasicAttackSkill : Skill
{
    public BasicAttackSkill()
    {
        mpCost = 0;
        name = "Basic Attack";
        info = "Basic attack 100% accuracy 50 base damage";

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
