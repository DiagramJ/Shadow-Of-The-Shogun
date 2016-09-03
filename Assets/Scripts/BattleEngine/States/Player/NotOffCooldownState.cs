using UnityEngine;
using System.Collections;

public class NotOffCooldownState : State
{
    InfoBox box;
    public NotOffCooldownState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if (!once)
        {
            box = BattleManager.instance.infoBox;
            Message message = new Message("Not Off Cooldown\n");
            TraitList List = BattleManager.instance.traitList;
            Character current = BattleManager.instance.turnOrder.currentCharacter;
            if ((int)input[5] != -1)
            {
                int number = current.BattleStats.TraitCooldown[(int)input[5]];
                if (number == 1)
                    message.message += number + " of turn Left\n ";
                else
                    message.message += number + " of turns Left\n ";
            }
            box.setText(message);
            box.show(0);
            BattleManager.instance.highlightManager.setTargetSelector(null, null);
            BattleManager.instance.boardManager.hidePopUp();
            BattleManager.instance.boardManager.hideSkills();
            BattleManager.instance.highlightManager.clearPressButton();
            once = true;
        }
        if (box.Input != 0)
            box.hide();
        if (box.isActive())
            return id;
        BattleManager.instance.boardManager.updateCharacterText();
        BattleManager.instance.boardManager.showPopUp();
        return StateList.PlayerTurn;
    }
}

