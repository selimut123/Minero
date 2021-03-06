using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
