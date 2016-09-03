using UnityEngine;
using System.Collections;

public class PostPlayerTraitState : State
{
    public PostPlayerTraitState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if (!once)
        {
            BattleManager.instance.applyAttackDamage();
            BattleManager.instance.boardManager.updateHealthBars();
            BattleManager.instance.infoStrip.add("Trait used", 60);
            once = true;
        }
        if (BattleManager.instance.infoStrip.isActive())
            return id;

        BattleManager.instance.boardManager.updateCharacterText();
        BattleManager.instance.boardManager.showPopUp();
        return StateList.PlayerTurn;
    }
}