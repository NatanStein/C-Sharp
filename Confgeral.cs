using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confgeral : MonoBehaviour
{
    public GameObject menu;
    static public bool pause;
    static public float temporest;
    public Text cronometro;
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
            
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FPause(!pause);
            temporest -= Time.deltaTime;
        }
        Attcronometro((int)Mathf.Round(temporest));
    }
    public void Attcronometro(int sec)
    {
        cronometro.text = sec.ToString();
    }
}
