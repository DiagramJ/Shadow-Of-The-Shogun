using System;
using System.Collections;

class RunBattleEffectsState :State
{
    public RunBattleEffectsState(int ID)
    {
        id = ID;
    }

    public override int run(ArrayList input)
    {
        return id;
    }
}
