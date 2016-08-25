using System;

public class AttackData
{
    public int baseDamage;
    public Character attacker;
    public Character target;
    public bool critical;
    public bool hit;
    public bool physical;
    public int damage;
    public bool heal;
    private double variance;

    public AttackData(int Damage, Character Attacker, Character Target, bool Physical, int Accuracy)
    {
        baseDamage = Damage;
        attacker = Attacker;
        target = Target;
        physical = Physical;
        heal = false;
        critical = GameManager.instance.random.NextDouble() <= .0625;
        hit = GameManager.instance.random.NextDouble() <= Accuracy / 100.0;
        variance = 0.85 + (GameManager.instance.random.NextDouble() * 0.15);
    }
    public int calculateDamage()
    {
        double damage = 0;
        damage = 2 * attacker.Level;
        damage += 10;
        damage /= 250.0;
        if(physical)
        {
            damage *= attacker.BattleStats.Attack;
            damage /= target.BattleStats.Defence;
        }
        else
        {
            damage *= attacker.BattleStats.MagicAttack;
            damage /= target.BattleStats.MagicDefence;
        }
        damage *= baseDamage;
        damage += 2;
        if (critical)
            damage *= 1.5;
        damage *= variance;
        return (int)damage;
    }

    public void applyDamage()
    {
        if(heal)
            target.BattleStats.damage(-calculateDamage());
        else
            target.BattleStats.damage(calculateDamage());
    }
}
