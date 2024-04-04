using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public static Player Instance {get; private set;}

    private void Awake() {
        Instance = this;
    }
}
