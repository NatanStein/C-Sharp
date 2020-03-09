using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false,UPHP = false,UPVel = false,UpForça = false,curar = false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MENU");
    }
    public void Play()
    {
        SceneManager.LoadScene("FTESTE");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void HP()
    {
        if (Player.pontos >= 1)
        {
            UPHP = true;
            Player.pontos -= 1;
        }

    }
    public void velocity()
    {
        if(Player.pontos >= 1)
        {
            UPVel = true;
            Player.pontos -= 1;
        }

    }
    public void força()
    {
        if (Player.pontos >= 2)
        {
            UpForça = true;
            Player.pontos -= 2;
        }

    }
    public void heal()
    {
        curar = true;
        Player.pontos -= 4;

    }

}

