﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public Animator animator;
    private float _maxValue;
    
    public bool IsAlive()
    {
        return value > 0;
    }

    public void DealDamage(float damage)
    {
        value -= damage;
        Debug.Log("damage value=" + value);
        if (value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }
    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        gameOverScreen.GetComponent<Animator>().SetTrigger("show");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("finish");
    }
    // Start is called before the first frame update
    void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawHealthBar()
    {
        //if (Time.timeSinceLevelLoad > 5)
        {
            valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
        }
    }
    public void AddHealth(float amount)
    {
        value += amount;
        /*if (value > _maxValue)
        {
            value = _maxValue;
        }*/
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawHealthBar();
    }
}
