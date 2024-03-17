using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage = 10;
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
        DamageEnemy(collision);
        DestroyFireball();
    }

    private void DamageEnemy(Collision collision)
    {        
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        Debug.Log("DamageEnemy enemyHealth=" + enemyHealth);
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
            /*Debug.Log("enemyHealth.value=" + enemyHealth.value);
            enemyHealth.value -= damage;
            Debug.Log("damage=" + damage);
            Debug.Log("enemyHealth.value=" + enemyHealth.value);
            if (enemyHealth.value <= 0)
            {
                Destroy(enemyHealth.gameObject);
            }*/
        }
    }

    private void DestroyFireball()  
    {
        Destroy(gameObject);
    }
}
