public class OniJob : Job
{
    public OniJob(int ID)
    {
        name = "Oni";
        id = ID;
        baseStat = new int[] { 100, 110, 65, 60, 55, 77 };
        availableSkills = new int[] { SkillList.BasicAttack };
        availableBasicAttacks = new int[] { SkillList.BasicAttack };
        sprite = "Oni";
    }
}
