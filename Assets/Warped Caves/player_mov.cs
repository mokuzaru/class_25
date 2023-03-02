using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mov : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float h;
    public float vel;
    private Animator anim;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        //int a = Convert.ToInt32(h);
        anim.SetFloat("run",h);
        rigid.MovePosition(rigid.position + new Vector2(h,0) * vel * Time.deltaTime);
    }
}
