using System.Collections;

class PlayerTurnState : State
{
    int skillInput;
    bool overexert;
    Character current;
    int mpCost;
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
            overexert = tempOverexert;
            BattleManager.instance.boardManager.showSkills();
            BattleManager.instance.boardManager.updateSkillText(overexert);
            current = BattleManager.instance.turnOrder.currentCharacter;
            skillInput = -2;
            mpCost = 0;
            once = true;
        }
        if(skillInput != tempInput || tempOverexert != overexert)
        {
            SkillList List = BattleManager.instance.skillList;
            if (tempOverexert != overexert)
                BattleManager.instance.boardManager.updateSkillText(tempOverexert);
            skillInput = tempInput;
            overexert = tempOverexert;
            int index = current.BattleBuild.basicAttack;
            if (skillInput != -1)
                index = current.BattleBuild.skills[skillInput];
            mpCost = List.get(index).mpCost;
            int[] targets = List.get(index).targets;
            int [][]shape = List.get(index).targetShape;
            if (overexert)
            {
                if (List.get(index).enhancedTargets != null)
                    targets = List.get(index).enhancedTargets;
                if (List.get(index).enhancedTargetShape != null)
                    shape = List.get(index).enhancedTargetShape;
            }
            BattleManager.instance.highlightManager.setTargetSelector(targets, shape);
        }
        if ((int)input[5] == 6)
            return StateList.Guard;
        if ((int)input[5] != -1)
        {
            if(current.BattleStats.TraitCooldown[(int)input[5]] == 0)
            {
                int index = current.BattleBuild.traits[(int)input[5]];
                current.BattleStats.setCooldown(current, BattleManager.instance.traitList.get(index));
                return StateList.PlayerTrait;
            }
            return StateList.NotOffCooldown;
        }
        if (!(bool)input[0])
            return id;
        Character shogun = BattleManager.instance.list.Shogun;
        if (shogun.BattleStats.HP >= mpCost)
        {
            BattleManager.instance.AddAttack(new AttackData(mpCost, shogun, false));
            return StateList.Attack;
        }
        return StateList.NotEnoughMP;
        
    }
}

