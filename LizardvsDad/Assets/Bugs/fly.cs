using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    public float speed;
    public float time = 0;
    public Transform camera;
    Vector3 basePosition;
    public bool isFly;
    // Start is called before the first frame update
    void Start()
    {
        basePosition = transform.position;
        camera = Camera.main.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime * speed;
        float sin_value = Mathf.Sin(time) * 0.01f;
        if (isFly == true)
        {
            transform.position = new Vector3(basePosition.x, basePosition.y + sin_value, basePosition.z);
        }
        
        Vector3 camera_position = camera.position;
        camera_position.y = transform.position.y;
        transform.LookAt(camera_position);
        transform.Rotate(0, 180, 0);
    }
 

}
