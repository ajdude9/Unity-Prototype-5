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
    // Start is called before the first frame update
    void Start()
    {        
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        
    }
    // Update is called once per frame
    void Update()
    {
        
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
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
