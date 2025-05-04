using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperShooter : MonoBehaviour
{
    public GameObject projectilePrefab;   // Assign your projectile prefab in the inspector
    public GameObject target;
    public float fireInterval = 5f;       // Time in seconds between each shot
    public float projectileSpeed = 10f;   // Speed of the projectile
    public GameObject sourceObject;
    public bool active = false;
    public float heightAboveTarget = 1f;
    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (active && fireTimer >= fireInterval)
        {
            Fire();
            fireTimer = 0f;
        }

        //this will need to change when lizard can climb walls - we might not always be using y axis
        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y + heightAboveTarget, target.transform.position.z);
        sourceObject.transform.position = targetPos;
   
    }

    void Fire()
    {
        Transform firePoint = sourceObject.transform;
        Vector3 fireRotation = (target.transform.position - sourceObject.transform.position).normalized;
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = fireRotation * projectileSpeed;
            }
        }
    }
}
