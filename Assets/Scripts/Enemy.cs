using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform nest;
    public float moveSpeed = 1f;
    public Animator animator;
    private Vector2 movement;
    private Vector2 direction;
    

    void Start()
    {
    }


    void Update()
    {
        direction = nest.position - transform.position;
        
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.SqrMagnitude());
        
    }

    void FixedUpdate()
    {
        movement = Vector2.MoveTowards( transform.position,
            nest.position,
            moveSpeed * Time.fixedDeltaTime);
        
        transform.position = movement;
    }
}
