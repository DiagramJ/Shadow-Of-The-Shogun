using System.Collections;

class EndTurnState : State
{
    public EndTurnState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if (!once)
        {
            Character character = BattleManager.instance.turnOrder.currentCharacter;
            if(character != null)
            {
                ArrayList effectList = character.BattleStats.StatusEffect;
                for (int i = 0; i < effectList.Count; i++)
                {
                    if (((StatusEffect)effectList[i]).endTurn(character))
                    {
                        effectList.RemoveAt(i);
                        i--;
                    }

                }
            }
            BattleManager.instance.boardManager.updateCharacterText();
            BattleManager.instance.turnOrder.nextTurn();
            BattleManager.instance.highlightManager.clearTargetsHighlight();
            once = true;
        }
        if (BattleManager.instance.infoStrip.isActive())
            return id;
        if (BattleManager.instance.turnOrder.currentCharacter == null)
            return StateList.TurnOrder;
        return StateList.StartTurn;
    }
}