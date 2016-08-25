using System.Collections;
public class SkillList
{
    public const int BasicAttack = 0;
    public const int BasicAllAttackSkill = 1;
    public const int BasicColumnAttackSkill = 2;
    public const int BasicRowAttackSkill = 3;
    public const int BasicHealSkill = 4; 
    public const int BasicCrossAttackSkill = 5;
    public const int BasicRandomAttackSkill = 6;

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
        list.Add(new BasicRandomAttackSkill());
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
