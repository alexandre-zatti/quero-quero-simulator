using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Transform focus;
    public float moveSpeed = 0.4f;
    public Animator animator;
    public EnemyHealthController healthBar;
    public float hitpoints;
    public float maxHitpoints;
    private Vector2 movement;
    private Vector2 direction;
    private Vector3 spawnPosition;
    private bool runBackToSpawn = false;
    private AudioEngine audioEngine;
    
    private void Start()
    {
        hitpoints = maxHitpoints;
        healthBar.setHealth(hitpoints, maxHitpoints);
        spawnPosition = transform.position;
        audioEngine = FindObjectOfType<AudioEngine>();
    }

    private  void FixedUpdate()
    {
        if (runBackToSpawn)
        {
            movement = moveTowards(spawnPosition);
        }
        else
        {
            movement = moveTowards(focus.position);
        }


        if ((Vector3)movement == focus.position || (Vector3)movement == spawnPosition)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = movement;
        }
    }
  
    public void TakeDamage(int damage)
    {
        hitpoints -= damage;
        healthBar.setHealth(hitpoints, maxHitpoints);

            if (hitpoints <= 0)
            {
                audioEngine.Play("correu");       
                runToTheHills();
            }
    }

    private Vector2 moveTowards(Vector3 focus)
    {
        direction = focus - transform.position;
        
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.SqrMagnitude());
        
        return Vector2.MoveTowards( transform.position,
                                    focus,
                                    moveSpeed * Time.fixedDeltaTime);
    }


    private void runToTheHills()
    {
        runBackToSpawn = true;
        moveSpeed = 1f;
    }
}
