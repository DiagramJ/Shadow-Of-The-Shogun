using System;
using System.Collections;

class RunBattleEffectsState :State
{
    public int type;
    public bool attackData;
    public int returnState;
    public RunBattleEffectsState(int ID)
    {
        id = ID;
    }

    public override int run(ArrayList input)
    {
        Character character = BattleManager.instance.turnOrder.currentCharacter;
        if(character != null)
        {
            runEffects(character);
        }
        else
        {
            ArrayList characters = BattleManager.instance.list.List;
            foreach(Character temp in characters)
            {
                runEffects(temp);
            }
        }
        return returnState;
    }
    private void runEffects(Character character)
    {
        ArrayList effectList = character.BattleStats.StatusEffect;
        Equipment[] equipments = character.BattleBuild.equipments;
        foreach (StatusEffect effect in effectList)
        {
            effect.run(character, type);
            if (attackData)
            {
                ArrayList attackList = BattleManager.instance.AttackList;
                foreach (AttackData data in attackList)
                    effect.run(data, type);
            }
        }
        foreach (Equipment equip in equipments)
        {
            if (equip != null)
            {
                equip.run(character, type);
                if (attackData)
                {
                    ArrayList attackList = BattleManager.instance.AttackList;
                    foreach (AttackData data in attackList)
                        equip.run(data, type);
                }
            }
        }
        BattleManager.instance.applyAttackDamage();
        BattleManager.instance.boardManager.updateHealthBars();
    }
}
