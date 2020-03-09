using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallpaper : MonoBehaviour{

	public int index;
	private int indexAtual;

	public float vel;
	public int time;

	private GameObject camada1;
	private GameObject camada2;

	private GameObject[] camada1Array;
	private GameObject[] camada2Array;

	private Vector3 defaultPositionC;
	private Vector3 defaultPositionW;

	private float cont;
	private int changeDir = 1;

	private GameObject[] ChildToArray(GameObject[] array, GameObject thing){

		array = new GameObject[thing.transform.childCount];
		for(int i = 0; i < thing.transform.childCount; i++){

			array[i] = thing.transform.GetChild(i).gameObject;

		}

		return array;

	}

	private int notTheSame(int index, int indexAtual){

		index = Random.Range(0,camada1Array.Length);

		if(index == indexAtual){

			index = notTheSame(index,indexAtual);

		}

		return index;

	}

	void Start(){

		camada1 = transform.Find("camada1").gameObject;
		camada2 = transform.Find("camada2").gameObject;

		camada1Array = new GameObject[camada1.transform.childCount];
		camada2Array = new GameObject[camada2.transform.childCount];

		camada1Array = ChildToArray(camada1Array,camada1);
		camada2Array = ChildToArray(camada2Array,camada2);

		defaultPositionC = transform.Find("dpc").gameObject.transform.position;
		defaultPositionW = transform.Find("dpw").gameObject.transform.position;

	}

	void Update(){

		Debug.Log(index);

		cont += Time.deltaTime;

		if(cont >= time){

			cont = 0f;

			index = notTheSame(index,indexAtual);

			if(index%2 == 0){

				changeDir = 1;

			}else if(index%2 != 0){

				changeDir = -1;

			}
			
			camada1Array[index].GetComponent<Rigidbody2D>().velocity = new Vector2(-vel,0);
			camada1Array[indexAtual].transform.position = defaultPositionC;
			camada2Array[index].GetComponent<Rigidbody2D>().velocity = new Vector2(-vel,0);
			camada2Array[indexAtual].transform.position = defaultPositionW;

		}

		if(index != indexAtual){

			camada1Array[indexAtual].SetActive(false);
			camada2Array[indexAtual].SetActive(false);
			indexAtual = index;

		}

		if(index == indexAtual){

			camada1Array[index].SetActive(true);
			camada2Array[index].SetActive(true);

		}

		camada1Array[index].GetComponent<Rigidbody2D>().velocity = new Vector2(-vel*changeDir,0);
		camada2Array[index].GetComponent<Rigidbody2D>().velocity = new Vector2(vel*changeDir,0);

	}
}
