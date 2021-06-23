using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 200.0f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttack = 0f; 




    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetMouseButton(0))
            {
                nextAttack = Time.time + 1f / attackRate;
                Attack();
            }
        }
        
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        foreach(Collider2D enemy in hitEnemies)
        {
            
            enemy.GetComponent<enemyInteraction>().takeDamage(50f);
            
        }
    }
}
