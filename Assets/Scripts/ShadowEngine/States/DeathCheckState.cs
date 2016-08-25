using UnityEngine;
using System.Collections;

class DeathCheckState : State
{
    public DeathCheckState(int ID)
    {
        id = ID;
        once = false;
    }

    public override int run(ArrayList input)
    {
        bool wait = false;
        ArrayList list = BattleManager.instance.list.List;
        for (int i = 0; i < list.Count; i++)
        {
            Character character = (Character) list[i];
            if(character.BattleStats.HP == 0)
            {
                if (BattleManager.instance.healthBars[character.position].isMoving())
                    wait = true;
                else
                {
                    BattleManager.instance.turnOrder.remove(character.position);
                    BattleManager.instance.list.remove(character.position);
                    BattleManager.instance.boardManager.displayBord();
                    i--;
                }
            }
        }
        if (wait)
            return id;
        return StateList.EndTurn;
    }
}
