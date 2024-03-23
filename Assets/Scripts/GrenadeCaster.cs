using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform grenadeSourceTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Rigidbody grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
            grenade.transform.position = grenadeSourceTransform.position;
            grenade.transform.rotation = grenadeSourceTransform.rotation;
            grenade.AddForce(grenadeSourceTransform.forward * 10, ForceMode.Impulse);
            /*
             * var grenade = Instantiate(grenadePrefab);
             * grenade.transform.position = grenadeSourceTransform.position;
             * grenade.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
             * */
            /*RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                GameObject grenade = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                grenade.transform.position = hit.point;
                grenade.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                grenade.AddComponent<Rigidbody>();
                grenade.AddComponent<SphereCollider>();
                grenade.AddComponent<Grenade>();
            }*/
        }
    }
}
