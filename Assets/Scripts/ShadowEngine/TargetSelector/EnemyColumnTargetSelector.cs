public class EnemyColumnTargetSelector : TargetSelector
{
    public EnemyColumnTargetSelector()
    {
        targetable = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        targetShape = new int[targetable.Length][];
        targetShape[0] = new int[] { 9, 12, 15 };
        targetShape[1] = new int[] { 10, 13, 16 };
        targetShape[2] = new int[] { 11, 14, 17 };
        targetShape[3] = new int[] { 9, 12, 15 };
        targetShape[4] = new int[] { 10, 13, 16 };
        targetShape[5] = new int[] { 11, 14, 17 };
        targetShape[6] = new int[] { 9, 12, 15 };
        targetShape[7] = new int[] { 10, 13, 16 };
        targetShape[8] = new int[] { 11, 14, 17 };
    }
}
