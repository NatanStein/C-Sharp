using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOME : MonoBehaviour
{
    public GameObject opcao;
    public GameObject outro;

    public void Some()
    {
        opcao.SetActive(true);
        outro.SetActive(false);
    }
}
