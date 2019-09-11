using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confgeral : MonoBehaviour
{
    public GameObject menu;
    public AudioSource audio;
    static public bool pause;
    static public float temporest;
    void Start()
    {
        menu = Instantiate(menu,menu.transform.position,menu.transform.rotation) as GameObject;
        FPause(false);
        temporest = 60;
    }
    void FPause(bool statusPause)
    {
        pause = statusPause;
        menu.SetActive(pause);
        if(pause)
        {
            Time.timeScale = 0;
            audio.Pause();
            
        }
        else
        {
            Time.timeScale = 1;
            audio.Play();
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FPause(!pause);
            temporest -= Time.deltaTime;
        }
    }
}
