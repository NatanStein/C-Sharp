using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepos : MonoBehaviour
{
    public float velocidade, fpulo;
    public Rigidbody2D rd2d;
    public bool noChao;
    public GameObject bala;
    public int contAmmo;
    static public bool l, r;
    public Animator animator;
    Collider2D myCollider;


    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        noChao = false;
    }
    void Update()
    {
        animator.SetFloat("Vertical Speed",0);
        animator.SetBool("Jump",false);
        if (Confgeral.pause)
        {
            return;
        }
        float velocidadeAtual = velocidade;
        myCollider.enabled = false;
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f))
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
            transform.localScale = new Vector3(-1,1,1);
            l = true;
            r = false;
            animator.SetFloat("Vertical Speed",1f);
        }

        if (Input.GetKey("d"))
        {
            rd2d.AddForce(Vector2.right * velocidade, ForceMode2D.Force);
            transform.localScale = new Vector3(1,1,1);
            r = true;
            l = false;
            animator.SetFloat("Vertical Speed",1);
        }
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            animator.SetBool("Jump", true);
            rd2d.AddForce(Vector2.up * fpulo);
        }
    }
}