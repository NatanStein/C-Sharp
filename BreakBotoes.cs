using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakBotoes : MonoBehaviour
{
    public Button HP, Vel, força, heal;
    public Text pontos;
    void Start()
    {
        
    }
    void Update()
    {
        pontos.text = (Player.pontos).ToString();
        if(Player.pontos < 1)
        {
            HP.interactable = false;
            Vel.interactable = false;
        }
        else
        {
            HP.interactable = true;
            Vel.interactable = true;
        }
        if(Player.pontos < 2)
        {
            força.interactable = false;
        }
        else
        {
            força.interactable = true;
        }
        if(Player.pontos < 4)
        {
            heal.interactable = false;
        }
        else
        {
            heal.interactable = true;
        }
        
    }
}
