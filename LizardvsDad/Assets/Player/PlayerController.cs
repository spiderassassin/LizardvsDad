using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camera;
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Animator animator;
    private float prev_speed;

    private void Start()
    {
        prev_speed = animator.speed;
        animator.speed = 0;
        print(camera.eulerAngles.y);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //if (vertical < 0)
        //{
            //vertical = 0f;
        //}

        // Movement direction
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Move(movDir);

            animator.speed = prev_speed;
        }
        else
        {
            animator.speed = 0;
        }
    }

    public void Move(Vector3 direction)
    {
        // Move forward
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }
}
