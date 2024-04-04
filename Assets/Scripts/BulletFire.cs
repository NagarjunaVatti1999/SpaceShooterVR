using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform bulletSpawn;
    [SerializeField] int bulletDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fire()
    {
        RaycastHit hit;
        if(Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, bulletDistance))
        {
            Debug.Log(hit.transform.gameObject.name);
        }
    }
}
