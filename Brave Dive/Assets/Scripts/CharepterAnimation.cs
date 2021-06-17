using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharepterAnimation : MonoBehaviour
{

    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical")!= 0)
        {
            Anim.SetBool("IsRunning", true);
        }
        else
        {
            Anim.SetBool("IsRunning", false);
        }


    }
}
