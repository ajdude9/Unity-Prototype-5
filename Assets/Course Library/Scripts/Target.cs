using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float speed;
    private float minSpeed = 12;
    private float maxSpeed = 16;

    private float torque = 10;

    private float xBound = 4;
    private float yBound = -6;

    public int pointValue;

    public ParticleSystem explosionParticle;

    private GameManager gameManager;//Create the object 'Game Manager' as a variable
    // Start is called before the first frame update
    void Start()
    {        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();//Set the variable 'gameManager' to the actual Game Manager
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        
    }
    // Update is called once per frame
    void Update()
    {
        if(!gameManager.isGameActive)
        {
            Destroy(gameObject);
        }
    }

    Vector3 RandomForce()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        return Vector3.up * speed;
    }
    float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xBound, xBound), yBound);
    }

    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();            
        }
    }
}
