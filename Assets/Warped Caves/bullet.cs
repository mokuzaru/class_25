using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 40;
    public Rigidbody2D rb;
    //public GameObject impacEffct;

    void Start()
    {
        rb.velocity = transform.right * speed;    
    }

    void OnTriggerEnter2D (Collider2D hitInfo){
        //Instantiate(impacEffct, transform.position, transform.rotation);
        Destroy (gameObject);
    }

    void Update()
    {
        Destroy (gameObject, 5.0f);
    }
}
