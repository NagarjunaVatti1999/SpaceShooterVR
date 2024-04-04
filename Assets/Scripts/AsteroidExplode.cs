using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplode : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject explodeAsteroid;
    public void AsteroidHit()
    {
        Instantiate(explodeAsteroid, transform.position, transform.rotation);
        Destroy(transform.gameObject);
    }
}
