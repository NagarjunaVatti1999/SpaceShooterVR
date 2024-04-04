using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform raycastOrigin;
    public event EventHandler OnGunTriggered;
    private RaycastHit hit;
    public void LaserTrigger()
    {
        OnGunTriggered(this, EventArgs.Empty);

        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 800f))
        {
            var obj = hit.transform.GetComponent<AsteroidExplode>();
            if(obj!=null)
            {
                obj.AsteroidHit();
            }
        }        
    }
}
