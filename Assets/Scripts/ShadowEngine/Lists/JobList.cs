using UnityEngine;
using System.Collections;

public class JobList
{
    public const int Shogun = 0;
    public const int Ronin = 1;
    public const int Spearman = 2;
    public const int Archer = 3;
    public const int Monk = 4;
    public const int Oni = 5;
    public const int Chimera = 6;
    public const int Jorougumo = 7;
    public const int Tengu = 8;

    ArrayList list;
    public JobList()
    {
        list = new ArrayList();
        list.Add(new ShogunJob(0));
        list.Add(new RoninJob(1));
        list.Add(new SpearmanJob(2));
        list.Add(new ArcherJob(3));
        list.Add(new MonkJob(4));
        list.Add(new OniJob(5));
        list.Add(new ChimeraJob(6));
        list.Add(new JorougumoJob(7));
        list.Add(new TenguJob(8));

    }
    public Job get(int index)
    {
        if (index < 0)
            return null;
        if (index >= list.Count)
            return null;
        return (Job)list[index];
    }
    
}
