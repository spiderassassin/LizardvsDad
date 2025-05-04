using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    public Transform tongue; // Assign your tongue object here
    public float maxLength = 5f;
    public float speed = 10f;
    public float descending_speed = 100f;

    private float currentLength = 0f;
    private bool extending = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            extending = true;
        if (Input.GetKeyUp(KeyCode.Space))
            extending = false;

        // Adjust length
        float targetLength = extending ? maxLength : 0f;

        
        if (extending == false)
        {
            currentLength = Mathf.MoveTowards(currentLength, targetLength, descending_speed * Time.deltaTime);
        }
        else
        {
            currentLength = Mathf.MoveTowards(currentLength, targetLength, speed * Time.deltaTime);
        }

        // Scale tongue along Z and reposition
        tongue.localScale = new Vector3(1f, currentLength, 1f );
        tongue.localPosition = new Vector3(0f, -currentLength / 2f, 0f);
    }
}
