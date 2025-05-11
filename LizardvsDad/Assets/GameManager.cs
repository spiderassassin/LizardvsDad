using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        ChillTime,
        DadCome, 
        DadTime
    }
    public float chill_phase_Length;
    public float dad_come_Length;
    public float dad_phase_Length;
    public bool dad_time = false;
    public SlipperShooter shooter;
    public GameState gameState;
    private static GameManager _instance;
    public float timer = 0f;
    public GameObject alert;
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
        if((gameState == GameState.ChillTime) && (timer>chill_phase_Length))
        {
            gameState = GameState.DadCome;
            timer = 0;
            alert.SetActive(true);
        }

        if ((gameState == GameState.DadCome) && (dad_time == true))
        {
            shooter.active = true;
            gameState = GameState.DadTime;
            timer = 0;
            dad_time = false;
            
        }


        else if ((gameState == GameState.DadTime) && (timer > dad_phase_Length))
        {
            shooter.active = false;
            gameState = GameState.ChillTime;
            timer = 0;
            alert.SetActive(false);
        }

    }
}
