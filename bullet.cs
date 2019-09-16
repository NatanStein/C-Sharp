using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        if(movepos.r)
        {
            rb.velocity = transform.right * speed;
        }
        else if(movepos.l)
        {
            rb.velocity = -transform.right * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "NoDestroy")
        {
            Destroy(collision);
        }
        Destroy(gameObject,2);
    }

}
