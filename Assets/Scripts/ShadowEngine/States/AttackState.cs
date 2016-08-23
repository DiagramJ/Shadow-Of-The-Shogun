using UnityEngine;
using System.Collections;
using System;

class AttackState : State
{
    Skill attack;
    public AttackState ( int ID)
    {
        id = ID;
        once = false;
        attack = new BasicAttackSkill();
    }
    public override int run(ArrayList input)
    {
        if(!once)
        {
            attack.run(BattleManager.instance.turnOrder.currentCharacter, (int[])input[2]);
            BattleManager.instance.highlightManager.setTargetSelector(null, null);
            BattleManager.instance.highlightManager.clearSkillSelected();
            BattleManager.instance.boardManager.hidePopUp();
            BattleManager.instance.boardManager.hideSkills();
            once = true;
        }
        return StateTable.PostAttack;
    }
}
