using System.Collections;

class PlayerTurnState : State
{
    int skillInput;
    Character current;
    public PlayerTurnState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        int tempInput = (int)input[3];
        if (!once)
        {
            BattleManager.instance.boardManager.showSkills();
            current = BattleManager.instance.turnOrder.currentCharacter;
            skillInput = -2;
            once = true;
        }
        if(skillInput != tempInput)
        {
            SkillList List = BattleManager.instance.skillList;
            skillInput = tempInput;
            int index = current.BattleBuild.basicAttack;
            if (skillInput != -1)
                index = current.BattleBuild.skills[skillInput];
            BattleManager.instance.highlightManager.setTargetSelector(List.get(index).targets, List.get(index).targetShape);
        }
        if (!(bool)input[0])
            return id;
        return StateList.Attack;
    }
}

