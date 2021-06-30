using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int damage;
    private playerInteraction player;  
    void Start()
    {
        player = FindObjectOfType<playerInteraction>();
        
    }

    public void OnTriggerStay2D(Collider2D other){

        if(other.CompareTag("Player")){
            if(timeBtwAttack <=0){
                
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
