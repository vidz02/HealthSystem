using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField]
    private float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hazard collided with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            var playerHealth = other.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Destroy(gameObject);                // Destroy the hazard after it has dealt damage
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hazard collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
