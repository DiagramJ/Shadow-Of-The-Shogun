using UnityEngine;
using System.Collections;

public class GuardState : State
{
    public GuardState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if (!once)
        {
            BattleManager.instance.infoStrip.add("Guard ", 60);
            BattleManager.instance.highlightManager.setTargetSelector(null, null);
            BattleManager.instance.highlightManager.clearSkillSelected();
            BattleManager.instance.boardManager.hidePopUp();
            BattleManager.instance.boardManager.hideSkills();
            BattleManager.instance.highlightManager.clearPressButton();
            once = true; 
        }
        if (BattleManager.instance.infoStrip.isActive())
            return id;
       return BattleManager.instance.stateList.changeRunBattleEffectsType(BattleEffect.AfterGuard, false, StateList.DeathCheck);
    }
}

