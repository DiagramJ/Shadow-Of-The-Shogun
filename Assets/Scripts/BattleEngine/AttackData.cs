using System;

public class AttackData
{
    public int baseDamage;
    public Character attacker;
    public Character target;
    public bool critical;
    public bool physical;
    public int damage;
    public bool heal;
    public int snapshotAttack;
    public int snapshotLevel;
    public bool miss;
    private double variance;
    private bool flatDamage;

    public AttackData(int Damage, Character Attacker, Character Target, bool Physical, bool Miss)
    {
        baseDamage = Damage;
        attacker = Attacker;
        target = Target;
        physical = Physical;
        heal = false;
        critical = GameManager.instance.random.NextDouble() <= .0625;
        variance = 0.85 + (GameManager.instance.random.NextDouble() * 0.15);
        miss = Miss;
        snapshotAttack = 0;
        snapshotLevel = 0;
        flatDamage = false;
    }
    public AttackData(int Damage, int Attack, int Level, Character Target, bool Physical, bool Miss)
    {
        baseDamage = Damage;
        attacker = null;
        target = Target;
        physical = Physical;
        heal = false;
        critical = GameManager.instance.random.NextDouble() <= .0625;
        variance = 0.85 + (GameManager.instance.random.NextDouble() * 0.15);
        miss = Miss;
        snapshotAttack = Attack;
        snapshotLevel = Level;
        flatDamage = false;
    }
    public AttackData(int Damage, Character Target, bool Miss)
    {
        baseDamage = Damage;
        target = Target;
        miss = Miss;
        flatDamage = true;
    }
    public virtual int calculateDamage()
    {
        if (flatDamage)
            return baseDamage;
        int level = snapshotLevel;
        int attack = snapshotAttack;
        if (attacker != null)
        {
            level = attacker.Level;
            attack = attacker.BattleStats.MagicAttack;
            if (physical)
                attack = attacker.BattleStats.Attack;

        }
        int defence = target.BattleStats.MagicDefence;
        if (physical)
            defence = target.BattleStats.Defence;
        double damage = 0;
        damage = 2 * level;
        damage += 10;
        damage /= 250.0;
        damage *= attack;
        damage /= defence;
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
    public bool FlatDamage
    {
        get { return flatDamage; }
    }
}
