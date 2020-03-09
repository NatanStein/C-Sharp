using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class principalmenu : MonoBehaviour
{
	public TextMeshProUGUI pressItText;
	public GameObject menu;

    void Update(){

    	if(Input.anyKey){

    		pressItText.enabled = false;
    		menu.SetActive(true);

    	}
    }   
}
