using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dadManager : MonoBehaviour
{

    public List<GameObject> dad = new List<GameObject>();
    public float frequency;
    float timer = 0f;
    int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= frequency)
        {
            timer = 0;
            dad[index].SetActive(false);
            index = Random.Range(0, dad.Count);
            dad[index].SetActive(true);
        }
    }
}
