using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        ChillTime,
        DadTime
    }
    public float chill_phase_Length;
    public float dad_phase_Length;
    public SlipperShooter shooter;
    public GameState gameState;
    private static GameManager _instance;
    public float timer = 0f;
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
            shooter.active = true;
            gameState = GameState.DadTime;
            timer = 0;
        }
        else if ((gameState == GameState.DadTime) && (timer > dad_phase_Length))
        {
            shooter.active = false;
            gameState = GameState.ChillTime;
            timer = 0;
        }

    }
}
