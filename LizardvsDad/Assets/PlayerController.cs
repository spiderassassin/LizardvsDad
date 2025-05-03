using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public Animator animator;
    private float prev_speed;

    private void Start()
    {
        prev_speed = animator.speed;
        animator.speed = 0;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (vertical < 0)
        {
            vertical = 0f;
        }

        // Movement direction
        Vector3 direction = new Vector3(0f, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.speed = prev_speed;
            Move(direction);
        }
        else
        {
            animator.speed = 0;
        }
    }

    public void Move(Vector3 direction)
    {
        // Move forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
