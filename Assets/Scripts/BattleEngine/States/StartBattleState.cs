﻿using System.Collections;

class StartBattleState : State
{
    public StartBattleState(int ID)
    {
        once = false;
        id = ID;
    }
    public override int run(ArrayList input)
    {
        if (!once)
        {
            BattleManager.instance.infoStrip.add("Battle Start", 60);
            BattleManager.instance.highlightManager.setTargetSelector(null, null);
            BattleManager.instance.boardManager.updateCharacterText();
            once = true;
        }
        if(BattleManager.instance.infoStrip.isActive())
            return id;
        return BattleManager.instance.stateList.changeRunBattleEffectsType(BattleEffect.BattleStart, false, StateList.TurnOrder);
    }
}
