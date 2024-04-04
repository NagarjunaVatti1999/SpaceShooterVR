using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplode : MonoBehaviour, IRaycastInterface
{
    // Start is called before the first frame update
    [SerializeField] GameObject explodeAsteroid;
    private void Start() {
    }
    public void AsteroidHit()
    {
        if(GameController.currentState == GameController.GameState.Playing)
        {
            Instantiate(explodeAsteroid, transform.position, transform.rotation);

            float dist = Vector3.Distance(transform.position, Player.Instance.transform.position);
            int bonuspoints = (int)dist;

            int asteroidScore = 10*bonuspoints;
            GameController.Instance.UpdatePlayerScore(asteroidScore);
        }
        
        Destroy(transform.gameObject);
    }

    public void Interact()
    {
        AsteroidHit();
    }
}
