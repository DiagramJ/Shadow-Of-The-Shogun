public class SpearmanJob : Job
{
    public SpearmanJob(int ID)
    {
        name = "Spearman";
        id = ID;
        baseStat = new int[] { 85, 95, 100, 90, 90, 70};
        availableSkills = new int[] { SkillList.BasicAttack };
        availableBasicAttacks = new int[] { SkillList.BasicAttack };
        sprite = "Spearman";
    }
}
