using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public enum CreatureType
{
    Player,
    Mob
}

public abstract class Sc_Creature : MonoBehaviour
{
    public HealthBar healthBar;
    public Statistic GetID => allPoints[StatType.ID];
    public Statistic GetLife => allPoints[StatType.HP];
    public Statistic GetMana => allPoints[StatType.MP];
    public Statistic GetAttack => allPoints[StatType.Attack];
    public Statistic GetDefense => allPoints[StatType.Defense];
    public Statistic GetSkill => allPoints[StatType.Skill];

    public Profile profile;
    [SerializeField] protected float animSpeed = 0.4f;
    [SerializeField] protected Statistic[] myPoints = new Statistic[6];
    protected Dictionary<StatType, Statistic> allPoints = new Dictionary<StatType, Statistic>();
    public bool isDead;
    private Animator anim;
    protected Vector3 initPos;

    public virtual void Awake()
    {
        GameObject newSprite = Instantiate(profile.visualObject, transform.position, transform.rotation, transform);
        anim = newSprite.GetComponent<Animator>();
        initPos = transform.position;
        foreach (var item in myPoints)
        {
            if (!allPoints.ContainsKey(item.myStat))
            {
                allPoints.Add(item.myStat, item);
            }
        }
        GetLife.Initialise();
    }

    public Statistic GetState(StatType statName)
    {
        return allPoints[statName];
    }

    public virtual void StartAttack(Sc_Creature target, float attackDamage)
    {
        StartCoroutine( Attack( target, attackDamage ) );
    }

    private IEnumerator Attack(Sc_Creature target, float attackDamage )
    {
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.1f);

        float calculateDamage = attackDamage;
        if (calculateDamage > 0)
        {
            target.ModifyHealth(-calculateDamage);
            target.transform.DOShakePosition(0.1f, 0.8f);

            target.gameObject.GetComponent<EnemyStat>( ).ModifyHealth( -calculateDamage );
        }
        else
        {
            target.transform.DOShakePosition(0.1f, 0.15f);
        }
        Sc_EventManager.instance.onUpdateStats.Invoke();
        yield return new WaitForSeconds(1);
        transform.DOMoveX(initPos.x, animSpeed);
    }

    private void ModifyHealth(float value)
    {
        GetLife.ModifyValue(value);

        if (GetLife.Value <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        
        
        isDead = true;
        anim.SetBool("isDead", isDead);
    }
}