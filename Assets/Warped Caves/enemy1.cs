using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public static int enemyLive = 100;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.name == "player"){
            anim.SetBool("saltar", true);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.name == "player"){
            anim.SetBool("saltar",false);
        }
    }
}
