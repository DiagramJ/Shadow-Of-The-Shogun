using UnityEngine;
using System.Collections;

public class StatusEffectList 
{
    public const int DamageOverTime = 0;
    public const int AttackBuff = 1;
    public const int Sprint = 2;
    public const int SprintDrawback = 3;
    public const int GuaranteeCriticalHit = 4;
    public StatusEffect get(int type, Character attacker)
    {
        switch(type)
        {
            case 0:
                return new DamageOverTimeStatusEffect(attacker);
            case 1:
                return new AttackBuffStatusEffect(attacker);
            case 2:
                return new SprintStatusEffect(attacker);
            case 3:
                return new SprintDrawbackStatusEffect(attacker);
            case 4:
                return new GuaranteeCriticalHitStatusEffect(attacker);
            default:
                return null;
        }
    }

}
