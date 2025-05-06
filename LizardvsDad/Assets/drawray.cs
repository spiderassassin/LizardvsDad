using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawray : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(point1.position, new Vector3(0,0,1) * 5f, Color.red);
        Debug.DrawRay(point2.position, Vector3.up * 5f, Color.red);
    }
}
