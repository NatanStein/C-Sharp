using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScBala : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    void Start()
    {

    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }

    }
    void shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }

}


