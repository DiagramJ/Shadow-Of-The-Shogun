public class ShogunJob : Job
{
    public ShogunJob(int ID)
    {
        name = "Shogun";
        id = ID;
        baseStat = new int[] { 255, 0, 0, 0, 0, 0};
        availableSkills = new int[] {};
        availableBasicAttacks = new int[] {};
        availableEquipment = new int[] { };
        sprite = "Shogun";
    }
}
