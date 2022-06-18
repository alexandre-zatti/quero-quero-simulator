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
    private Vector2 movement;
    private Vector2 direction;
    private Vector3 spawnPosition;
    private bool runBackToSpawn = false;

    private void Start()
    {
        spawnPosition = transform.position;
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
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bird"))
        {
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
        // GameObject[] spawnLocations = GameObject.FindGameObjectsWithTag("Spawn");
        //
        // GameObject spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
        
        runBackToSpawn = true;
        moveSpeed = 1f;
    }
}
