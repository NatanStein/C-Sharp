using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public Image HB, Pbar, PGbar;
    public GameObject pause;
    public int cont;
    static public int contSocos, pontos, contInicio, contMorto, vidas = 4,contDelay;
    static public bool Dcima, DBaixo, DEsq, DDir, EDown, SocoEsq, SocoMeio, SocoDir, isDown, Perdeu,Bpause;
    public float vel, vida, Startvida;
    static public Transform playerpos;
    static public float danoSoco,addHP,addVel,addDano;
    public AudioSource AL, AR, ADown, dodge1, dodge2, dead;

    private void Awake()
    {
        playerpos = transform;
    }

    void Start()
    {
        isDown = true;
        cont = 0;
        contMorto = 0;
        Perdeu = false;
        vida = Startvida;
        rb = GetComponent<Rigidbody2D>();
        HB.fillAmount = 1f;
        contSocos = 0;
        pontos = 0;
        addDano = 0;
        addHP = 0;
        addVel = 0;
        contDelay = 15;
        Bpause = false;
    }
    void DANO(float dano)
    {
        vida -= dano;
    }
    void FixedUpdate()
    {
        Debug.Log(contSocos);
        HB.fillAmount = vida / Startvida;
        HB.color = new Color(1f - vida / Startvida, vida / Startvida, 0, 1);
        Pbar.fillAmount = pontos / 4f;
        PGbar.fillAmount = pontos / 4f;

        if (PauseMenu.UPHP)
        {
            addHP += 20f;
            Startvida += 20f;
            PauseMenu.UPHP = false;
        }
        if (PauseMenu.UPVel)
        {
            addVel += 0.5f;
            vel += 0.5f;
            PauseMenu.UPVel = false;
        }
        if (PauseMenu.UpForça)
        {
            addDano += 1.5f;
            PauseMenu.UpForça = false;

        }
        if (PauseMenu.curar)
        {
            vida = Startvida;
            PauseMenu.curar = false;
        }
        if (contInicio <= 120)
        {
            contInicio++;
        }
        if (HUD.parada || contInicio < 120)
        {
            playerpos = transform;
            animator.SetBool("DBaixo", false);
            animator.SetBool("DDir", false);
            animator.SetBool("DEsq", false);
            animator.SetBool("SocoEsq", false);
            animator.SetBool("SocoDir", false);
            animator.SetBool("InimigoBaixo", false);
            animator.SetBool("InimigoCima", false);
            rb.velocity = new Vector2(0, 0);
            return;
        }
        if (contSocos == 30)
        {
            if (pontos < 4)
            {
                pontos += 1;
            }
            contSocos = 0;
        }
        if (Perdeu)
        {
            SceneManager.LoadScene("FLOSE");
        }
        if (vida <= 0)
        {
            animator.SetTrigger("Cair");
            dead.Play();
            if (contMorto < vidas)
            {
                vida = 3f / 4f * Startvida;
                HB.fillAmount = vida / Startvida;
                contMorto += 1;
            }
            else
            {
                animator.SetBool("Morto", true);
                Perdeu = true;
            }
        }
        cont++;
        if (IA.AtackDL || IA.AtackDR || IA.AtackUL || IA.AtackUR)
        {
            if (!(DEsq || DDir || EDown) && vida > 0)
            {
                DANO(5f);
                if (DBaixo)
                {
                    animator.SetBool("InimigoBaixo", true);
                }
                else
                {
                    animator.SetBool("InimigoCima", true);
                }
            }
            IA.AtackDL = false;
            IA.AtackDR = false;
            IA.AtackUL = false;
            IA.AtackUR = false;
        }
        if (cont % 9 == 0)
        {
            DEsq = false;
            DDir = false;
            EDown = false;
            cont = 0;
        }
        playerpos = transform;
        animator.SetBool("DBaixo", false);
        animator.SetBool("DDir", false);
        animator.SetBool("DEsq", false);
        animator.SetBool("SocoEsq", false);
        animator.SetBool("SocoDir", false);
        animator.SetBool("InimigoBaixo", false);
        animator.SetBool("InimigoCima", false);
        rb.velocity = new Vector2(0, 0);

        if (Input.GetKeyDown("w"))
        {
            animator.SetBool("Dcima", true);
            animator.SetBool("DBaixo", false);
            Dcima = true;
            DBaixo = false;
            isDown = false;
        }
        if (Input.GetKeyDown("s"))
        {
            animator.SetBool("DBaixo", true);
            animator.SetBool("Dcima", false);
            DBaixo = true;
            Dcima = false;
            if (isDown)
            {
                EDown = true;
                cont = 0;
                dodge2.Play();
            }
            else
            {
                isDown = true;
                EDown = false;
            }
        }
        if (Input.GetKey("a"))
        {
            if (transform.position.x >= -6.85f)
            {
                rb.velocity = new Vector2(-vel, 0);
            }
        }
        if (Input.GetKey("d"))
        {
            if (transform.position.x <= 6.96f)
            {
                rb.velocity = new Vector2(vel, 0);
            }
        }
        if (Input.GetKeyDown("q"))
        {
            animator.SetBool("DEsq", true);
            animator.SetBool("DDir", false);
            DEsq = true;
            DDir = false;
            cont = 0;
            dodge1.Play();
        }
        if (Input.GetKeyDown("e"))
        {
            animator.SetBool("DDir", true);
            animator.SetBool("DEsq", false);
            DDir = true;
            DEsq = false;
            cont = 0;
            dodge1.Play();
        }
        if (contDelay <= 15)
        {
            contDelay++;
        }

        if (Input.GetKeyDown("j"))
        {
            animator.SetBool("SocoEsq", true);
            SocoEsq = true;
            if (Dcima)
            {
                AL.Play();
            }
            else
            {
                ADown.Play();
            }
            contDelay = 0;
        }
        if (Input.GetKeyDown("l"))
        {
            animator.SetBool("SocoDir", true);
            SocoDir = true;
            if (Dcima)
            {
                AR.Play();
            }
            else
            {
                ADown.Play();
            }
            contDelay = 0;
        }
        if (Input.GetKeyDown("esc"))
        {
            Bpause = !Bpause;
            pause.gameObject.SetActive(Bpause);
        }
    }
}
