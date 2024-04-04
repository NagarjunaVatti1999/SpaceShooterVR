using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : Weapon
{

    // Start is called before the first frame update
    [SerializeField] GameObject bulletPrefab;
    protected override void StartShoot(ActivateEventArgs interactor)
    {
        base.StartShoot(interactor);
        Shoot();
    }
    protected override void Shoot()
    {
        base.Shoot();
        GameObject bullet = Instantiate(bulletPrefab, bulletTransform.position, bulletTransform.rotation);
    }

};
