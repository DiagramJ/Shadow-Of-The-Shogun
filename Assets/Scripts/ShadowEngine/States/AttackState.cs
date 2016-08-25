using UnityEngine;
using System.Collections;
using System;

class AttackState : State
{
    public AttackState ( int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if(!once)
        {
            SkillList List = BattleManager.instance.skillList;
            Character current = BattleManager.instance.turnOrder.currentCharacter;
            int index = current.BattleBuild.basicAttack;
            if ((int)input[3] != -1)
                index = current.BattleBuild.skills[(int)input[3]];
            if ((bool)input[4])
                List.get(index).runEnhancedAction(BattleManager.instance.turnOrder.currentCharacter, (int[])input[2]);
            else
                List.get(index).run(BattleManager.instance.turnOrder.currentCharacter, (int[])input[2]);
            BattleManager.instance.highlightManager.setTargetSelector(null, null);
            BattleManager.instance.highlightManager.clearSkillSelected();
            BattleManager.instance.boardManager.hidePopUp();
            BattleManager.instance.boardManager.hideSkills();
            once = true;
        }
        return StateList.PostAttack;
    }
}
