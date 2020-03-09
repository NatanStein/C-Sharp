using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Animator animator;
    public int escolha,cont,contTest=4,contLetras=0;
    public float speed, contStart;
    public string STutorial = "",lixo="",SUsuario="";
    public bool Starting,waiting,stop;
    public Button play, skip,tryagain;
    public Image L1, L2, L3, L4, L5;
    public Text TL1, TL2, TL3, TL4, TL5,timer,GO,ST,points;
    public Transform ConjLetras;
    public AudioSource AL, AR, dodge1, dodge2;

    public void Skip()
    {
        SceneManager.LoadScene("F1");
    }
    public void TryAgain()
    {
        tryagain.gameObject.SetActive(false);
        SceneManager.LoadScene("FTESTE");
    }
    public void Play()
    {
        play.gameObject.SetActive(false);
        skip.gameObject.SetActive(false);
        waiting = false;
        timer.gameObject.SetActive(true);
        ST.gameObject.SetActive(true);
        contStart = 10f;
    }
    public int check ()
    {
        int contador = 0;
        for(int i = 0;i<100;i++)
        {
            if (STutorial.Substring(i, 1) == SUsuario.Substring(i, 1))
            {
                contador++;
            }
        }
        return contador;

    }
    void Start()
    {
        cont = 9;
        contStart = 10f;
        Starting = true;
        GO.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        ST.gameObject.SetActive(false);
        waiting = true;
        stop = false;
        for (int i=0;i<100;i++)
        {
            escolha = Random.Range(1, 7);
            if(escolha == 1)
            {
                lixo = "w";
            }
            if (escolha == 2)
            {
                lixo = "s";
            }
            if (escolha == 3)
            {
                lixo = "e";
            }
            if (escolha == 4)
            {
                lixo = "q";
            }
            if (escolha == 5)
            {
                lixo = "l";
            }
            if (escolha == 6)
            {
                lixo = "j";
            }
            STutorial += lixo;

        }
        Debug.Log(STutorial);
        TL5.text = (STutorial.Substring(0,1)).ToUpper();
        TL4.text = (STutorial.Substring(1,1)).ToUpper();
        TL3.text = (STutorial.Substring(2,1)).ToUpper();
        TL2.text = (STutorial.Substring(3,1)).ToUpper();
        TL1.text = (STutorial.Substring(4,1)).ToUpper();
        SUsuario = "     ";
    }
    void FixedUpdate()
    {
        if(!waiting || !stop)
        {
            if (Starting && !stop)
            {
                timer.text = (contStart -= Time.fixedDeltaTime).ToString().Substring(0, 1);
                if (contStart <= 0f)
                {
                    GO.gameObject.SetActive(true);
                    timer.gameObject.SetActive(false);
                    ST.gameObject.SetActive(false);
                }
                if (contStart <= -1.5f)
                {
                    GO.gameObject.SetActive(false);
                    Starting = false;
                }
            }
            else
            {
                if (SUsuario.Length == 100)
                {
                    stop = true;
                    tryagain.gameObject.SetActive(true);
                    points.gameObject.SetActive(true);
                    points.text = check() + "/100";

                }
                if (Input.anyKeyDown)
                {
                    contLetras += 1;
                    for (int i = 0; i < SUsuario.Length; i++)
                    {
                        if (SUsuario.Substring(i, 1) == " " && contLetras <= 5)
                        {

                            SUsuario = SUsuario.Substring(0, i) + Input.inputString + SUsuario.Substring(i + 1, SUsuario.Length - i - 1);
                            Debug.Log(SUsuario);
                            break;
                        }
                    }


                }
                if(cont != 104)
                {
                    L1.rectTransform.localPosition += new Vector3(0f, -1f * speed, 0f);
                    L2.rectTransform.localPosition += new Vector3(0f, -1f * speed, 0f);
                    L3.rectTransform.localPosition += new Vector3(0f, -1f * speed, 0f);
                    L4.rectTransform.localPosition += new Vector3(0f, -1f * speed, 0f);
                    L5.rectTransform.localPosition += new Vector3(0f, -1f * speed, 0f);
                }


                for (int i = contTest - 4; i <= cont; i++)
                {
                    if (i == contTest - 4)
                    {
                        if (STutorial.Substring(i, 1) == SUsuario.Substring(i, 1))
                        {
                            L5.color = new Color(0f, 1f, 0f);
                        }
                        else if (SUsuario.Substring(i, 1) == " ")
                        {
                            L5.color = new Color(1f, 1f, 1f);
                        }
                        else
                        {
                            L5.color = new Color(1f, 0f, 0f);
                        }
                    }
                    if (i == contTest - 3)
                    {
                        if (STutorial.Substring(i, 1) == SUsuario.Substring(i, 1))
                        {
                            L4.color = new Color(0f, 1f, 0f);
                        }
                        else if (SUsuario.Substring(i, 1) == " ")
                        {
                            L4.color = new Color(1f, 1f, 1f);
                        }
                        else
                        {
                            L4.color = new Color(1f, 0f, 0f);
                        }
                    }
                    if (i == contTest - 2)
                    {
                        if (STutorial.Substring(i, 1) == SUsuario.Substring(i, 1))
                        {
                            L3.color = new Color(0f, 1f, 0f);
                        }
                        else if (SUsuario.Substring(i, 1) == " ")
                        {
                            L3.color = new Color(1f, 1f, 1f);
                        }
                        else
                        {
                            L3.color = new Color(1f, 0f, 0f);
                        }
                    }
                    if (i == contTest - 1)
                    {
                        if (STutorial.Substring(i, 1) == SUsuario.Substring(i, 1))
                        {
                            L2.color = new Color(0f, 1f, 0f);
                        }
                        else if (SUsuario.Substring(i, 1) == " ")
                        {
                            L2.color = new Color(1f, 1f, 1f);
                        }
                        else
                        {
                            L2.color = new Color(1f, 0f, 0f);
                        }
                    }
                    if (i == contTest)
                    {
                        if (STutorial.Substring(i, 1) == SUsuario.Substring(i, 1))
                        {
                            L1.color = new Color(0f, 1f, 0f);
                        }
                        else if (SUsuario.Substring(i, 1) == " ")
                        {
                            L1.color = new Color(1f, 1f, 1f);
                        }
                        else
                        {
                            L1.color = new Color(1f, 0f, 0f);
                        }
                    }
                }

                if (L1.rectTransform.localPosition.y <= -780f && cont != 104)
                {
                    L1.rectTransform.localPosition = new Vector2(-80f, 290f);
                    L2.rectTransform.localPosition = new Vector2(-80f, 160f);
                    L3.rectTransform.localPosition = new Vector2(-80f, 30f);
                    L4.rectTransform.localPosition = new Vector2(-80f, -100f);
                    L5.rectTransform.localPosition = new Vector2(-80f, -230f);

                    for (int i = cont - 4; i <= cont; i++)
                    {
                        if (i == cont - 4)
                        {
                            TL5.text = (STutorial.Substring(cont - 4, 1)).ToUpper();
                        }
                        if (i == cont - 3)
                        {
                            TL4.text = (STutorial.Substring(cont - 3, 1)).ToUpper();
                        }
                        if (i == cont - 2)
                        {
                            TL3.text = (STutorial.Substring(cont - 2, 1)).ToUpper();
                        }
                        if (i == cont - 1)
                        {
                            TL2.text = (STutorial.Substring(cont - 1, 1)).ToUpper();
                        }
                        if (i == cont)
                        {
                            TL1.text = (STutorial.Substring(cont, 1)).ToUpper();
                        }
                    }
                    cont += 5;
                    speed += 0.2f;
                    contTest += 5;
                    for (int i = 0; i < SUsuario.Length; i++)
                    {
                        if (SUsuario.Substring(i, 1) == " ")
                        {
                            SUsuario = SUsuario.Substring(0, i) + "X" + SUsuario.Substring(i + 1, SUsuario.Length - i - 1);
                            Debug.Log(SUsuario);
                            Debug.Log(SUsuario.Length);
                        }
                    }
                    SUsuario += "     ";
                    contLetras = 0;
                }
                animator.SetBool("DBaixo", false);
                animator.SetBool("DDir", false);
                animator.SetBool("DEsq", false);
                animator.SetBool("SocoEsq", false);
                animator.SetBool("SocoDir", false);
                animator.SetBool("InimigoBaixo", false);
                animator.SetBool("InimigoCima", false);
                if (Input.GetKeyDown("w"))
                {
                    animator.SetBool("Dcima", true);
                    animator.SetBool("DBaixo", false);
                }
                if (Input.GetKeyDown("s"))
                {
                    animator.SetBool("DBaixo", true);
                    animator.SetBool("Dcima", false);
                    dodge2.Play();
                }
                if (Input.GetKeyDown("q"))
                {
                    animator.SetBool("DEsq", true);
                    animator.SetBool("DDir", false);
                    dodge1.Play();
                }
                if (Input.GetKeyDown("e"))
                {
                    animator.SetBool("DDir", true);
                    animator.SetBool("DEsq", false);
                    dodge1.Play();
                }
                if (Input.GetKeyDown("j"))
                {
                    animator.SetBool("SocoEsq", true);
                    AL.Play();
                }
                if (Input.GetKeyDown("l"))
                {
                    AR.Play();
                    animator.SetBool("SocoDir", true);
                }
            }
        }
        else
        {
            contStart = 10f;
        }
        

    }
}
