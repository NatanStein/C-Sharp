using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void CenaJogo()
    {
        SceneManager.LoadScene("Jogo1");
    }
    public void BackMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
