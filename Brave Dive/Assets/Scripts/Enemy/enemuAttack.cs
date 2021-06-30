using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemuAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int damage;
    public Animator animator;
    private playerInteraction player;  
    void Start()
    {
        player = FindObjectOfType<playerInteraction>();
        
    }

    public void OnTriggerStay2D(Collider2D other){

        if(other.CompareTag("Player")){
            if(timeBtwAttack <=0){
                animator.SetTrigger("isAttack");
                
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
