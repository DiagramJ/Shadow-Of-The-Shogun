using System.Collections;

class StartTurnState : State
{
    public StartTurnState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if(!once)
        {
            BattleManager.instance.boardManager.showPopUp();
            BattleManager.instance.boardManager.updateCharacterText();

            Character current = BattleManager.instance.turnOrder.currentCharacter;
            current.BattleStats.turnStart();
        }
        if (BattleManager.instance.turnOrder.currentCharacter.Enemy)
            return BattleManager.instance.stateList.changeRunBattleEffectsType(BattleEffect.TurnStart,false,StateList.ComputerTurn);
        return BattleManager.instance.stateList.changeRunBattleEffectsType(BattleEffect.TurnStart, false, StateList.PlayerTurn);
    }
}

