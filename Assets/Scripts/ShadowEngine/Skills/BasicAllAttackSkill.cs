﻿using UnityEngine;
using System.Collections;

public class BasicAllAttackSkill : Skill
{
    public BasicAllAttackSkill()
    {
        mpCost = 0;
        name = "Basic Attack All";
        info = new Message("Basic attack all\n100% accuracy\n<color=#ff0000ff>50</color> base damage");
        enhancedInfo = null;

        targets = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        targetShape = new int[9][];
        for (int i = 0; i < targetShape.Length; i++)
        {
            targetShape[i] = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        }

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