using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public GameObject explosionPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosioin", delay);

        /*if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }*/
    }
    private void Explosioin()
    {
        /*Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);
        foreach (var item in colliders)
        {
            if(item.tag == "Enemy")
            {
                Destroy(item.gameObject);
            }
        }*/
        Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}
