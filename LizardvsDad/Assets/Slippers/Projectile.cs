using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 5f;
    public int damage = 20;
    public AudioSource falling;
    public AudioSource impact;
    public AudioSource squeek;
    bool soundplayed = false;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject != null)
        {
            //Debug.Log("Hit parent's name: " + hitObject.name);
            var health = hitObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                
                health.TakeDamage(damage);
                squeek.Play();
            }
            falling.Stop();
            impact.Play();
            soundplayed = true;

        }


    }

    private void Update()
    {
        if(soundplayed == true && impact.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}

