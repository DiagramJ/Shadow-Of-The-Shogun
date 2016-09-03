public class TenguJob : Job
{
    public TenguJob(int ID)
    {
        name = "Tengu";
        id = ID;
        baseStat = new int[] { 75, 100, 80, 90, 60, 80};
        availableSkills = new int[] { SkillList.BasicAttack };
        availableBasicAttacks = new int[] { SkillList.BasicAttack };
        sprite = "Tengu";
    }
}
