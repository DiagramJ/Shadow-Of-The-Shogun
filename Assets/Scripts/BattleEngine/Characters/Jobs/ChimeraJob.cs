public class ChimeraJob : Job
{
    public ChimeraJob(int ID)
    {
        name = "Chimera";
        id = ID;
        baseStat = new int[] { 120, 135, 70, 90, 70, 75 };
        availableSkills = new int[] { SkillList.BasicAttack };
        availableBasicAttacks = new int[] { SkillList.BasicAttack };
        sprite = "Chimera";
    }
}
