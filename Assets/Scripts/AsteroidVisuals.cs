using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidVisuals : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float delay = 1f;
    private bool flag = false;
    public static AsteroidVisuals Instance {get; private set;} //singleton as it has only one instance
    private void Awake() {
        Instance = this;
    }
    private void Update() {
        if(flag == false)Delay();
    }
    IEnumerator Delay()
    {
        flag = true;
        foreach(GameObject go in transform)
        {
            Destroy(go);
        }
        yield return new WaitForSeconds(delay);
        flag = false;
        yield return null;
    }
}
