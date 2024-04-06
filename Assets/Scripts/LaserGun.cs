using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform raycastOrigin;
    [SerializeField] float laserTime = 0.2f;
    public event EventHandler OnGunTriggered;
    [SerializeField] GameObject flash;
    private RaycastHit hit;
    public void LaserTrigger()
    {
        OnGunTriggered(this, EventArgs.Empty);
        GameObject flashRay = Instantiate(flash, raycastOrigin.position, raycastOrigin.rotation);
        Destroy(flashRay, laserTime);
        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 800f))
        {
            var obj = hit.transform.GetComponent<IRaycastInterface>();
            
            if(obj!=null)
            {
                obj.Interact();
            }
        }        
    }
}
