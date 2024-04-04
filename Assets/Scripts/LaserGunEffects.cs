using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunEffects : MonoBehaviour
{
    // Start is called before the first frame update
    static string TRIGGER ="Fire";
    [SerializeField] LaserGun gun;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Animator animator;
    void Start()
    {
        gun.OnGunTriggered += OnGunTriggered_Audio;
        gun.OnGunTriggered += OnGunTriggered_Animation;
    }

    private void OnGunTriggered_Animation(object sender, EventArgs e)
    {
        animator.SetTrigger(TRIGGER);
    }

    private void OnGunTriggered_Audio(object sender, EventArgs e)
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
