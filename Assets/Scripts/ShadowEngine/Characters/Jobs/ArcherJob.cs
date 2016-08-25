public class ArcherJob : Job
{
    public ArcherJob(int ID)
    {
        name = "Archer";
        id = ID;
        baseStat = new int[] { 65, 80, 60, 60, 125, 95, 100};
        availableSkills = new int[] { SkillList.BasicAttack };
        availableBasicAttacks = new int[] { SkillList.BasicAttack };
        sprite = "Archer";
    }
}

