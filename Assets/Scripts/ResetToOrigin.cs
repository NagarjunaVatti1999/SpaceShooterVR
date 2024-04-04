using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetToOrigin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Pose originPose;
    [SerializeField] XRGrabInteractable xRGrabInteractable;
    private void Awake() {
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
        originPose.position = transform.position;
        originPose.rotation = transform.rotation;
    }

    private void OnEnable() {
        xRGrabInteractable.selectExited.AddListener(LaserGunReleased);
    }
    private void OnDisable() {
        xRGrabInteractable.selectExited.RemoveListener(LaserGunReleased);
    }

    private void LaserGunReleased(SelectExitEventArgs arg0)
    {
        transform.position = originPose.position;
        transform.rotation = originPose.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
