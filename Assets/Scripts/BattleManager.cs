using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance = null;

    public Box [] buttons;
    public Box [] targets;
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
    public TraitList traitList;
    public JobList jobs;
    public LoyaltyManager loyaltyManager;
    public StatusEffectList statusEffectList;
    public InfoBox infoBox;
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
        traitList = new TraitList();
        jobs = new JobList();
        statusEffectList = new StatusEffectList();
        loyaltyManager = new LoyaltyManager();
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
            buttons[6].setText(new Message("Overexert"));
            buttons[13].setText(new Message("Guard"));
            infoBox.hide();
            boardManager.placeSprites();
            boardManager.displayBord();
            boardManager.displaySkills();
            boardManager.setHealthBars();
            once = true;
        }
        highlightManager.runSkillSelect();
        highlightManager.highlightTurnCharacter();
        highlightManager.runOverexertSelect();
        highlightManager.runPressButton();
        highlightManager.runHighlightTarget();
        machine.run(highlightManager.getInputs());
    }

    public void Order()
    {
        turnOrder.Order(list.List);
    }

    public FlyingText makeText(int index, int delay)
    {
        GameObject temp = Instantiate(flyingText, targets[index].position(), Quaternion.identity) as GameObject;
        temp.GetComponent<FlyingText>().instantiate(delay);
        return temp.GetComponent<FlyingText>();
    }
    public void AddAttack(AttackData data)
    {
        AttackList.Add(data);
    }
    public void applyAttackDamage()
    {
        int[] delay = new int[targets.Length];

        foreach(AttackData data in AttackList)
        {
            FlyingText temp = makeText(data.target.position, delay[data.target.position]);
            if (data.miss)
            {
                temp.setText("miss");
                temp.setFont(FontStyle.Bold);
            }
            else if(data.FlatDamage)
            {
                data.applyDamage();
                temp.setText("" + data.calculateDamage());
                if (data.heal)
                    temp.setColor(new Color(1, 0.714f, 0.757f));
            }
            else
            {
                data.applyDamage();
                if (data.critical)
                {
                    temp.setText("" + data.calculateDamage() + "!");
                    temp.setFont(FontStyle.Bold);
                    temp.setColor(new Color(1, 1, 0));
                }
                else
                    temp.setText("" + data.calculateDamage());
                if (data.heal)
                    temp.setColor(new Color(1, 0.714f, 0.757f));
            }
            delay[data.target.position] += 10;
        }
        AttackList.Clear();
    }
    public bool hit(int accuracy)
    {
        return GameManager.instance.random.NextDouble() > accuracy / 100.0;
    }







    public void temp()
    {
        Character Archer1 = new Character("Archer1", jobs.get(JobList.Archer), 0);
        Character Archer2 = new Character("Archer2", jobs.get(JobList.Archer), 1);
        Character Ronin1 = new Character("Ronin1", jobs.get(JobList.Ronin), 2);
        Character Ronin2 = new Character("Ronin2", jobs.get(JobList.Ronin), 3);
        Character Spearman1 = new Character("Spearman1", jobs.get(JobList.Spearman), 4);
        Character Spearman2 = new Character("Spearman2", jobs.get(JobList.Spearman), 5);
        Character Monk1 = new Character("Monk1", jobs.get(JobList.Monk), 6);
        Character Monk2 = new Character("Monk2", jobs.get(JobList.Monk), 7);
        Character Shogun = new Character("Shogun", jobs.get(JobList.Shogun), 8);

        setSkills(Archer1);
        setSkills(Archer2);
        setSkills(Ronin1);
        Ronin1.BattleBuild.equip(1, new FastStartEquipment());
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


        Shogun.BattleBuild.setSkill(0, SkillList.Betray);
        Shogun.BattleBuild.setSkill(1, SkillList.Recruit);

        Character Oni1 = new Character("Oni1", jobs.get(JobList.Oni), 9);
        Character Oni2 = new Character("Oni2", jobs.get(JobList.Oni), 10);
        Character Chimera1 = new Character("Chimera1", jobs.get(JobList.Chimera), 11);
        Character Chimera2 = new Character("Chimera2", jobs.get(JobList.Chimera), 12);
        Character Jorogumo1 = new Character("Jorogumo1", jobs.get(JobList.Jorougumo), 13);
        Character Jorogumo2 = new Character("Jorogumo2", jobs.get(JobList.Jorougumo), 14);
        Character Tengu1 = new Character("Tengu1", jobs.get(JobList.Tengu), 15);
        Character Tengu2 = new Character("Tengu2", jobs.get(JobList.Tengu), 16);
        Character enemyShogun = new Character("enemyShogun", jobs.get(JobList.Shogun), 17);

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
    
    public void setSkills(Character c)
    {
        c.BattleBuild.setBasicAttack(SkillList.BasicAttack);
        c.BattleBuild.setSkill(0, SkillList.BasicAllAttack);
        c.BattleBuild.setSkill(1, SkillList.BasicCrossAttack);
        c.BattleBuild.setSkill(2, SkillList.BasicRowAttack);
        c.BattleBuild.setSkill(3, SkillList.BasicColumnAttack);
        c.BattleBuild.setSkill(4, SkillList.BasicHeal);
        c.BattleBuild.setSkill(5, SkillList.BasicDamageOverTime);

        c.BattleBuild.setTraits(0, TraitList.SelfBuffAttack);
        c.BattleBuild.setTraits(1, TraitList.GuaranteeCriticalHit);
        c.BattleBuild.setTraits(2, TraitList.SelfHeal);
        c.BattleBuild.setTraits(3, TraitList.SelfBuffAttack);
        c.BattleBuild.setTraits(4, TraitList.SelfBuffAttack);
        c.BattleBuild.setTraits(5, TraitList.SelfBuffAttack);
    }
    public StateList stateList
    {
        get { return machine.stateList; }
    }
}
