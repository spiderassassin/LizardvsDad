using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip jump;

    public AudioSource music;

    
    public GameObject audioSource;



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