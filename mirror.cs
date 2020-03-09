using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mirror : MonoBehaviour{

	public GameObject theHUD;
	public GameObject Player;

	private Image VidaSlider;
	private TextMeshProUGUI VidaTexto;
	private Image StaminaSlider;
	private TextMeshProUGUI StaminaTexto;
	private GameObject bonus;
	private GameObject[] bonusArray;

	private int ativos;
	private int bonusAtivos;

	private Color ativado;
	private Color desativado;


	void Start(){

		VidaSlider = transform.Find("VidaSlider").Find("Background").Find("HBP").GetComponent<Image>();
		VidaTexto = transform.Find("VidaTexto").GetComponent<TextMeshProUGUI>();
		StaminaTexto = transform.Find("StaminaTexto").GetComponent<TextMeshProUGUI>();
		bonus = transform.Find("Bonus").gameObject;

		bonusArray = theHUD.GetComponent<HUD>().ChildToArray(bonusArray,bonus);

		ativado = theHUD.GetComponent<HUD>().ativado;
		desativado = theHUD.GetComponent<HUD>().desativado;


		for(int i = 0; i < bonusArray.Length; i++){

			bonusArray[i].transform.Find("BonusInner").GetComponent<SpriteRenderer>().color = desativado;

		}

	}

	void Update(){

		ativos = HUD.ativos;
		bonusAtivos = theHUD.GetComponent<HUD>().bonusAtivos;

		VidaSlider.fillAmount = Player.GetComponent<Player>().HB.fillAmount;
		VidaSlider.color = Player.GetComponent<Player>().HB.color;
		VidaTexto.text = ((Player.GetComponent<Player>().vida.ToString()) + "/" + (Player.GetComponent<Player>().Startvida.ToString()));

			for(int i = 0; i < bonusArray.Length; i++){

				if(i <= (bonusAtivos - 1)){

					bonusArray[i].transform.Find("BonusInner").GetComponent<SpriteRenderer>().color = ativado;

				}else{

					bonusArray[i].transform.Find("BonusInner").GetComponent<SpriteRenderer>().color = desativado;

				}

			}

	}

}
