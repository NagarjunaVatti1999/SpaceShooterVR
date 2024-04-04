using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Control asteroid speed")]
    public float asteroidSpeedMin;
    public float asteroidSpeedMax;

    [Header("Control asteroid rotation")]
    public float minRotationSpeed;
    public float maxRotationSpeed;

    public Vector3 movementDirection;
    private float xAngle, yAngle, zAngle;

    private float rotationalSpeed;
    private float asteroidSpeed;

    void Start()
    {
        asteroidSpeed = Random.Range(asteroidSpeedMin, asteroidSpeedMax);
        rotationalSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        xAngle = Random.Range(0,360);
        yAngle = Random.Range(0,360);
        zAngle = Random.Range(0,360);

        transform.Rotate(xAngle,yAngle,zAngle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection*Time.deltaTime*asteroidSpeed, Space.World);
        transform.Rotate(Vector3.up*rotationalSpeed*Time.deltaTime);
    }
}
