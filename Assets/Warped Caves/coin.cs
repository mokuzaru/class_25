using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    
    void OnTriggerEnter2D (Collider2D collider){
        score.puntaje++;
        enemy_life.life--;
        Debug.Log(score.puntaje);
        Destroy(gameObject);
    }

}
