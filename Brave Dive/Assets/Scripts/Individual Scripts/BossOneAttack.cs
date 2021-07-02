using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int damage;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 200.0f;

    public LayerMask PlayerLayer;

    private GameObject Target;

    public float attackDistance; 
    int attack = 0;

    
    void Start()
    {
       Target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        if(Vector2.Distance(Target.transform.position, transform.position) <= attackDistance){
            if (Time.time >= timeBtwAttack){
                if(attack == 0)
                {
                     animator.SetTrigger("attack1");
                     attack = 1;
                     timeBtwAttack = Time.time + 1f / startTimeBtwAttack;
                }
                else if(attack == 1)
                {
                    animator.SetTrigger("attack2");
                    attack = 0;
                    timeBtwAttack = Time.time + 1f / startTimeBtwAttack;
                }
            }
        }
    }
    public void OnEnemyAttack(){
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerLayer);
        foreach (Collider2D Player in hitPlayer){
            Player.GetComponent<playerInteraction>().TakeDamage(damage);
        }
    }
}
