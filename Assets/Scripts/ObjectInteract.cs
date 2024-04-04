using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteract : MonoBehaviour, IRaycastInterface
{
    public UnityEvent unityEvent;
    
    public void Interact()
    {
        unityEvent.Invoke();
        //GameController.currentState = GameController.GameState.Playing;
    }

    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
