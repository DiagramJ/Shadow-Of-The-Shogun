public class RoninJob : Job
{
    public RoninJob(int ID)
    {
        name = "Ronin";
        id = ID;
        baseStat = new int[] { 80, 125, 90, 55, 80, 90};
        availableSkills = new int[] { SkillList.BasicAttack };
        availableBasicAttacks = new int[] { SkillList.BasicAttack };
        sprite = "Ronin";
    }
}
