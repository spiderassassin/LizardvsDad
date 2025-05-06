using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugspawner : MonoBehaviour
{
    public List<Transform> grassHopperSpawns = new List<Transform>();
    public List<bool> grassHopperSpawnsBool = new List<bool>();
    public List<Transform> flySpawns = new List<Transform>();
    public List<bool> flySpawnsBool = new List<bool>();
    public GameObject fly;
    public GameObject grassHopper;
    public int number_of_bugs = 0;
    public int bugs_limit;
    public float timer = 0;
    public int spawnFrequency;
    private static bugspawner _instance;
    bool filled = false;
    public static bugspawner Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }


    }
    // Start is called before the first frame update
        void Start()
    {
        for(int i=0; i < grassHopperSpawns.Count; i++)
        {
            grassHopperSpawnsBool.Add(false);
        }
        for (int i = 0; i < flySpawns.Count; i++)
        {
            flySpawnsBool.Add(false);
        }


        bugs_limit = grassHopperSpawns.Count + flySpawns.Count;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        
        if (((int)timer == 5) && (number_of_bugs!=bugs_limit))
        {
            timer = 0;
            filled = false;
            
            int index = Random.Range(0, bugs_limit);
            //print("index" + index);

            if (index < grassHopperSpawns.Count)
                {
                    if(grassHopperSpawns[index].childCount==0)
                    {
                        grassHopperSpawnsBool[index] = true;
                        Instantiate(grassHopper, grassHopperSpawns[index]);
                        filled = true;
                    }
                }
            else
            {
                index = index - grassHopperSpawns.Count;
                    if (flySpawns[index].childCount == 0)
                    {
                        flySpawnsBool[index] = true;
                        Instantiate(fly, flySpawns[index]);
                        filled = true;
                    }
            }

            if(filled == true)
            {
                number_of_bugs++;
            }
            
        }
    }
}
