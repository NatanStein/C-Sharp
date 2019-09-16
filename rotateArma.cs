using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateArma : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            transform.Rotate(0f, 20f, 0f);
        }
    }
}
