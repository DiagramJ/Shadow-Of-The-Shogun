using System.Collections;

class PlayerTurnState : State
{
    int skillInput;
    bool overexert;
    Character current;
    public PlayerTurnState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        int tempInput = (int)input[3];
        bool tempOverexert = (bool)input[4];
        if (!once)
        {
            BattleManager.instance.boardManager.showSkills();
            BattleManager.instance.boardManager.updateSkillText();
            current = BattleManager.instance.turnOrder.currentCharacter;
            skillInput = -2;
            overexert = tempOverexert;
            once = true;
        }
        if(skillInput != tempInput || tempOverexert != overexert)
        {
            SkillList List = BattleManager.instance.skillList;
            skillInput = tempInput;
            overexert = tempOverexert;
            int index = current.BattleBuild.basicAttack;
            if (skillInput != -1)
                index = current.BattleBuild.skills[skillInput];
            int [][]shape = List.get(index).targetShape;
            if (overexert && List.get(index).enhancedTargetShape != null)
                shape = List.get(index).enhancedTargetShape;
            BattleManager.instance.highlightManager.setTargetSelector(List.get(index).targets, shape);
        }
        if (!(bool)input[0])
            return id;
        return StateList.Attack;
    }
}

