
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    //Sound array
    public Sounds[] sounds;

    public AudioClip[] clips;

    public static AudioManager instance;


    private ObjectPool pool;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);
        foreach ( Sounds s in sounds )
        {   
            s.audioSource = gameObject.AddComponent<AudioSource>(); 
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }

        pool = GetComponent<ObjectPool>();
    }


    private void Start()
    {
        GameObject soundGameObject = new GameObject("Sound");
        soundGameObject.AddComponent<AudioSource>();
        soundGameObject.name = "Sound";
        pool.Initialize(soundGameObject, 10);
    }
    public void Play (string name)
    {
        //FindObjectOfType<AudioManager>().Play("PlayerDeath");
        Sounds s = Array.Find(sounds, s => s.name == name);
        s.audioSource.Play();
    }

    public void PlaySound (int index)
    { 
        GameObject soundGameObject = pool.CreateObject();
        AudioSource audioSource = soundGameObject.GetComponent<AudioSource>();
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(clips[index]);
    }



}
