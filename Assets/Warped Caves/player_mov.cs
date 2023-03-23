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
    //for jumping
    bool lado = false;
    bool jump = true;

    //Vida player
    public static int vida;

    //en-tierra
    const float player_size = 0.2f;
    public LayerMask esto_tierra;
    public Transform tierra_verificada;

    //for shooting
    public Transform firePoint;
    public GameObject bulletPrefab;
  
    void Start()
    {

        vida = 100;
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
            
            StartCoroutine(stop_anim(0f,true, 1.1f));
            shoot();
            StartCoroutine(stop_anim(0.8f,false, 0f));
        }

        if(vida < 1){
            Time.timeScale = 0f;
        }
    }

    void shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }

    IEnumerator stop_anim(float t, bool status, float t2){
        yield return new WaitForSeconds(t);
        anim.SetBool("disparando",status);
        yield return new WaitForSeconds(t2);
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

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "enemy"){
            Debug.Log("Entro en el colider");
            vida = vida - 20;
        }
    }
}
