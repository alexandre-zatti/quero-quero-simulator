using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private float timeSinceGrito = 0.0f;

    public AudioSource audioGrito;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;

    public float gritoCooldown;

    // Update is called once per frame
    void Update()
    {
        timeSinceGrito += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode. Space) && timeSinceGrito > gritoCooldown) {
            
            if(!audioGrito.isPlaying) {
                audioGrito.Play();
            }
            timeSinceGrito = 0;
            Attack();
        }
        
        
    }

    void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
           
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    
}
