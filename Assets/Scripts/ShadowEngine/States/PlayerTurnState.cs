using System.Collections;

class PlayerTurnState : State
{
    int [] indexes;
    public PlayerTurnState(int ID)
    {
        id = ID;
        once = false;
        indexes = new int [] {9, 10, 11, 12, 13, 14, 15, 16, 17 };
    }
    public override int run(ArrayList input)
    {
        if (!once)
        {
            BattleManager.instance.boardManager.showSkills();
            BattleManager.instance.highlightManager.setTargetSelector(indexes, null);
            once = true;
        }
        if (!(bool)input[0])
            return id;
        return StateTable.Attack;
    }
}

