using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int damage;
    public Animator animator;
    private playerInteraction player;  
    int attack = 0;

    
    void Start()
    {
        player = FindObjectOfType<playerInteraction>();
        
    }

    public void OnTriggerStay2D(Collider2D other){

        if(other.CompareTag("Player")){
            if(timeBtwAttack <=0){
                if(attack == 0)
                {
                     animator.SetTrigger("attack1");
                     attack = 1;
                }
                if(attack == 1)
                {
                    animator.SetTrigger("attack2");
                    attack = 0;
                }
                
            }else{
                timeBtwAttack -= Time.deltaTime; 
            }
        }
    }
    public void OnEnemyAttack(){
        player.currentHealth -= damage;
        timeBtwAttack = startTimeBtwAttack; 
    }
}
