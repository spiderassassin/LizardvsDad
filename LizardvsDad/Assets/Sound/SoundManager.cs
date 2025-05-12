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
    public AudioClip dadGo;
    int choice = 0;
    public AudioSource music;
    public AudioSource doorCreak;


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
            //print("anim" + GameManager.Instance.Door.GetCurrentAnimatorStateInfo(0).normalizedTime);
            if (music.clip != DadStomp && music.clip != barks[choice])
            {
                music.loop = false;
                music.clip = DadStomp;
                music.Play();
            }

            else if ((music.clip == DadStomp && music.isPlaying == false) && GameManager.Instance.Door.GetBool("DoorOpen") == false)
            {
                GameManager.Instance.Dad.SetActive(true);
                GameManager.Instance.Door.SetBool("DoorOpen", true);
                doorCreak.Play();
                
            }

            else if((GameManager.Instance.Door.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f && GameManager.Instance.Door.GetCurrentAnimatorStateInfo(0).IsName("DoorOpen")) && music.clip != barks[choice])
            {
                choice = Random.Range(0, barks.Count);
                music.clip = barks[choice];
                music.Play();
                bark_played = true;
            }



            else if (music.clip == barks[choice] && music.isPlaying == false)
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

        if (GameManager.Instance.gameState == GameManager.GameState.DadGo)
        {
            if (music.clip != dadGo)
            {
                music.loop = false;
                music.clip = dadGo;
                music.Play();
            }
            if (music.clip == dadGo && music.isPlaying == false)
            {
                GameManager.Instance.Door.SetBool("DoorOpen", false);
                GameManager.Instance.dad_left = true;
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