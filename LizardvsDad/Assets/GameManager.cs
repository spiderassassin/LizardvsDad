using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        ChillTime,
        DadCome, 
        DadTime,
        DadGo
    }
    public float chill_phase_Length;
    public float dad_come_Length;
    public float dad_phase_Length;
    public bool dad_time = false;
    public bool dad_left = false;
    public SlipperShooter shooter;
    public GameState gameState;
    private static GameManager _instance;
    public float timer = 0f;
    public GameObject alert;
    public GameObject DadisHere;
    public GameObject Run;
    public GameObject Dad;
    public Animator Door;
    public Transform dad_transform;
    
    public static GameManager Instance

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
        gameState = GameState.ChillTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if((gameState == GameState.ChillTime) && (timer>chill_phase_Length))//SWITCHING TO DADCOME
        {
            gameState = GameState.DadCome;
            timer = 0;
            alert.SetActive(true);
            DadisHere.SetActive(true);
        }

        else if ((gameState == GameState.DadCome) && (dad_time == true))//SWITCHING TO DADTIME
        {
            Dad.GetComponent<dad>().active = true;
            shooter.active = true;
            gameState = GameState.DadTime;
            timer = 0;
            dad_time = false;
            DadisHere.SetActive(false);
            Run.SetActive(true);

        }



        else if ((gameState == GameState.DadTime) && (timer > dad_phase_Length))//SWITCHING TO CHILLTIME
        {
            Dad.SetActive(false);
            shooter.active = false;
            gameState = GameState.DadGo;
            timer = 0;
            alert.SetActive(false);
            Run.SetActive(false);
        }

        else if ((gameState == GameState.DadGo) && (dad_left == true))//SWITCHING TO CHILLTIME
        {
            Dad.GetComponent<dad>().active = false;
            Dad.transform.position = dad_transform.position;
            Dad.transform.rotation = dad_transform.rotation;
            Dad.SetActive(false);
            
            shooter.active = false;
            dad_left = false;
            gameState = GameState.ChillTime;
            timer = 0;
            alert.SetActive(false);
            Run.SetActive(false);
        }




    }
}
