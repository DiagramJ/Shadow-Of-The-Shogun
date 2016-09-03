using UnityEngine;
using System.Collections;
using System;

public class NotEnoughMPState : State
{
    InfoBox box;
    public NotEnoughMPState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if(!once)
        {
            box = BattleManager.instance.infoBox;
            Message message = new Message("Not Enough MP\n");
            SkillList List = BattleManager.instance.skillList;
            Character current = BattleManager.instance.turnOrder.currentCharacter;
            int index = current.BattleBuild.basicAttack;
            if ((int)input[3] != -1)
                index = current.BattleBuild.skills[(int)input[3]];
            message.message += List.get(index).mpCost+ " MP needed\n ";
            box.setText(message);
            box.show(0);
            BattleManager.instance.highlightManager.setTargetSelector(null, null);
            BattleManager.instance.boardManager.hidePopUp();
            BattleManager.instance.boardManager.hideSkills();
            once = true;
        }
        if (box.Input != 0)
            box.hide();
        if(box.isActive())
            return id;
        BattleManager.instance.boardManager.updateCharacterText();
        BattleManager.instance.boardManager.showPopUp();
        return StateList.PlayerTurn;
    }
}
