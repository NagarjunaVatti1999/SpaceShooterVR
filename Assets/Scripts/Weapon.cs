using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletTransform;
    [SerializeField] private float recoilForce;
    [SerializeField] private float damage;

    private Rigidbody rigidbody;
    private XRGrabInteractable interactableWeapon;
    private void Awake() {
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rigidbody = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        interactableWeapon.selectEntered.AddListener(PickUpWeapon);
        interactableWeapon.selectExited.AddListener(DropWeapon);
        interactableWeapon.activated.AddListener(StartShoot);
        interactableWeapon.deactivated.AddListener(StopShoot);
    }

    protected virtual void StopShoot(DeactivateEventArgs arg0)
    {
        throw new NotImplementedException();
    }

    protected virtual void StartShoot(ActivateEventArgs arg0)
    {
        throw new NotImplementedException();
    }

    private void DropWeapon(SelectExitEventArgs arg0)
    {
        throw new NotImplementedException();
    }

    private void PickUpWeapon(SelectEnterEventArgs arg0)
    {
        throw new NotImplementedException();
    }

    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        rigidbody.AddRelativeForce(Vector3.back*recoilForce, ForceMode.Impulse);
    }
    public float GetShootingForce()
    {
        return shootingForce;
    }
    public float GetDamage()
    {
        return damage;
    }
}
