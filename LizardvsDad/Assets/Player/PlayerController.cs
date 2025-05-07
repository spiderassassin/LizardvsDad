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
    public LayerMask climbable;
    public LayerMask obstacle;
    float turnSmoothVelocity;
    public Animator animator;
    private float prev_speed;
    public AnimationCurve curve;
    public float time;
    Vector3 climbPoint;
    public Transform floor;
    public float skinOffset = 0.1f;

    private void Start()
    {
        prev_speed = animator.speed;
        animator.speed = 0;
        //print(camera.eulerAngles.y);
    }

    void FixedUpdate()
    {
        RaycastHit current_floor;
        Debug.DrawRay(transform.position, -transform.up * 0.3f, Color.red);
        if (Physics.Raycast(transform.position, -transform.up, out current_floor, 0.3f, climbable))
        {
            floor = current_floor.transform;
           

        }


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = transform.forward * vertical;
        //print(transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.15f, climbable))
        {
            print("wall detected");
            transform.rotation = Quaternion.LookRotation(Quaternion.FromToRotation(transform.up, hit.normal)*transform.forward, hit.normal);
            climbPoint = hit.point;
            transform.position = climbPoint - climbPoint * skinOffset;

            // Movement direction
            
        }
        /*
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.1f, climbable))
        {
            if(hit.transform.gameObject != floor.gameObject)
            {
                print("wall detected" + hit.transform.gameObject.name);
                print(Quaternion.FromToRotation(transform.up, hit.normal).eulerAngles);

                transform.Rotate(-90f, 0f, 0f, Space.Self);

                climbPoint = hit.point;
                float value = hit.normal.x + hit.normal.y + hit.normal.z;
                transform.position = climbPoint + hit.normal * skinOffset;
            }
            

        }*/
        

            transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            animator.speed = prev_speed;
        }
        else
        {
            animator.speed = 0;
        }
        if (true && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.15f, obstacle) == false)
        {
            Move(direction);
        }
            
    }

    public void Move(Vector3 direction)
    {
        
        
        // Move forward
        rb.MovePosition(rb.position + (direction) * moveSpeed * Time.deltaTime);
        
    }
}
