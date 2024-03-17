using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireball", lifeTime);
    }

    // Update is called once per frame
    /*void Update()
    {
       //transform.position +=  transform.forward * speed * Time.deltaTime;
    }*/

    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            DestroyFireball();
        }
    }

    private void DestroyFireball()  
    {
        Destroy(gameObject);
    }
}
