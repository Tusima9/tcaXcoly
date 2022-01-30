using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sc_Enemy : Sc_Creature
{
    [SerializeField]
    public int TurnLeftBeforeAction;

    private EnemyProfile myProfile => profile as EnemyProfile;

    public override void Awake()
    {
        base.Awake();
        for (int i = 1; i < myProfile.statspoints + 1; i++)
        {
            int random = Random.Range((int)StatType.Attack, (int)StatType.Defense + 1);
            myPoints[random].Value++;
        }
    }

    public override void StartAttack(Sc_Creature target, float attackDamage)
    {
        transform.DOMoveX(initPos.x - 1, animSpeed);
        base.StartAttack(target, attackDamage );
    }

    public override void Death()
    {
        base.Death();
    }
}