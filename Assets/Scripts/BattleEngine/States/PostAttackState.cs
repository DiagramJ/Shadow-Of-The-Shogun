using UnityEngine;
using System.Collections;
using System;

class PostAttackState : State
{
    public PostAttackState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if(!once)
        {
            BattleManager.instance.applyAttackDamage();
            BattleManager.instance.boardManager.updateHealthBars();
            BattleManager.instance.infoStrip.add("Attack ", 60);
            once = true;
        }
        if (BattleManager.instance.infoStrip.isActive())
            return id;
        return StateList.DeathCheck;
    }
}
