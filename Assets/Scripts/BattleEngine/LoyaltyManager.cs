using UnityEngine;
using System;
using System.Collections;

public class LoyaltyManager
{
    public LoyaltyManager()
    {

    }
    public int Recruit(Character target)
    {
        double limit = Math.Pow(10, -(100 - target.Loyalty) / 80.0) - .1;
        double roll = GameManager.instance.random.NextDouble();
        if (roll >= limit)
            return -1;
        int position = BattleManager.instance.boardManager.getOpenPlayerPositon();
        if (position != -1)
        {
            BattleManager.instance.boardManager.moveCharacter(target, position);
            return 1;
        }
        return 0;
    }
    public int Betray(Character target)
    {
        double limit = Math.Pow(10, - target.Loyalty / 80.0) - .1;
        double roll = GameManager.instance.random.NextDouble();
        if (roll >= limit)
            return -1;
        int position = BattleManager.instance.boardManager.getOpenEnemyPositon();
        if (position != -1)
        {
            BattleManager.instance.boardManager.moveCharacter(target, position);
            return 1;
        }
        return 0;
    }
}
