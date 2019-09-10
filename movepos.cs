using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepos : MonoBehaviour
{
    public float velocidade,fpulo;
    public Rigidbody2D rd2d;
    public bool noChao;
    public GameObject bala;
    public Transform arma;
    public int contAmmo;
    Collider2D myCollider;


    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        myCollider = GetComponent < Collider2D >();
        noChao = false;
        contAmmo = 10;

    }
    void Update()
    {
        if(Confgeral.pause)
        {
            return;
        }
        float velocidadeAtual = velocidade;
        myCollider.enabled = false;
        if (Physics2D.Raycast(transform.position,Vector3.down,1.5f))
        {
            noChao = true;
        }
        else
        {
            noChao = false;
        }
        myCollider.enabled = true;
        if (Input.GetKey("a"))
        {
            rd2d.AddForce(Vector2.left * velocidade, ForceMode2D.Force);
        }

        if (Input.GetKey("d"))
        {
            rd2d.AddForce(Vector2.right * velocidade, ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rd2d.AddForce(Vector2.up * fpulo);
        }
        if (Input.GetMouseButtonDown(0) && contAmmo > 0)
        {
            Instantiate(bala, arma.position, arma.rotation);
            contAmmo --;

        }
    }
}
