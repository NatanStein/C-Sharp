using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    //Script que controla as interações nos menus
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void CenaJogo()
    {
        //Carrega a cena do jogo
        SceneManager.LoadScene("F1");
    }
    public void BackMainMenu()
    {
        //Carrega a cena do menu principal
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    { 
        //Quita do game, fechando assim o executavel
        Application.Quit();
    }
}
