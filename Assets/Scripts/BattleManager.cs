using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance = null;

    public Box [] buttons;
    public Box[] targets;
    public HealthBar [] healthBars;
    public CharacterList list;
    public TurnOrder turnOrder;
    public InfoStrip infoStrip;
    public BoardManager boardManager;
    public HighlightManager highlightManager;
    public SpriteList characterSprite;
    public SpriteList highlightSprite;
    public GameObject flyingText;
    public ArrayList AttackList;
    public SkillList skillList;
    public JobList jobs;
    StateMachine machine;

    bool once;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start ()
    {
        AttackList = new ArrayList();
        machine = new StateMachine();
        list = new CharacterList();
        turnOrder = new TurnOrder();
        skillList = new SkillList();
        jobs = new JobList();
        highlightManager = new HighlightManager(buttons, targets);
        boardManager = new BoardManager(buttons, targets, healthBars);
        once = false;

        TargetSelector temp = new EnemyRowTargetSelector();
        highlightManager.setTargetSelector(temp.targetable, temp.targetShape);
    }
	
	void Update ()
    {
        if(!once)
        {
            temp();

            boardManager.placeSprites();
            boardManager.displayBord();
            boardManager.displaySkills();
            boardManager.setHealthBars();

            once = true;
        }
        highlightManager.runSkillSelect();
        highlightManager.highlightTurnCharacter();
        highlightManager.runOverexertSelect();
        highlightManager.runHighlightTarget();
        machine.run(highlightManager.getInputs());
    }

    public void setSkills(Character c)
    {
        c.BattleBuild.setBasicAttack(SkillList.BasicAttack);
        c.BattleBuild.setSkill(0, SkillList.BasicAllAttackSkill);
        c.BattleBuild.setSkill(1, SkillList.BasicCrossAttackSkill);
        c.BattleBuild.setSkill(2, SkillList.BasicRowAttackSkill);
        c.BattleBuild.setSkill(3, SkillList.BasicColumnAttackSkill);
        c.BattleBuild.setSkill(4, SkillList.BasicHealSkill);
        c.BattleBuild.setSkill(5, SkillList.BasicRandomAttackSkill);
    }

    public void Order()
    {
        turnOrder.Order(list.List);
    }

    public FlyingText makeText(int index)
    {
        GameObject temp = Instantiate(flyingText, targets[index].position(), Quaternion.identity) as GameObject;
        temp.GetComponent<FlyingText>().instantiate();
        return temp.GetComponent<FlyingText>();
    }
    public void AddAttack(AttackData data)
    {
        AttackList.Add(data);
    }
    public void applyAttackDamage()
    {
        foreach(AttackData data in AttackList)
        {
            data.applyDamage();
            FlyingText temp = makeText(data.target.position);
            if (data.critical)
            {
                temp.setText("" + data.calculateDamage() + "!");
                temp.setFont(FontStyle.Bold);
                temp.setColor(new Color(1, 1, 0));
            }
            else
                temp.setText(""+data.calculateDamage());
            if(data.heal)
                temp.setColor(new Color(1, 0.714f, 0.757f));
        }
        AttackList.Clear();
    }







    public void temp()
    {
        Character Archer1 = new Character("", jobs.get(JobList.Archer));
        Character Archer2 = new Character("", jobs.get(JobList.Archer));
        Character Ronin1 = new Character("", jobs.get(JobList.Ronin));
        Character Ronin2 = new Character("", jobs.get(JobList.Ronin));
        Character Spearman1 = new Character("", jobs.get(JobList.Spearman));
        Character Spearman2 = new Character("", jobs.get(JobList.Spearman));
        Character Monk1 = new Character("", jobs.get(JobList.Monk));
        Character Monk2 = new Character("", jobs.get(JobList.Monk));
        Character Shogun = new Character("", jobs.get(JobList.Shogun));

        setSkills(Archer1);
        setSkills(Archer2);
        setSkills(Ronin1);
        setSkills(Ronin2);
        setSkills(Spearman1);
        setSkills(Spearman2);
        setSkills(Monk1);
        setSkills(Monk2);
        setSkills(Shogun);

        list.addPlayerParty(0, Archer1);
        list.addPlayerParty(1, Ronin1);
        list.addPlayerParty(2, Spearman1);
        list.addPlayerParty(3, Shogun);
        list.addPlayerParty(4, Monk1);
        list.addPlayerParty(5, Monk2);
        list.addPlayerParty(6, Archer2);
        list.addPlayerParty(7, Ronin2);
        list.addPlayerParty(8, Spearman2);

        Character Oni1 = new Character("", jobs.get(JobList.Oni));
        Character Oni2 = new Character("", jobs.get(JobList.Oni));
        Character Chimera1 = new Character("", jobs.get(JobList.Chimera));
        Character Chimera2 = new Character("", jobs.get(JobList.Chimera));
        Character Jorogumo1 = new Character("", jobs.get(JobList.Jorougumo));
        Character Jorogumo2 = new Character("", jobs.get(JobList.Jorougumo));
        Character Tengu1 = new Character("", jobs.get(JobList.Tengu));
        Character Tengu2 = new Character("", jobs.get(JobList.Tengu));
        Character enemyShogun = new Character("", jobs.get(JobList.Shogun));

        setSkills(Oni1);
        setSkills(Oni2);
        setSkills(Chimera1);
        setSkills(Chimera2);
        setSkills(Jorogumo1);
        setSkills(Jorogumo2);
        setSkills(Tengu1);
        setSkills(Tengu2);
        setSkills(enemyShogun);

        Oni1.addLoyalty(-50);
        Oni2.addLoyalty(-50);
        Chimera1.addLoyalty(-50);
        Chimera2.addLoyalty(-50);
        Jorogumo1.addLoyalty(-50);
        Jorogumo2.addLoyalty(-50);
        Tengu1.addLoyalty(-50);
        Tengu2.addLoyalty(-50);
        enemyShogun.addLoyalty(-50);

        list.addEnemyParty(0, Chimera1);
        list.addEnemyParty(1, Tengu1);
        list.addEnemyParty(2, Jorogumo1);
        list.addEnemyParty(3, Oni1);
        list.addEnemyParty(4, Oni2);
        list.addEnemyParty(5, enemyShogun);
        list.addEnemyParty(6, Chimera2);
        list.addEnemyParty(7, Tengu2);
        list.addEnemyParty(8, Jorogumo2);

        for (int i = 0; i < 100; i++)
        {
            Archer1.levelUp();
            Archer2.levelUp();
            Ronin1.levelUp();
            Ronin2.levelUp();
            Spearman1.levelUp();
            Spearman2.levelUp();
            Monk1.levelUp();
            Monk2.levelUp();
            Shogun.levelUp();
            Oni1.levelUp();
            Oni2.levelUp();
            Chimera1.levelUp();
            Chimera2.levelUp();
            Jorogumo1.levelUp();
            Jorogumo2.levelUp();
            Tengu1.levelUp();
            Tengu2.levelUp();
            enemyShogun.levelUp();
        }
    }

}
