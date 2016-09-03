
public class BattleBuild
{
    public int[] skills;
    public int[] traits;
    public int basicAttack;
    public Equipment[] equipments;
    public BattleBuild()
    {
        skills = new int[6];
        traits = new int[6];
        equipments = new Equipment[3];
    }
    public Equipment equip(int index,Equipment newEquipment)
    {
        Equipment hold = equipments[index];
        equipments[index] = newEquipment;
        return hold;
    }
    public void setSkill(int index, int skillID)
    {
        skills[index] = skillID;
    }
    public void setBasicAttack(int skillID)
    {
        basicAttack = skillID;
    }
    public void setTraits(int index, int traitID)
    {
        traits[index] = traitID;
    }
}
