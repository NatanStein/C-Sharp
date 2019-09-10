using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScBala : MonoBehaviour
{
    public Rigidbody2D rd2d;
    public float v;
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        rd2d.velocity = transform.right * v;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "NoDestroy")
        {
            Destroy(collision.transform.gameObject);
            Destroy(gameObject);
        }
    }
}

