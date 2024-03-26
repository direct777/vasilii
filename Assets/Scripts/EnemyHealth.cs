﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;
    public Explosion explosionPrefab;
    public void DealDamage(float damage)
    {
        value -= damage;
        Debug.Log("damage value=" + value);
        if (value <= 0)
        {
            //Destroy(gameObject);
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    private void EnemyDeath()
    {
        Debug.Log("EnemyDeath");
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        MobExplosion();
    }
    private void MobExplosion()
    {
        if (explosionPrefab == null) return;
        var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosion.transform.position = transform.position;
    }
    public bool IsAlive()
    {
        return value > 0;
    }

}
