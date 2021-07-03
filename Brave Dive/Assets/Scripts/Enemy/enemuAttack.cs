using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemuAttack : MonoBehaviour
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
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnEnemyAttack(){
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerLayer);
        foreach (Collider2D Player in hitPlayer){
            Player.GetComponent<playerInteraction>().TakeDamage(damage);
        }
  
    }
    void Update(){
        if(Vector2.Distance(Target.transform.position, transform.position) <= attackDistance){
            if (Time.time >= timeBtwAttack){
                animator.SetTrigger("isAttack");
                timeBtwAttack = Time.time + 1f / startTimeBtwAttack;
            }
        }
    }
}
