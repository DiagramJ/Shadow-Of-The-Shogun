using System.Collections;
public class SkillList
{
    public const int BasicAttack = 0;
    public const int BasicAllAttack = 1;
    public const int BasicColumnAttack = 2;
    public const int BasicRowAttack = 3;
    public const int BasicHeal = 4; 
    public const int BasicCrossAttack = 5;
    public const int BasicDamageOverTime = 6;
    public const int Betray = 7;
    public const int Recruit = 8;

    ArrayList list;
    public SkillList()
    {
        list = new ArrayList();
        list.Add(new BasicAttackSkill());
        list.Add(new BasicAllAttackSkill());
        list.Add(new BasicColumnAttackSkill());
        list.Add(new BasicRowAttackSkill());
        list.Add(new BasicHealSkill());
        list.Add(new BasicCrossAttackSkill());
        list.Add(new BasicDamageOverTimeSkill());
        list.Add(new BetraySkill());
        list.Add(new RecruitSkill());
    }
    public Skill get(int index)
    {
        if (index < 0)
            return null;
        if (index >= list.Count)
            return null;
        return (Skill)list[index];
    }
}
