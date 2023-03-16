using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mov : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float h;
    public float vel;
    public float j_force;
    private Animator anim;
    //for shoting
    bool lado = false;
    bool jump = true;

    //en-tierra
    const float player_size = 0.2f;
    public LayerMask esto_tierra;
    public Transform tierra_verificada;

    //for shooting
    public Transform firePoint;
    public GameObject bulletPrefab;
  
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        if(h < 0 && !lado){
            lado = !lado;
            transform.Rotate(0f,180f,0f);
        }else if (h > 0 && lado){
            lado = !lado;
            transform.Rotate(0f,180f,0f);
        }
        
        anim.SetFloat("run",h);
        rigid.MovePosition(rigid.position + new Vector2(h,0) * vel * Time.deltaTime);
        esta_en_tierra();
        if(Input.GetButton("Jump") && !jump){
            jump = true;
            anim.SetBool("EstaSaltando", true);
            rigid.AddForce(new Vector2(0f, j_force));
        }
        if(Input.GetButtonDown("Fire1")){
            anim.SetBool("disparando",true);
            
            shoot();
            StartCoroutine(stop_anim());
        }
    }

    void shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }

    IEnumerator stop_anim(){
        Debug.Log("estamos en la coroutine");
        yield return new WaitForSeconds(.8f);
        anim.SetBool("disparando",false);
    }

    void esta_en_tierra(){

        Collider2D[] colliders = Physics2D.OverlapCircleAll(tierra_verificada.position, player_size,esto_tierra);
        for(int i = 0; i < colliders.Length; i++){
            if(colliders[i].gameObject != gameObject){
                jump = false;
                anim.SetBool("EstaSaltando",false);
            }
        }
        
    }
}
