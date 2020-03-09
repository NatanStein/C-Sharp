using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IA : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public int probAtack, probEsq,tonto,contSoco=0,resistencia,qttTonto,resiliencia,cont,dir,velSoco,contDie;
    public float vida,StartVida,velocidade;
    public bool isDead,resurg;
    static public bool AtackUL, AtackUR,AtackDL,AtackDR,UP,DOWN;
    public AudioSource clow1, clow2, blockD, blockUP, dead;
    int escolha;
    void Dmg(float dano)
    {
        vida -= dano;
    }
    void Attack()
    {
        if(Mathf.Abs(transform.position.x - Player.playerpos.position.x) <= 2)
        {
            escolha = Random.Range(1, 5);
            if (escolha == 1)
            {
                AtackUL = true;
                anim.SetBool("isDown",false);
                UP = true;
                DOWN = false;
                anim.SetBool("punchLeft", true);
                clow1.Play();

            }
            if (escolha == 2)
            {
                AtackUR = true;
                anim.SetBool("isDown",false);
                UP = true;
                DOWN = false;
                anim.SetBool("punchRight", true);
                clow2.Play();
            }
            if (escolha == 3)
            {
                AtackDL = true;
                anim.SetBool("isDown", true);
                UP = false;
                DOWN = true;
                anim.SetBool("punchLeft", true);
                clow1.Play();
            }
            if(escolha == 4)
            {
                AtackDR = true;
                anim.SetBool("isDown", true);
                UP = false;
                DOWN = true;
                anim.SetBool("punchRight", true);
                clow2.Play();
            }
            cont = 0;

        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vida = StartVida;
        tonto = 0;
        isDead = false;
        resurg = false;
        contDie = 5;
    }

    void FixedUpdate()
    {
        if(resurg)
        {
            contDie++;
            if(contDie >= 5)
            {
                anim.SetBool("isDead", false);
                resurg = false;
            }
            else
            {
                return;
            }
        }
        if(HUD.parada || Player.contInicio < 115)
        {
            anim.SetBool("hitHigh", false);
            anim.SetBool("hitLow", false);
            anim.SetBool("punchLeft", false);
            anim.SetBool("punchRight", false);
            rb.velocity = new Vector2(0, 0);
            return;
        }
        cont++;
        anim.SetBool("hitHigh", false);
        anim.SetBool("hitLow", false);
        anim.SetBool("punchLeft", false);
        anim.SetBool("punchRight", false);
        rb.velocity = new Vector2(0, 0);
        resurg = false;
        if (contSoco >= resistencia)
        {
            tonto = qttTonto;
        }
        if(Mathf.Abs(transform.position.x - Player.playerpos.position.x) <= 0.8)
        {
            anim.SetBool("walkB", false);
            anim.SetBool("walkF", false);
            if ((Player.SocoDir || Player.SocoEsq) && vida > 0)
            {
                if((!UP && !Player.Dcima ) || (UP) )
                {
                    escolha = Random.Range(1, 100);
                    if (escolha <= probEsq - tonto)
                    {
                        if (UP)
                        {
                            anim.SetBool("hitHigh", true);
                            blockUP.Play();
                        }
                        else
                        {
                            anim.SetBool("hitLow", true);
                            blockD.Play();
                        }
                        Player.SocoDir = false;
                        Player.SocoEsq = false;
                    }
                    else
                    {
                        if (UP)
                        {
                            anim.SetBool("hitLow", true);
                        }
                        else
                        {
                            anim.SetBool("hitHigh", true);
                        }
                        contSoco += 1;
                        if(Player.isDown)
                        {
                            Dmg(4f + Player.addDano);
                        }
                        else
                        {
                            Dmg(7f + Player.addDano);
                        }
                        Player.SocoDir = false;
                        Player.SocoEsq = false;
                        Player.contSocos += 1;
                    }

                }
                else
                {
                    Player.SocoDir = false;
                    Player.SocoEsq = false;

                }
            }
            if (cont % velSoco == 0)
            {
                Attack();
            }
        }
        else
        {
            if (transform.position.x - Player.playerpos.position.x >= 0)
            {
                anim.SetBool("walkF", true);
                dir = -1;
            }
            else
            {
                anim.SetBool("walkF", true);
                dir = 1;
            }
            rb.velocity = new Vector2(velocidade * dir, 0);
        }
        if (vida <= 0 && !isDead && !resurg)
        {
            anim.SetBool("isDead", true);
            dead.Play();
            escolha = Random.Range(1, 100);
            contDie = 0;
            if(escolha <= resiliencia)
            {
                resiliencia /= 2;
                vida = StartVida * 3 / 4;
                resurg = true;
                
            }
            else
            {
                isDead = true;
                SceneManager.LoadScene("FWIN");
            }

        }
    }
}
