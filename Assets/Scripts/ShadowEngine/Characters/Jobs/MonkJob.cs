public class MonkJob : Job
{
    public MonkJob(int ID)
    {
        name = "Monk";
        id = ID;
        baseStat = new int[] { 65, 70, 55, 110, 100, 78};
        availableSkills = new int[] { SkillList.BasicAttack };
        availableBasicAttacks = new int[] { SkillList.BasicAttack };
        sprite = "Monk";
    }
}

