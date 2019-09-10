using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCMunicao : MonoBehaviour
{
    public int muni,rot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rot * Time.deltaTime, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        movepos personagem = collision.transform.GetComponent<movepos>() ;
        if (personagem)
        {
            personagem.contAmmo += muni;
            Destroy(gameObject);
        }
    }
}

