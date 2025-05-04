using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 5f;
    public int damage = 20;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Health>() != null)
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}

