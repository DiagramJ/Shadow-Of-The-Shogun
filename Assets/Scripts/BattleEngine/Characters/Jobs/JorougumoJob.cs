
public class JorougumoJob : Job
{
    public JorougumoJob(int ID)
    {
        name = "Jorougumo";
        id = ID;
        baseStat = new int[] { 70, 60, 50, 115, 100, 95};
        availableSkills = new int[] { SkillList.BasicAttack };
        availableBasicAttacks = new int[] { SkillList.BasicAttack };
        sprite = "Jorougumo";
    }
}

