using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isDead;
    [SerializeField] private int healthMax = 100;
    [SerializeField] private float healthSubGap = 3;

    private GameManager gameManager;
    private CharacterEffect effecter;
    private Animator animator;

    private bool isLeak;
    private float timeSum;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        effecter = FindObjectOfType<CharacterEffect>();
        timeSum = 0;
        health = healthMax;
    }

    private void Update()
    {
        CheckIsDead();
        CheckLeakHealth();
    }

    private void FixedUpdate()
    {
        timeSum += Time.fixedDeltaTime;
        if (timeSum >= healthSubGap)
        {
            health -= 1;
            timeSum -= healthSubGap;
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
        if (health > 0)
        {
            this.health = healthMax;
            animator.ResetTrigger("Dead");
            isDead = false;
        }
    }
}
