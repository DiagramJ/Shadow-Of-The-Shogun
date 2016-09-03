using UnityEngine;
using System.Collections;

public class TraitList
{
    public const int SelfBuffAttack = 0;
    public const int GuaranteeCriticalHit = 1;
    public const int SelfHeal = 2;

    ArrayList list;
    public TraitList()
    {
        list = new ArrayList();
        list.Add(new SelfBuffAttackTrait(0));
        list.Add(new GuaranteeCriticalHitTrait(1));
        list.Add(new SelfHealTrait(2));
    }
    public Trait get(int index)
    {
        if (index < 0)
            return null;
        if (index >= list.Count)
            return null;
        return (Trait)list[index];
    }
}