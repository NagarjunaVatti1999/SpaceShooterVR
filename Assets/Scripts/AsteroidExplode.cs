using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplode : MonoBehaviour, IRaycastInterface
{
    // Start is called before the first frame update
    [SerializeField] GameObject explodeAsteroid;
    [SerializeField] GameObject[] explosions;
    private float VisualTime = 1f;
    private void Start() {
    }
    public void AsteroidHit()
    {
        if(GameController.currentState == GameController.GameState.Playing)
        {
            GameObject v1 = Instantiate(explodeAsteroid, transform.position, transform.rotation, AsteroidVisuals.Instance.transform );
            GameObject v2 =Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, transform.rotation, AsteroidVisuals.Instance.transform);

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
