using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aidkit : MonoBehaviour
{
    public float healAmount = 50f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Aidkit-OnTriggerEnter");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Aidkit-OnTriggerEnter");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log("healing player");
                playerHealth.AddHealth(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
