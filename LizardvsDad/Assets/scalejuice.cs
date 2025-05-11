using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scalejuice : MonoBehaviour
{
    float time = 0;
    public RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime * 2.7f;
        rectTransform.localScale = new Vector3(1 + Mathf.Sin(time) * Mathf.Sin(time), 1 + Mathf.Sin(time) * Mathf.Sin(time));
    }
}
