using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    public Transform tongue; // Assign your tongue object here
    public float maxLength = 5f;
    public float speed = 10f;
    public float descending_speed = 100f;
    public LineRenderer lineRenderer;
    private float currentLength = 0f;
    private bool extending = false;
    private Vector3 point;
    public LayerMask bugs;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            extending = true;
        if (Input.GetKeyUp(KeyCode.Space))
            extending = false;

        // Adjust length
        float targetLength = 0;
        if(extending == true)
        {
            targetLength = maxLength;
        }


        
        if (extending == false)
        {
            currentLength = Mathf.MoveTowards(currentLength, targetLength, descending_speed * Time.deltaTime);
        }
        else
        {
            currentLength = Mathf.MoveTowards(currentLength, targetLength, speed * Time.deltaTime);
        }
        point = tongue.position + tongue.up * currentLength;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, tongue.position);
        lineRenderer.SetPosition(1, point);

        RaycastHit hit;
        if (Physics.Raycast(tongue.position, tongue.up, out hit, currentLength, bugs))
        {
            print("yumm");
            Destroy(hit.transform.gameObject);
        }


        // Scale tongue along Z and reposition
        //tongue.localScale = new Vector3(1f, currentLength, 1f );
        //tongue.localPosition = new Vector3(0f, -currentLength / 2f, 0f);
    }
}
