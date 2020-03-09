using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour{


	[Header("Personagens")]
	public GameObject player;
	public GameObject todosInimigos;
	private GameObject[] inimigosArray;
	public int indexInimigoAtivo;


	[Header("HUDs")]
	public GameObject playerHUD;
	public GameObject todosInimigosHUD;

	public Color[] corDeCadaHUD;

	private GameObject[] inimigosHUDArray;
	private GameObject pointsOnTheGo;


	[Header("Setup do Bonus")]
	public GameObject bonus;
	private GameObject[] bonusArray;
	public int bonusAtivos;
	public Color ativado;
	public Color desativado;


	[Header("Config dos Rounds")]
	public float countdownTime;
	public float tempoNoMenu;


	public Image blackPanel;

	//"Algumas" Variaveis Privadas (eu sei).

	private GameObject startPositionPlayerHUD;
	private GameObject startPositionInimigosHUD;
	private GameObject ancoraPlayer;
	private GameObject ancoraInimigos;
	private GameObject esseInimigo;
	private GameObject esseHUDInimigo;
	private GameObject roundText;
	private GameObject countdownText;
	private GameObject countdownTextBreak;

	private GameObject menuBreak;

	private bool startRound = true;
	private bool showNextRound = true;
	private bool done = false;
	private bool once = false;
	private bool vidaDefaultCheck = true;
	private bool pontoBool = false;

	static public int ativos;
	private int round = 0;
	private int socosDefault = 0;

	private float countdownTimeDefault;
	private float velocidadeDefault;
	private float count;

	private Image HBE;
	private Image shiny;
	private Image notShiny;

	private Color essaCor;

	private float razaoR;
	private float razaoG;
	private float razaoB;
    static public bool parada = false;
	public TextMeshProUGUI TPontos,TGPontos,TSocos;





	//Monta VETORES DE GAMEOBJECTS com as CHILDS de um GameObject.
	public GameObject[] ChildToArray(GameObject[] array, GameObject thing){

		array = new GameObject[thing.transform.childCount];
		for(int i = 0; i < thing.transform.childCount; i++){

			array[i] = thing.transform.GetChild(i).gameObject;

		}

		return array;

	}



	//Passa um Round.
	public void NextRound(){

		round += 1;
		roundText.GetComponent<TextMeshProUGUI>().text = ("Round " + round.ToString());

		countdownTime = countdownTimeDefault;

	}



	//Faz alguma coisa seguir outra coisa com delay.
	void ChaseAncora(GameObject anyHUD, GameObject ancora){

		if((anyHUD.transform.position.x - ancora.transform.position.x) == 0){

			anyHUD.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

		}

    	if((anyHUD.transform.position.x - ancora.transform.position.x) > 0.25f){

   			anyHUD.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadeDefault,0);

   		}

   		if((anyHUD.transform.position.x - ancora.transform.position.x) < -0.25f){

   			anyHUD.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeDefault,0);

    	}

    }


    //Mostra o Round NUMERO por X segundos.
    IEnumerator ShowRound(){

    	roundText.SetActive(true);
		yield return new WaitForSeconds(2);
		roundText.SetActive(false);
		yield return null;
		startRound = false;

    }



    //Ativa a contagem regressiva na tela.
	IEnumerator ShowCountdown(){

		for(int i = 0; i < 3; i++){

			countdownText.SetActive(true);
			yield return null;
			countdownText.SetActive(false);
			yield return null;

		}

		countdownText.SetActive(true);
		done = true;

	}


	IEnumerator ShowSocos(){

		pointsOnTheGo.GetComponent<TextMeshProUGUI>().text = ((Player.contSocos).ToString()) + "/30";
		pointsOnTheGo.SetActive(false);

		yield return new WaitForSeconds(2);


	}



	public void Start(){

		count = tempoNoMenu;

		pointsOnTheGo = transform.Find("OnTheGo").gameObject;

		//Configura as ANCORAS e START POSITIONS.
		ancoraPlayer = transform.Find("Referencias").Find("AncoraPlayer").gameObject;
		ancoraInimigos = transform.Find("Referencias").Find("AncoraInimigos").gameObject;
		startPositionPlayerHUD = transform.Find("Referencias").Find("StartPlayerHUD").gameObject;
		startPositionInimigosHUD = transform.Find("Referencias").Find("StartInimigosHUD").gameObject;



		//Pega as CHILDS e monta um VETOR (pra facilitar).
		inimigosArray = ChildToArray(inimigosArray,todosInimigos);
		inimigosHUDArray = ChildToArray(inimigosHUDArray,todosInimigosHUD);
		bonusArray = ChildToArray(bonusArray,bonus);



		//Prepara a POSIÇÂO DE LANÇAMENTO DAS HUDS.
		playerHUD.transform.position = startPositionPlayerHUD.transform.position;
		inimigosHUDArray[indexInimigoAtivo].transform.position = startPositionInimigosHUD.transform.position;



		//Inicializa os BONUS com cor (mais pra frente a qtd. real de BONUS é ajustada).
		for(int i = 0; i < bonusArray.Length; i++){

			bonusArray[i].transform.Find("BonusInner").GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);

		}


		menuBreak = transform.Find("MenuBreak").gameObject;
		countdownTextBreak = menuBreak.transform.Find("Timer").Find("Time").gameObject;

		roundText = transform.Find("RoundText").gameObject;						//Procurando o GObject do texto de round.
		countdownText = transform.Find("CountdownText").gameObject;				//Procurando o GObject do countdown.
		countdownTimeDefault = countdownTime;									//Backup do valor do Countdown pra poder resetá-lo.

		esseInimigo = inimigosArray[indexInimigoAtivo].gameObject;				//Facilitando a chamada do Inimigo atual
		esseHUDInimigo = inimigosHUDArray[indexInimigoAtivo].gameObject;		//Facilitando a chamada do HUD inimigo atual.


		essaCor = corDeCadaHUD[esseHUDInimigo.GetComponent<colorHUD>().indexColor];


		HBE = esseHUDInimigo.transform.Find("VidaSlider").Find("Background").Find("HBE").GetComponent<Image>();
		shiny = esseHUDInimigo.transform.Find("Detalhes").Find("ShinyThing").GetComponent<Image>();
		notShiny = esseHUDInimigo.transform.Find("Detalhes").Find("NotShinyThing").GetComponent<Image>();

		razaoR = (1 - essaCor.r);
		razaoG = (1 - essaCor.g);
		razaoB = (1 - essaCor.b);
	
	}




	void Update(){

		if((Player.contSocos) != socosDefault){

			socosDefault = Player.contSocos;
			StartCoroutine(ShowSocos());

		}
		TPontos.text = (Player.pontos).ToString();
		TGPontos.text = (Player.pontos).ToString();
		TSocos.text ="Socos: "+((Player.contSocos).ToString()) + "/30";

		HBE.fillAmount = esseInimigo.GetComponent<IA>().vida/esseInimigo.GetComponent<IA>().StartVida;
        HBE.color = new Color((esseInimigo.GetComponent<IA>().vida / esseInimigo.GetComponent<IA>().StartVida) - razaoR, (esseInimigo.GetComponent<IA>().vida / esseInimigo.GetComponent<IA>().StartVida) - razaoG, (esseInimigo.GetComponent<IA>().vida / esseInimigo.GetComponent<IA>().StartVida) - razaoB, 1f);
        shiny.color = new Color((esseInimigo.GetComponent<IA>().vida / esseInimigo.GetComponent<IA>().StartVida) - razaoR, (esseInimigo.GetComponent<IA>().vida / esseInimigo.GetComponent<IA>().StartVida) - razaoG, (esseInimigo.GetComponent<IA>().vida / esseInimigo.GetComponent<IA>().StartVida) - razaoB, 1f);
        notShiny.color = new Color((esseInimigo.GetComponent<IA>().vida / esseInimigo.GetComponent<IA>().StartVida) - razaoR, (esseInimigo.GetComponent<IA>().vida / esseInimigo.GetComponent<IA>().StartVida) - razaoG, (esseInimigo.GetComponent<IA>().vida / esseInimigo.GetComponent<IA>().StartVida) - razaoB, 0.25f);

		if(!done){

			for(int i = 0; i < inimigosArray.Length; i++){

					esseInimigo.SetActive(true);
					esseHUDInimigo.SetActive(true);

					if(i != indexInimigoAtivo){

						inimigosArray[i].SetActive(false);
						inimigosHUDArray[i].SetActive(false);

					}

				}

			}

		//Preenche alguns FILL AMOUNT e o TEXTOS de vida e afins.
		playerHUD.transform.Find("VidaTexto").GetComponent<TextMeshProUGUI>().text = ((player.GetComponent<Player>().vida.ToString()) + "/" + (player.GetComponent<Player>().Startvida.ToString()));


		//Controla o indicador de quantos BONUS o PLAYER tem.
		bonusAtivos= Player.vidas - Player.contMorto;
		if(bonusAtivos != ativos){

			for(int i = 0; i < bonusArray.Length; i++){

				if(i <= (bonusAtivos - 1)){

					bonusArray[i].transform.Find("BonusInner").GetComponent<SpriteRenderer>().color = ativado;

				}else{

					bonusArray[i].transform.Find("BonusInner").GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);	

				}

			}

			ativos = bonusAtivos;

		}


		//Controla o comportamento da contagem regressiva.
		if(!startRound){

			countdownTime -= Time.deltaTime;
			countdownText.GetComponent<TextMeshProUGUI>().text = ((int)countdownTime + 1).ToString();
            if(countdownTime <= 0)
            {
                parada = true;
            }

		}else if(startRound){

			countdownText.GetComponent<TextMeshProUGUI>().text = countdownTimeDefault.ToString();

		}

	}




	void FixedUpdate(){

		if(countdownTime <= 0f){

			countdownText.SetActive(false);
			blackPanel.enabled = true;

			menuBreak.SetActive(true);
			count -= Time.deltaTime;
			
			if(count <=3)
            {
				Player.contInicio = 0;
            }
			countdownTextBreak.GetComponent<Text>().text = count.ToString();

			if(count <= 0f){

				menuBreak.SetActive(false);
				blackPanel.enabled = false;
				startRound = true;
                parada = false;
                count = tempoNoMenu;

			}

		}

		//Faz os HUDS perseguirem as ANCORAS causando o delay.
		if(countdownTime > 0f){

			velocidadeDefault = (player.GetComponent<Player>().vel + 1);

			ChaseAncora(playerHUD, ancoraPlayer);
			ChaseAncora(esseHUDInimigo, ancoraInimigos);

		}else if(countdownTime <= 0f){

			ChaseAncora(playerHUD, startPositionPlayerHUD);
			ChaseAncora(esseHUDInimigo, startPositionInimigosHUD);

		}

		if(startRound){

			if(showNextRound){

				NextRound();
				showNextRound = false;

			}

			StartCoroutine(ShowRound());

			done = false;

		}



    	//Começa o movimento da contagem regressiva.
    	if(startRound == false && !done){

    		StartCoroutine(ShowCountdown());
    		showNextRound = true;

    	}

	}

}