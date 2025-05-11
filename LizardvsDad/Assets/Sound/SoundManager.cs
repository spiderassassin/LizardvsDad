using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip ChillTrack;
    public AudioClip ActionTrack;
    public AudioClip DadStomp;
    public List<AudioClip> barks = new List<AudioClip>();
    int choice = 0;
    public AudioSource music;

    
    public GameObject audioSource;
    bool bark_played = false;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.ChillTime)
        {
            if(music.clip != ChillTrack)
            {
                music.clip = ChillTrack;
                music.Play();
            }
        }

        if (GameManager.Instance.gameState == GameManager.GameState.DadCome)
        {
            if (music.clip != DadStomp && music.clip != barks[choice])
            {
                music.loop = false;
                music.clip = DadStomp;
                music.Play();
            }

            if (music.clip == DadStomp && music.isPlaying == false)
            {
                choice = Random.Range(0, barks.Count);
                music.clip = barks[choice];
                music.Play();
                bark_played = true;
            }



            if (music.clip == barks[choice] && music.isPlaying == false)
            {
                GameManager.Instance.dad_time = true;
            }



        }

        if (GameManager.Instance.gameState == GameManager.GameState.DadTime)
        {
            if (music.clip != ActionTrack)
            {
                music.loop = true;
                music.clip = ActionTrack;
                music.Play();
            }
        }

        


    }






    public GameObject PlaySound(AudioClip clip, bool loop, Transform parent)
    {
        GameObject obj = Instantiate(audioSource);
        obj.transform.position = parent.position;
        obj.transform.SetParent(parent);
        obj.GetComponent<AudioSource>().loop = loop;
        obj.GetComponent<AudioSource>().clip = clip;
        obj.GetComponent<AudioSource>().Play();



        return obj;

    }

    public void StopSound(GameObject obj)
    {
        Destroy(obj);
    }

}