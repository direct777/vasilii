﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamageEvent : MonoBehaviour
{
    public EnemyAI enemyAI;
    public void AttackDamageEvent()
    {
        Debug.Log("AttackDamageEvent");
        //var enemyAI = GetComponentInParent<EnemyAI>();
        //enemyAI.AttackUpdate();

        enemyAI.AttackDamage();
    }
}