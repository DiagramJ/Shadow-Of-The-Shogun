using UnityEngine;
using System.Collections;

public class PlayerTraitState : State
{
    public PlayerTraitState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if (!once)
        {
            TraitList List = BattleManager.instance.traitList;
            Character current = BattleManager.instance.turnOrder.currentCharacter;
            if ((int)input[5] != -1)
            {
                int index = current.BattleBuild.traits[(int)input[5]];
                List.get(index).run(current);
            }
            BattleManager.instance.highlightManager.setTargetSelector(null, null);
            BattleManager.instance.boardManager.hidePopUp();
            BattleManager.instance.boardManager.hideSkills();
            BattleManager.instance.highlightManager.clearPressButton();
            once = true;
        }
        return StateList.PostPlayerTrait;
    }
}