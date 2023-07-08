using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SocialPlatforms.Impl;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isDead;
    [SerializeField] private int healthMax = 100;
    [SerializeField] private float healthSubGap = 3;
    [SerializeField] private float ClambScore = 1;
    [SerializeField] private float JumpAgainScore = 2;
    [SerializeField] private float RushScore = 3;
    [SerializeField] private int HealthRestore = 20;

    private GameManager gameManager;
    private CharacterEffect effecter;
    private Animator animator;

    private bool isLeak;
    private float timeSum;
    private bool stopHealthSub;
    private int score;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        effecter = FindObjectOfType<CharacterEffect>();
        timeSum = 0;
        health = healthMax;
        stopHealthSub = false;
        score = 0;
    }

    public void AddScore()
    {
        score++;
        health = Math.Min(health + HealthRestore, healthMax);
    }

    public int GetScore()
    {
        return score;
    }

    public bool CanClamb()
    {
        return score >= ClambScore;
    }

    public bool CanJumpAgain()
    {
        return score >= JumpAgainScore;
    }
    public bool CanRush()
    {
        return score >= RushScore;
    }

    public void SetStopHealthSub(bool x)
    {
        stopHealthSub = x;
    }

    private void Update()
    {
        CheckIsDead();
        CheckLeakHealth();
    }

    private void FixedUpdate()
    {
        if (!stopHealthSub && health > 0)
        {
            timeSum += Time.fixedDeltaTime;
            if (timeSum >= healthSubGap)
            {
                health -= 1;
                timeSum -= healthSubGap;
            }
        }
    }

    private void CheckLeakHealth()
    {
        if (health == 1 && !isLeak)
        {
            isLeak = true;
            effecter.DoEffect(CharacterEffect.EffectType.LowHealthLeak, true);
        }
        else if (health != 1 && isLeak)
        {
            isLeak = false;
            effecter.DoEffect(CharacterEffect.EffectType.LowHealthLeak, false);
        }
    }

    private void CheckIsDead()
    {
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void LoseHealth(int health)
    {
        this.health -= health;
    }

    public int GetCurrentHealth()
    {
        return health;
    }

    public bool GetDeadStatement()
    {
        CheckIsDead();
        return isDead;
    }

    public void Die()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Hero Detector"), LayerMask.NameToLayer("Enemy Detector"), true);
        isDead = true;
        animator.SetTrigger("Dead");
    }

    public void Respawn()
    {
        FindObjectOfType<HazardRespawn>().Respawn();
    }

    public void SetRespawnData(int health)
    {
        this.health = healthMax;
        animator.ResetTrigger("Dead");
        isDead = false;
        stopHealthSub = false;
        score = 0;
    }
}
