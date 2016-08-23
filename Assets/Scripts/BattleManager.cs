﻿using UnityEngine;
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
            Job SJ = new ShogunJob();
            Job RJ = new RoninJob();
            Job AJ = new ArcherJob();
            Job MJ = new MonkJob();
            Job SpJ = new SpearmanJob();
            Job CJ = new ChimeraJob();
            Job OJ = new OniJob();
            Job JJ = new JorougumoJob();
            Job TJ = new TenguJob();
            list.addPlayerParty(0, new Character("", AJ));
            list.addPlayerParty(1, new Character("", RJ));
            list.addPlayerParty(2, new Character("", SpJ));
            list.addPlayerParty(3, new Character("", SJ));
            list.addPlayerParty(4, new Character("", MJ));
            list.addPlayerParty(5, new Character("", MJ));
            list.addPlayerParty(6, new Character("", AJ));
            list.addPlayerParty(7, new Character("", RJ));
            list.addPlayerParty(8, new Character("", SpJ));


            list.addEnemyParty(0, new Character("", CJ));
            list.addEnemyParty(1, new Character("", TJ));
            list.addEnemyParty(2, new Character("", JJ));
            list.addEnemyParty(3, new Character("", OJ));
            list.addEnemyParty(4, new Character("", OJ));
            list.addEnemyParty(5, new Character("", SJ));
            list.addEnemyParty(6, new Character("", CJ));
            list.addEnemyParty(7, new Character("", TJ));
            list.addEnemyParty(8, new Character("", JJ));

            list.temp();

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
            if(data.critical)
            {
                FlyingText temp = makeText(data.target.position);
                temp.setText("" + data.calculateDamage() + "!");
                temp.critical();
            }
            else
                makeText(data.target.position).setText(""+data.calculateDamage());
        }
        AttackList.Clear();
    }
}
