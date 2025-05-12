using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dad : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform lizard;
    public SlipperShooter slipper;
    public Animator animator;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if(animator.enabled == false)
            {
                animator.enabled = true;
            }
            navMeshAgent.destination = lizard.position;
        }
        else
        {
            animator.enabled = false;
        }
    }
    public void Fire()
    {
        slipper.Fire();
    }
}
