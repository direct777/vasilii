using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcano : MonoBehaviour
{
    public Grenade grenadePrefab;
    public float forse = 500;
    public float delayMin = 1;
    public float delayMax = 3;
    public float forseMin = 500;
    public float forseMax = 700;

    private void SpawnGrenade()
    {
        Grenade grenade = Instantiate(grenadePrefab);
        grenade.transform.position = transform.position;
        //grenade.GetComponent<Rigidbody>().AddForce(transform.forward * forse, ForceMode.Impulse);
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1f), Random.Range(-1f, 1f));
        //var direction = Random.insideUnitSphere;
        //var direction = Random.onUnitSphere;
        grenade.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(forseMin, forseMax));
        Invoke("SpawnGrenade", Random.Range(delayMin, delayMax));
    }

    private void Start()
    {
        Invoke("SpawnGrenade", Random.Range(delayMin, delayMax));
    }
}
