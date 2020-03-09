using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confgeral : MonoBehaviour
{
    public GameObject menu;
    public AudioSource audio;
    static public bool pause;
    void Start()
    {
        menu = Instantiate(menu,menu.transform.position,menu.transform.rotation) as GameObject;//Define menu como a chave para instanciar o menu
        FPause(false);
    }
    void FPause(bool statusPause)
    {
        pause = statusPause;
        //Ativa ou desativa o menu conforme a variavel pause
        menu.SetActive(pause);
        if(pause)
        {
            //Paralisa tudo em cena
            Time.timeScale = 0;
            //Paralisa o audio 
            audio.Pause();
            
        }
        else
        {
            //Ativa tudo em cena
            Time.timeScale = 1;
            //Ativa o audio 
            audio.Play();
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Se a tecla ESC for apertada coloca a variavel pause como o inverso dele e chama a função FPause
            FPause(!pause);
        }
    }
}
